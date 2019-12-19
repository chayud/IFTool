using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace api.IFTool.Models
{
    public class AppSetting
    {
        public Logging Logging { get; set; }
        public Connectionstrings ConnectionStrings { get; set; }
        public Appsettings AppSettings { get; set; }
        public Connsettings ConnSettings { get; set; }
        public string AllowedHosts { get; set; }
    }

    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
    }

    public class Connectionstrings
    {
        public string DefaultConnection { get; set; }
    }

    public class Appsettings
    {
        public string VirtualDirectory { get; set; }
        public string IsProduction { get; set; }
        public string IsMailTo { get; set; }
        public string UseHeaderVerification { get; set; }
        public string APIKey { get; set; }
        public string APIHeader { get; set; }
        public string StorageID { get; set; }
        public string DirRoot { get; set; }
        public string ZipPath { get; set; }
    }

    public class Connsettings
    {
        public string conn { get; set; }
        public string connap { get; set; }
        public string endpoint_url { get; set; }
    }



    #region TransactionModel


    public class ProjectContructTypeModel
    {
        public int ConstructTypeID { get; set; }
        public string ConstructTypeName { get; set; }
        public HousemModelItem HouseModelItem { get; set; }
        public int HouseTypeID { get; set; }
        public string HouseTypeName { get; set; }
        public int? HouseModelID { get; set; }
        public string Id { get; set; }
        public int ProjectLayoutTypeID { get; set; }
        public string ProjectLayoutTypeName { get; set; }
        public int? Quantity { get; set; }
        public int? BuildingsQTY { get; set; }
        public int? FloorsQTY { get; set; }
        public int? ParkingQTY { get; set; }
        public string GFA { get; set; }
        public string GreenArea { get; set; }
    }

    public class HousemModelItem
    {
        public HouseModelExtent HouseModel { get; set; }
        public string Key { get; set; }
        public string Quantity { get; set; }
    }

    public partial class ParamUploadPlanImage
    {
        public string CreatorFullName { get; set; }

        public string CreateDeviceId { get; set; }

        public string Description { get; set; }

        //public List<ImageMappingData> ImageUnitMappingData { get; set; }

        public string ImageUnitMappingData { get; set; }

        public List<IFormFile> PlanImageFiles { get; set; }


    }

    public class ActionProject
    {
        public int? ProjectID { get; set; }
        public int? UserID { get; set; }
    }

    public class HouseModelExtent
    {
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string HouseModelCode { get; set; }
        public int? HouseModelID { get; set; }
        public string HouseModelName { get; set; }
        public bool? IsActive { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
    }


    public class ProjectUtilityModel
    {
        public string Key { get; set; }
        public int? UtilityPeriodID { get; set; }
        public string UtilityPeriodName { get; set; }
        public string WBS { get; set; }
        public string Remark { get; set; }
    }

    public class ProjectAttachFileAdHoc
    {
        public List<ProjectAttachFileModel> ProjectAttachFile { get; set; }
        public int RequestOpenProjectID { get; set; }
        public int UserID { get; set; }
        public ProjectAttachFileAdHoc()
        {
            ProjectAttachFile = new List<ProjectAttachFileModel>();
        }

    }

    public class ProjectAdjust
    {
        public List<int?> SEID { get; set; }  

        public string SubBGID { get; set; }
        public string ProjectName { get; set; }
        public int? SVPID { get; set; }
        public int? PMID { get; set; }
        public int RequestOpenProjectID { get; set; }
        public int UserID { get; set; }
        public ProjectAdjust()
        {
            SEID = new List<int?>();
        }

    }
    



    public class ResultModel
    {
        public string ID { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    #endregion

    #region ProjectAttachFileModel 


    public class ProjectAttachFileModel
    {
        public DateTime? CreateDate { get; set; }
        public string FileName { get; set; }
        public int? FileTypeID { get; set; }
        public string FileTypeName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsCreateFile { get; set; }
        public string Key { get; set; }
    }

    public class ProjectAttachFileContent
    {

    }

    public class UpdateStatusResult
    {
        public string MailType { get; set; }
        public string MailToUserID { get; set; }
        public bool? IsValid { get; set; }
        public string Message { get; set; }
    }
    #endregion

    #region FilterModel
    public class FilterRequestOpenProject
    {
        public int? ProjectID { get; set; }
        public string ProjectLayoutTypeID { get; set; }
        public string HouseTypeID { get; set; }
        public string ApproveStatusID { get; set; }
        public bool? IsActive { get; set; }
        public int? UserID { get; set; }
        public string DocDate { get; set; }
        public string Plant { get; set; }

        public string ProjectStatusID { get; set; }

    }
    #endregion

    #region MailModel
    public partial class Param_Mail
    {
        public DateTime? MailTime { get; set; }
        public string MailFrom { get; set; }
        public string MailTo { get; set; }
        public string MailCC { get; set; }
        public string Topic { get; set; }
        public string Detail { get; set; }
        public string MailType { get; set; }
        public string Key1 { get; set; }
        public string Key2 { get; set; }
        public string Key3 { get; set; }
        public string Key4 { get; set; }
        public string MailFromName { get; set; }
        public string MailBCC { get; set; }
        public string SendStatus { get; set; }
        public string Result { get; set; }
        public List<Param_Mail_AttachFile> AttachFiles { get; set; }
    }

    public partial class Param_Mail_AttachFile
    {
        public string FileName { get; set; }
        public long? FileSize { get; set; }
        public byte[] FileObject { get; set; }
    }
    #endregion

    #region LogModel

    public class LogModel
    {
        public string FieldName { get; set; }
        public string Data { get; set; }
        public string PrevData { get; set; }
        public DateTime? Time { get; set; }
        public string By { get; set; }
    }
    public class ProjectLogModel
    {
        public int? ProjectID { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string DocDate { get; set; }
        public string CostCenter { get; set; }
        public int? SubBGID { get; set; }
        public string SubBGName { get; set; }
        public string Plant { get; set; }
        public int? CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Status { get; set; }
        public int? ZoneID { get; set; }
        public string ZoneName { get; set; }
        public int? SubDistrictID { get; set; }
        public string SubDistrictName { get; set; }
        public string DistrictID { get; set; }
        public string DistrictName { get; set; }
        public int? ProvinceID { get; set; }
        public string ProvinceName { get; set; }
        public string PostCode { get; set; }
        public string Description { get; set; }
        public string AddressOther { get; set; }
        public int? ProjectLayoutTypeID { get; set; }
        public string LayoutType { get; set; }
        public string ProjectStatus { get; set; }
        public string Rai { get; set; }
        public string SquareWah { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string ModifyByName { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
    }

    public class RequestOpenProjectLogModel
    {
        public int? RequestOpenProjectID { get; set; }
        public int? ProjectID { get; set; }
        public string BMLName { get; set; }
        public string RemarkBM { get; set; }
        public string BMMName { get; set; }
        public string BSLName { get; set; }
        public string RemarkBS { get; set; }
        public string BSMName { get; set; }
        public string ISLName { get; set; }
        public string RemarkIS { get; set; }
        public string ISMName { get; set; }
        public string AdminLName { get; set; }
        public string RemarkAdmin { get; set; }
        public string SiteAdminMName { get; set; }
        public DateTime? TimeStart { get; set; }
        public DateTime? TimeEnd { get; set; }
        public string ResponsibleUserID { get; set; }
    }

    public class SessionModel
    {
        public string Session { get; set; }
    }
    #endregion

}
