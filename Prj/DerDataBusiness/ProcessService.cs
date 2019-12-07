using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DerDataModel;
using System.Management;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using Dapper;
using System.Data;

namespace DerDataBusiness
{




    /// <summary>
    /// 衍生品处理程序
    /// </summary>
    public class ProcessService
    {

        public static string ConnStr = ConfigurationManager.AppSettings["scmdb"];
        public static SqlConnection conn = new SqlConnection(ConnStr);
        public static List<DerDataInfo> GetDerList(int flag=1)
        {
           
            
            try
            {
                conn.Open();

                string sql = null;
                if(flag==1)
                {
                     sql = "select * from DerDataInfo where IsAble != 2 and (Select count(1) from DerDataOParams where DId = DerDataInfo.Id) = 0" +
                        "Order BY OrderX DESC";
                }
                else
                {
                    sql = "select * from DerDataInfo where IsAble != 2 " +
                        "Order BY OrderX DESC";
                }


               

                var derDataList = conn.Query<DerDataInfo>(sql);

                var result = derDataList.ToList();
                conn.Close();
                return result;
            }
            catch(Exception ex)
            {
                conn.Close();
                return null;
            }

        }




        /// <summary>
        /// 修改别名
        /// </summary>
        public static void ReviseAlias()
        {
            //string ConnStr = ConfigurationManager.AppSettings["scmdb"];
            //SqlConnection conn = new SqlConnection(ConnStr);
            try
            {
                conn.Open();

                Dictionary<string, string> derDic = new Dictionary<string, string>();
                StreamReader sr = new StreamReader(@"..\..\field.txt", Encoding.Default);
                string line = string.Empty;
                while (!string.IsNullOrEmpty(line = sr.ReadLine()))
                {
                    string[] value = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (!derDic.ContainsKey(value[0]))
                        derDic.Add(value[0], value[1]);
                }


                foreach (var item in derDic)
                {
                    string sql = "Update DerDataOParams Set Name = '{0}' where PKey = '{1}'";
                    sql = string.Format(sql, item.Value, item.Key);
                    conn.Execute(sql);

                    //sql = "Update DBSOParams Set Name = '{0}' where PKey = '{1}'";
                    //sql = string.Format(sql, item.Value, item.Key);
                    //conn.Execute(sql);
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 添加衍生品输出参数
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="DbId"></param>
        /// <param name="AccessKey"></param>
        public static void AddOPara(string Id, string DBId, string AccessKey)
        {
            try
            {
                string sql = string.Format("select * from DerDataIParams where DId = '{0}'",Id);

                var inputParams = conn.Query<DerDataIParams>(sql).ToList();

                var inputPs = getDynObj(inputParams);

                sql = string.Format("select ConnStr from DBInfo where Id = '{0}'", DBId);
                string dbConnStr = conn.Query<string>(sql).First();

                using (SqlConnection connDB = new SqlConnection(dbConnStr))
                {
                    connDB.Open();

                    //var result = connDB.Query<dynamic>(derdata.AccessKey, inputPs, null, true, 5000, CommandType.StoredProcedure);
                    var reader = connDB.ExecuteReader(AccessKey, inputPs, null, 5000, CommandType.StoredProcedure);

                    List<string> OutputNames = new List<string>();
                    List<string> dataType = new List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        OutputNames.Add(reader.GetName(i));
                        dataType.Add(reader.GetDataTypeName(i));
                    }
                    reader.Close();


                    for (int i = 0; i < OutputNames.Count; i++)
                    {
                        sql = "Select count(1) from DerDataOParams where PKey = '{0}' and DId = '{1}'";
                        sql = string.Format(sql, OutputNames[i], Id);
                        int cnt = conn.Query<int>(sql).First();

                        if (cnt == 0)
                        {
                            sql = "select ItemValue from [dbo].[Base_DataItem] where ItemName = '{0}'";
                            sql = string.Format(sql, dataType[i]);
                            string dtp = conn.Query<string>(sql).First();

                            sql = "INSERT INTO [dbo].[DerDataOParams](Id,DId,PKey,Name,SN,Dtp,IsRequired,Local,Unit,DefaultValue,IsAble) VALUES(@Id, @DId, @PKey, @Name, @SN, @Dtp, @IsRequired, @Local, @Unit, @DefaultValue, @IsAble)";

                            conn.Execute(sql, new
                            {
                                Id = Guid.NewGuid().ToString(),
                                DId = Id,
                                PKey = OutputNames[i],
                                Name = OutputNames[i],
                                SN = i,
                                Dtp = int.Parse(dtp),
                                IsRequired = "1",
                                Local = "zh-cn",
                                Unit = "",
                                DefaultValue = "",
                                IsAble = 1,
                            });
                        }
                    }



                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error[{0}]:{1}", Id, ex.ToString());
            }
        }



        public static void DeleteList(List<string> deleteIds)
        {
            try
            {
                conn.Open();
                string sql = "delete from DerDataOParams where DId in (";
                foreach (var item in deleteIds)
                {
                    sql += "'" + item + "'" + ",";
                }

                int length = sql.Length;

                sql = sql.Substring(0, length - 1);
                sql += ")";

                conn.Execute(sql);
                conn.Close();

            }
            catch
            {

            }
           


        }



        /// <summary>
        /// 获取输入参数值
        /// </summary>
        /// <param name="inputPs"></param>
        /// <returns></returns>
        private static DynamicParameters getDynObj(List<DerDataIParams> inputPs)
        {
            try
            {
                if (inputPs == null) return null;

                var obj = new DynamicParameters();
                foreach (var item in inputPs)
                {

                    string key = item.PKey;
                    string VData = item.DefaultValue;

                    ParamDTP dtpType = (ParamDTP)item.Dtp;
                    switch (dtpType)
                    {
                        case ParamDTP.t_int:
                            {
                                int val = Convert.ToInt32(VData.ToString());
                                obj.Add(key, val);

                            }
                            break;
                        case ParamDTP.t_datetime:
                            {
                                DateTime val = Convert.ToDateTime(VData.ToString());
                                obj.Add(key, val);
                            }
                            break;
                        case ParamDTP.t_double:
                            {
                                double val = Convert.ToDouble(VData.ToString());
                                obj.Add(key, val);
                            }
                            break;
                        case ParamDTP.t_geometry:
                            {
                                String val = Convert.ToString(VData.ToString());
                                obj.Add(key, val);
                            }
                            break;
                        case ParamDTP.t_stream:
                            {
                                string data = Convert.ToString(VData.ToString());
                                byte[] val = System.Text.Encoding.Default.GetBytes(data);
                                obj.Add(key, val);
                            }
                            break;
                        case ParamDTP.t_struct:
                            {
                                obj.Add(key, VData.ToString());
                            }
                            break;
                        case ParamDTP.t_text:
                            {
                                string val = Convert.ToString(VData.ToString());
                                obj.Add(key, val);
                            }
                            break;
                        default:
                            {
                                obj.Add(key, VData.ToString());
                            }
                            break;
                    }


                }
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        private static string GetDataType(int dtp)
        {

            switch (dtp)
            {
                case 0: return "null";
                case 0x1: return "int";
                case 0x2: return "double";
                case 0x3: return "string";
                case 0x4: return "datetime";
                case 0x5: return "geometry";
                case 0x6: return "stream";
                case 0xff: return "struct";
                default: return "string";
            }
        }
    }
}
