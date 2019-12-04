using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DerDataModel;

namespace DerDataBusiness
{
    /// <summary>
    ///自动封装服务
    /// </summary>
    public class AutoService : IAutoService
    {
        public static string DerDataCheckUrl = ConfigurationManager.AppSettings["DerDataCheckUrl"];
        public static string DbsPublishUrl = ConfigurationManager.AppSettings["DbsPublishUrl"];
        public static string conn = ConfigurationManager.AppSettings["scmdb"];
        public static string UIDReplaceCharacter = ConfigurationManager.AppSettings["UIDReplaceCharacter"];


        /// <summary>
        /// 单个衍生品测试
        /// </summary>
        /// <param name="derdataid"></param>
        /// <returns></returns>
        public bool DerDataCheck(string derdataid)
        {
            string url = string.Format(DerDataCheckUrl, derdataid);

            using (HttpClient cli = new HttpClient())
            {
                try
                {
                    var result = cli.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
                    if (result.Contains("200")) return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
            return false;

        }

        /// <summary>
        /// 更新衍生品测试信息
        /// </summary>
        /// <param name="derdataid"></param>
        /// <param name="testresult"></param>
        /// <returns></returns>
        public bool UpdateDerDataStatus(string derdataid, bool testresult)
        {
            using (SqlConnection connDB = new SqlConnection(conn))
            {
                try
                {
                    connDB.Open();
                    string testResult = testresult == true ? "1" : "2";
                    string sql = String.Format("UPDATE DerDataInfo SET isTest={0} where id={1}", testResult, derdataid);
                    int result = connDB.Execute(sql);
                    if (result > 0) return true;



                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    connDB.Close();
                }

            }

            return false;
        }

        /// <summary>
        /// 衍生品封装为数据服务
        /// </summary>
        /// <param name="derdataid"></param>
        /// <returns></returns>
        public bool DerDataToDBService(string derdataid)
        {
            using (SqlConnection connDB = new SqlConnection(conn))
            {
                var transaction = connDB.BeginTransaction();
                try
                {
                    connDB.Open();                    
                    
                    string queryDerDataSql = String.Format("SELECT DBId,Name,AccessType,AccessKey,Des FROM DerDataInfo WHERE Id={0}", derdataid);

                    var derDatainfo = connDB.Query<DerDataInfo>(queryDerDataSql).FirstOrDefault();

                    string accessKey = derDatainfo.AccessKey;
                    var replaceCharacters = UIDReplaceCharacter.Split(',');
                    foreach(var item in replaceCharacters)
                    {
                        accessKey = accessKey.Replace(item,"");
                    }

                    DBSInfo dbsinfo = new DBSInfo()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UID = accessKey,
                        Method = "Get,Post",
                        SourceType = derDatainfo.AccessType,
                        SourceID = derdataid,
                        KeyWords = derDatainfo.Des,
                        Abstract = derDatainfo.Des,
                        Des = derDatainfo.Des,
                        IsAble = 1
                    };

                    connDB.Insert(dbsinfo);

                    string sqlExcuteIPara = String.Format("  INSERT INTO DBSIParams SELECT NEWID() AS [ID] ," +
                        "'{0}' AS [DId] " +
                        ",[PKey] ,[Name] ," +
                        "[SN] ," +
                        "[Dtp] ," +
                        "[IsRequired] ," +
                        "[Local] ," +
                        "[Des] ," +
                        "[DefaultValue] ," +
                        "[Unit] ," +
                        "[BZ] ," +
                        "[IsAble] FROM [DerDataIParams] WHERE Id='{1}'",
                        dbsinfo.Id,
                        derdataid
                        );


                    string sqlExcuteOPara = String.Format("  INSERT INTO DBSOParams SELECT NEWID() AS [ID] ," +
                        "'{0}' AS [DId] " +
                        ",[PKey] ,[Name] ," +
                        "[SN] ," +
                        "[Dtp] ," +
                        "[IsRequired] ," +
                        "[Local] ," +
                        "[Des] ," +
                        "[DefaultValue] ," +
                        "[Unit] ," +
                        "[BZ] ," +
                        "[IsAble] FROM [DerDataOParams] WHERE Id='{1}'",
                        dbsinfo.Id,
                        derdataid
                        );

                    int resultIPara = connDB.Execute(sqlExcuteIPara);
                    int resultOPara = connDB.Execute(sqlExcuteIPara);

                    if (resultIPara >= 0 && resultOPara >= 0)
                    {
                        transaction.Commit();
                        return true;
                    }
                    else
                    {
                        transaction.Rollback();
                    }
                       
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                }
                finally
                {
                    connDB.Close();
                }
                


            }

            return false;
        }

        private bool  SyncDerDataToDB(string derdataid,string dbsid)
        {

            return false;
        }



        public bool ServiceAutoCatalog(string dbsid)
        {
            throw new NotImplementedException();
        }

        public bool ServiceAutoPrivi(string uid)
        {
            throw new NotImplementedException();
        }

        public bool ServiceAutoPublish(string dbsid, string uid)
        {
            throw new NotImplementedException();
        }
    }
}
