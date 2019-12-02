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
        bool DerDataCheck(string derdataid);
        /// <summary>
        /// 衍生品封装为数据服务
        /// </summary>
        /// <param name="derdataid"></param>
        /// <returns></returns>
        bool DerDataToDBService(string derdataid);
        /// <summary>
        /// 衍生品自动编目
        /// </summary>
        /// <param name="dbsid"></param>
        /// <returns></returns>
        bool ServiceAutoCatalog(string dbsid);
        /// <summary>
        /// 衍生品自动发布
        /// </summary>
        /// <param name="dbsid"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        bool ServiceAutoPublish(string dbsid,string uid);
        /// <summary>
        /// 衍生品自动授权
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        bool ServiceAutoPrivi(string uid);

    }
}
