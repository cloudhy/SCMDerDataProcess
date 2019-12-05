using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Dapper;

namespace DerDataModel
{
    public interface IParamData
    {
        dynamic VData { get; set; }
        bool isRequired { get; }
    }

    [Table("PropertyInfo")]
    public class PropertyInfo
    {
        [Key]
        public string Id { get; set; }
        public string UID { get; set; }
        public string TbName { get; set; }
        public string Name { get; set; }
        public string OwnerCode { get; set; }
        public string OwnerName { get; set; }
        public string VindicatorCode { get; set; }
        public string VindicatorName { get; set; }
        public string Des { get; set; }
        public int IsAble { get; set; }
        public int OrderX { get; set; }
    }

    public class DbInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DBType { get; set; }
        public string Alias { get; set; }
        public string Version { get; set; }
        public string Source { get; set; }
        public string Des { get; set; }
        public string BZ { get; set; }
        public int IsAble { get; set; }
        public int OrderX { get; set; }
        public string ConnStr { get; set; }
    }

    [Table("DBSInfo")]
    public class DBSInfo
    {
        [Key]
        public string Id { get; set; }
        public string UID { get; set; }
        public string RouteTemplate { get; set; }
        public string Method { get; set; }
        public string SourceType { get; set; }
        public string SourceID { get; set; }
        public string KeyWords { get; set; }
        public string Abstract { get; set; }
        public string Des { get; set; }
        public int IsAble { get; set; }
        public int OrderX { get; set; }
    }
    [Table("DBSIParams")]
    public class DBSIParams : IParamData
    {
        [Key]
        public string Id { get; set; }
        public string DId { get; set; }
        public string PKey { get; set; }
        public string Name { get; set; }
        public int SN { get; set; }
        public int Dtp { get; set; }
        public string IsRequired { get; set; }
        public string Local { get; set; }
        public string Des { get; set; }
        public dynamic DefaultValue { get; set; }
        public string Unit { get; set; }
        public string BZ { get; set; }
        public int IsAble { get; set; }
        public int OrderX { get; set; }

        #region IParamData
        public bool isRequired
        {
            get
            {
                if (IsRequired == "1" || IsRequired.ToLower() == "true")
                {
                    return true;
                }
                return false;
            }
        }

        public dynamic VData { get; set; }
        #endregion

    }
    [Table("DBSOParams")]
    public class DBSOParams : IParamData
    {
        [Key]
        public string Id { get; set; }
        public string DId { get; set; }
        public string PKey { get; set; }
        public string Name { get; set; }
        public int SN { get; set; }
        public int Dtp { get; set; }
        public string IsRequired { get; set; }
        public string Local { get; set; }
        public string Des { get; set; }
        public dynamic DefaultValue { get; set; }
        public string Unit { get; set; }
        public string BZ { get; set; }
        public int IsAble { get; set; }
        public int OrderX { get; set; }
        #region IParamData
        public bool isRequired
        {
            get
            {
                if (IsRequired == "1" || IsRequired.ToLower() == "true")
                {
                    return true;
                }
                return false;
            }
        }

        public dynamic VData { get; set; }
        #endregion
    }

    public class DSStateInfo
    {
        public string Id { get; set; }
        public string DId { get; set; }
        public int OrderID { get; set; }
        public string ChangeType { get; set; }
        public DateTime ChangeTime { get; set; }
        public string ChangeSource { get; set; }
        public string ChangedDep { get; set; }
        public string ChangedContent { get; set; }
        public string ChangedFunc { get; set; }
        public string ChangedExtent { get; set; }
        public string ChangedPerson { get; set; }
        public DateTime CheckedTime { get; set; }
        public string CheckedPerson { get; set; }
        public string CheckedRecord { get; set; }
        public int IsAble { get; set; }
        public int OrderX { get; set; }
    }

    public class DerDataInfo
    {


        #region Table Fields
        public string Id { get; set; }
        public string DBId { get; set; }
        public string Name { get; set; }
        public string AccessType { get; set; }
        public string AccessKey { get; set; }
        public string Des { get; set; }
        public int IsAble { get; set; }
        public int OrderX { get; set; }
        #endregion

    }

    public class DerDataIParams : IParamData
    {
        public string Id { get; set; }
        public string DId { get; set; }
        public string PKey { get; set; }
        public string Name { get; set; }
        public int SN { get; set; }
        public int Dtp { get; set; }
        public string IsRequired { get; set; }
        public string Local { get; set; }
        public string Unit { get; set; }
        public dynamic DefaultValue { get; set; }
        public string Des { get; set; }
        public string BZ { get; set; }
        public int IsAble { get; set; }
        public int OrderX { get; set; }
        #region IParamData
        public bool isRequired
        {
            get
            {
                if (IsRequired == "1" || IsRequired.ToLower() == "true")
                {
                    return true;
                }
                return false;
            }
        }

        public dynamic VData { get; set; }
        #endregion

    }

    public class DerDataOParams : IParamData
    {
        public string Id { get; set; }
        public string DId { get; set; }
        public string PKey { get; set; }
        public string Name { get; set; }
        public int SN { get; set; }
        public int Dtp { get; set; }
        public string IsRequired { get; set; }
        public string Local { get; set; }
        public string Unit { get; set; }
        public dynamic DefaultValue { get; set; }
        public string Des { get; set; }
        public string BZ { get; set; }
        public int IsAble { get; set; }
        public int OrderX { get; set; }
        #region IParamData
        public bool isRequired
        {
            get
            {
                if (IsRequired == "1" || IsRequired.ToLower() == "true")
                {
                    return true;
                }
                return false;
            }
        }

        public dynamic VData { get; set; }
        #endregion
    }

    [Table("ServiceCatalog")]
    public class ServiceCatalog 
    {
        #region 获取/设置 字段值
        /// <summary>
        /// Id
        /// </summary>	
        [Key]
        public string Id { get; set; }
        /// <summary>
        /// ServiceId
        /// </summary>		
        public string ServiceId { get; set; }
        /// <summary>
        /// ServiceType
        /// </summary>		
        public string ServiceType { get; set; }
        /// <summary>
        /// ClassifyId
        /// </summary>		
        public string ClassifyId { get; set; }
        /// <summary>
        /// CatalogId
        /// </summary>		
        public string CatalogId { get; set; }
        /// <summary>
        /// BZ
        /// </summary>		
        public string BZ { get; set; }
      
        #endregion
       
    }

    [Table("ServiceReleaseInfo")]
    public class ServiceReleaseInfo 
    {
        #region 获取/设置 字段值
        /// <summary>
        /// Id
        /// </summary>	
        [Key]
        public string Id { get; set; }
        /// <summary>
        /// ServiceType
        /// </summary>		
        public string ServiceType { get; set; }
        /// <summary>
        /// SourceId
        /// </summary>		
        public string SourceId { get; set; }
        /// <summary>
        /// ReleaseTime
        /// </summary>		
        public DateTime? ReleaseTime { get; set; }
        /// <summary>
        /// RunState
        /// </summary>		
        public int? RunState { get; set; }
        /// <summary>
        /// ReleaseState
        /// </summary>		
        public int? ReleaseState { get; set; }
        /// <summary>
        /// IsPublic
        /// </summary>		
        public int? IsPublic { get; set; }
        /// <summary>
        /// IsAvailable
        /// </summary>		
        public int? IsAble { get; set; }
        /// <summary>
        /// BZ
        /// </summary>		
        public string BZ { get; set; }
       
        public int? OrderX { get; set; }
        /// <summary>
        /// UID
        /// </summary>		
        public string UID { get; set; }
        /// <summary>
        /// 是否需要更新
        /// </summary>
        public int? IsUpdate { get; set; }
        #endregion

       
    }


    /// <summary>
    /// 数据类型-枚举
    /// </summary>
    public enum ParamDTP
    {
        [Description("NULL")]
        t_null = 0,

        [Description("INT")]
        t_int = 0X1,

        [Description("DOUBLE")]
        t_double = 0X2,

        [Description("STRING")]
        t_text = 0X3,

        [Description("DATETIME")]
        t_datetime = 0X4,

        [Description("GEOMETRY")]
        t_geometry = 0X5,

        [Description("STREAM")]
        t_stream = 0x6,

        [Description("STRUCT")]
        t_struct = 0xff
    }
}
