using DerDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerDataBusiness
{
    public interface IAutoService
    {
        /// <summary>
        /// 衍生品测试
        /// </summary>
        /// <param name="derdataid"></param>
        /// <returns></returns>
        bool  DerDataCheck(string derdataid);
        /// <summary>
        /// 更新测试结果信息
        /// </summary>
        /// <param name="derdataid"></param>
        /// <param name="testresult"></param>
        /// <returns></returns>
        bool UpdateDerDataStatus(string derdataid, bool testresult);
        /// <summary>
        /// 衍生品封装为数据服务
        /// </summary>
        /// <param name="derdataid"></param>
        /// <returns></returns>
        bool DerDataToDBService(string derdataid);
        /// <summary>
        /// 获取数据服务
        /// </summary>
        /// <returns></returns>
        List<DBSInfo> GetDBSInfo();
        /// <summary>
        /// 衍生品自动编目
        /// </summary>
        /// <param name="dbsid"></param>
        /// <returns></returns>
        bool ServiceAutoCatalog(string dbsid, string serviceType="DBSInfo");


        List<DBSInfo> GetUnPublishService();
        /// <summary>
        /// 服务自动发布
        /// </summary>
        /// <param name="dbsid"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        bool ServiceAutoPublish(string dbsid,string uid, string serviceType = "DBSInfo");
        /// <summary>
        /// 服务自动授权
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        bool ServiceAutoPrivi(string uid, string sourceId, string serviceType);

    }
}
