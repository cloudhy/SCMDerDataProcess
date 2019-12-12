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
        public static string conn = ConfigurationManager.AppSettings["scmdb"];
        public static string UIDReplaceCharacter = ConfigurationManager.AppSettings["UIDReplaceCharacter"];
        public static string OwnerCodeDefault = ConfigurationManager.AppSettings["OwnerCodeDefault"];
        public static string OwnerNameDefault = ConfigurationManager.AppSettings["OwnerNameDefault"];
        public static string VindicatorCodeDefault = ConfigurationManager.AppSettings["VindicatorCodeDefault"];
        public static string VindicatorNameDefault = ConfigurationManager.AppSettings["VindicatorNameDefault"];
        public static string ClassifyIdDefault = ConfigurationManager.AppSettings["ClassifyIdDefault"];
        public static string CatalogIdDefault = ConfigurationManager.AppSettings["CatalogIdDefault"];
        public static string DBSPublishUrl = ConfigurationManager.AppSettings["DBSPublishUrl"];

        public static string DBSId;
        public static string UId;


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
                    string sql = String.Format("UPDATE DerDataInfo SET isTest={0} where id='{1}'", testResult, derdataid);
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
                SqlTransaction transaction=null;
                try
                {
                    connDB.Open();
                    transaction = connDB.BeginTransaction();

                    string queryDerDataSql = String.Format("SELECT DBId,Name,AccessType,AccessKey,Des FROM DerDataInfo WHERE Id='{0}'", derdataid);

                    var derDatainfo = connDB.Query<DerDataInfo>(queryDerDataSql,null, transaction).FirstOrDefault();
                    //transaction.Commit();

                    string accessKey = derDatainfo.AccessKey;
                    var replaceCharacters = UIDReplaceCharacter.Split(',');
                    foreach (var item in replaceCharacters)
                    {
                        accessKey = accessKey.Replace(item, "");
                    }

                    DBSInfo dbsinfo = new DBSInfo()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UID = accessKey,
                        RouteTemplate=null,
                        Method = "Get,Post",
                        SourceType = derDatainfo.AccessType,
                        SourceID = derdataid,
                        KeyWords = derDatainfo.Des,
                        Abstract = derDatainfo.Des,
                        Des = derDatainfo.Des,
                        IsAble=1,
                        IsUpdate=1
                    };

                    DBSId = dbsinfo.Id;
                    UId = dbsinfo.UID;



                    var resultInsertDBSInfoData = connDB.Execute(@"Insert into DBSInfo(Id, UID, RouteTemplate, Method, SourceType, SourceID, KeyWords, Abstract, Des,IsAble, IsUpdate) " +
                        "VALUES (@Id, @UID, @RouteTemplate, @Method, @SourceType, @SourceID, @KeyWords, @Abstract, @Des, @IsAble, @IsUpdate) ",
                        dbsinfo,
                        transaction);

                    var propertyInfo = new PropertyInfo()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UID = dbsinfo.Id,
                        TbName = "DBSInfo",
                        Name = derDatainfo.Des,
                        OwnerCode = OwnerCodeDefault,
                        OwnerName = OwnerNameDefault,
                        VindicatorCode = VindicatorCodeDefault,
                        VindicatorName = VindicatorNameDefault,
                        Des = derDatainfo.Des,
                        IsAble = 1
                    };

                    var resultInsertPropertyInfo = connDB.Execute(@"INSERT INTO  PropertyInfo(Id, UID, TbName, Name, OwnerCode, OwnerName, VindicatorCode, VindicatorName, Des, IsAble)"+ 
                     " VALUES (@Id, @UID, @TbName, @Name, @OwnerCode, @OwnerName, @VindicatorCode, @VindicatorName, @Des, @IsAble)", 
                        propertyInfo,
                        transaction);


                    if (resultInsertDBSInfoData <= 0 || resultInsertPropertyInfo <= 0)
                    {
                        transaction.Rollback();
                        return false;
                    }

                    string sqlExcuteIPara = String.Format("  INSERT INTO " +
                        "DBSIParams " +
                        "([ID],[DId],[PKey],[Name],[SN],[Dtp],[IsRequired],[Local],[Des],[DefaultValue],[Unit],[BZ],[IsAble])" +
                        "SELECT NEWID() AS [ID] ," +
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
                        "[IsAble] FROM [DerDataIParams] WHERE DId='{1}'",
                        dbsinfo.Id,
                        derdataid
                        );


                    string sqlExcuteOPara = String.Format("  INSERT INTO " +
                        "DBSOParams " +
                        "([ID],[DId],[PKey],[Name],[SN],[Dtp],[IsRequired],[Local],[Des],[DefaultValue],[Unit],[BZ],[IsAble])" +
                        "SELECT NEWID() AS [ID] ," +
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
                        "[IsAble] FROM [DerDataOParams] WHERE DId='{1}'",
                        dbsinfo.Id,
                        derdataid
                        );

                    int resultIPara = connDB.Execute(sqlExcuteIPara,null, transaction);
                    int resultOPara = connDB.Execute(sqlExcuteOPara, null, transaction);

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
                catch (Exception ex)
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

        /// <summary>
        /// 获取数据服务信息
        /// </summary>
        /// <returns></returns>
        public List<DBSInfo> GetDBSInfo()
        {
            using (SqlConnection connDB=new SqlConnection(conn))
            {
                try
                {
                    connDB.Open();
                    var dbs = connDB.Query<DBSInfo>("SELECT * FROM DBSINFO " +
                        " WHERE ID NOT IN " +
                        " (SELECT SERVICEID FROM ServiceCatalog) " +
                        " AND ISABLE = 1 "+
                        " ORDER BY ORDERX DESC").ToList();

                    return dbs;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    connDB.Close();
                }

                
            }
        }


        /// <summary>
        /// 数据服务自动编目
        /// </summary>
        /// <param name="dbsid"></param>
        /// <returns></returns>
        public bool ServiceAutoCatalog(string dbsid,string serviceType="DBSInfo")
        {
            var serviceCatalog = new ServiceCatalog()
            {
                Id = Guid.NewGuid().ToString(),
                ServiceId = dbsid,
                ServiceType = serviceType,
                ClassifyId = ClassifyIdDefault,
                CatalogId = CatalogIdDefault,
                CreateDate = DateTime.Now
            };

            using (SqlConnection connDB = new SqlConnection(conn))
            {
                try
                {
                    connDB.Open();
                    var result = connDB.Execute(@"insert into  ServiceCatalog(Id, ServiceId, ServiceType, ClassifyId, CatalogId, BZ, CreateDate) 
                      VALUES (@Id, @ServiceId, @ServiceType, @ClassifyId, @CatalogId, @BZ, @CreateDate)", serviceCatalog);
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


        public bool ServiceAutoPrivi(string uid, string sourceId, string serviceType)
        {
            using (HttpClient cli = new HttpClient())
            {
                try
                {
                    var url = String.Format(DBSPublishUrl, uid);
                    var resultPublishService = cli.PostAsync(url, null).Result.Content.ReadAsStringAsync().Result;
                    if (!resultPublishService.Contains("200")) return false;

                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {

                }

            }

            using (SqlConnection connDB = new SqlConnection(conn))
            {
                var serviceReleaseInfo = new ServiceReleaseInfo()
                {
                    Id = Guid.NewGuid().ToString(),
                    ServiceType = serviceType,
                    SourceId = sourceId,
                    ReleaseTime = DateTime.Now,
                    RunState = 1,
                    ReleaseState = 1,
                    IsPublic = 1,
                    IsAble = 1
                };
                try
                {
                    connDB.Open();
                    connDB.Insert(serviceReleaseInfo);
                    return true;
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

        }

        public bool ServiceAutoPublish(string dbsid, string uid, string serviceType="DBSInfo")
        {
            using (HttpClient cli = new HttpClient())
            {
                try
                {
                    var url = String.Format(DBSPublishUrl, uid);
                    var resultPublishService = cli.PostAsync(url, null).Result.Content.ReadAsStringAsync().Result;
                    if (!resultPublishService.Contains("200")) return false;

                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {

                }

            }

            using (SqlConnection connDB = new SqlConnection(conn))
            {
                var serviceReleaseInfo = new ServiceReleaseInfo()
                {
                    Id = Guid.NewGuid().ToString(),
                    ServiceType = serviceType,
                    SourceId = dbsid,
                    ReleaseTime = DateTime.Now,
                    RunState = 1,
                    ReleaseState = 1,
                    IsPublic = 1,
                    IsAble = 1
                };
                try
                {
                    connDB.Open();
                    int count=connDB.Execute(@"insert into  serviceReleaseInfo (Id, ServiceType, SourceId, ReleaseTime, RunState, ReleaseState, IsPublic, BZ, IsAble) 
                                VALUES  (@Id, @ServiceType, @SourceId, @ReleaseTime, @RunState, @ReleaseState, @IsPublic, @BZ, @IsAble) ",serviceReleaseInfo);
                    if (count>0) return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    connDB.Close();
                }

                return false;
            }
        }


        public List<DBSInfo> GetUnPublishService()
        {
            using (SqlConnection connDB = new SqlConnection(conn))
            {
                try
                {
                    connDB.Open();
                    var dbs = connDB.Query<DBSInfo>("SELECT * FROM DBSINFO " +
                        " WHERE ID NOT IN " +
                        " (SELECT ID FROM ServiceReleaseInfo) " +
                        " AND ISABLE = 1 " +
                        " ORDER BY ORDERX DESC").ToList();

                    return dbs;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    connDB.Close();
                }


            }
        }

        public bool ServiceDeleteDerdataRelationInfo(string Id)
        {
            string Sql1 = String.Format(@"delete from DerDataOParams where did ='{0}' ", Id);
            string Sql2 = String.Format(@"delete from DBSIParams where did in (select Id from dbsinfo where SourceID='{0}')", Id);
            string Sql3 = String.Format(@"delete from DBSOParams where did in (select Id from dbsinfo where SourceID='{0}')", Id);
            string Sql4 = String.Format(@"delete  from PropertyInfo where uid in  (select Id from  dbsinfo where SourceID='{0}') ", Id);
            string Sql5 = String.Format(@"delete from DBSInfo where SourceID = '{0}' ", Id);
            string Sql6 = String.Format(@"delete from ServiceCatalog where ServiceId ='{0}' ", Id);
            string Sql7 = String.Format(@"delete from serviceReleaseInfo where SourceId ='{0}' ", Id);

            using (SqlConnection connDB = new SqlConnection(conn))
            {
                try
                {
                    connDB.Open();
                    int result1=connDB.Execute(Sql1);
                    int result2 = connDB.Execute(Sql2);
                    int result3 = connDB.Execute(Sql3);
                    int result4 = connDB.Execute(Sql4);
                    int result5 = connDB.Execute(Sql5);
                    int result6 = connDB.Execute(Sql6);
                    int result7 = connDB.Execute(Sql7);

                    if(result1>0 && result2 > 0 && result3 > 0 && 
                        result4 > 0 && result5 > 0 && result6 > 0 && result7 > 0)
                    {
                        return true;
                    }
                }
                catch(Exception ex)
                {

                }
                finally
                {
                    connDB.Close();
                    
                }
                return false;
            }
        }

    }
}
