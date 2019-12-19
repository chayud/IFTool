using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.IFTool.Models
{

    public class Department
    {
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string DivisionCode { get; set; }
        public string DivisionName { get; set; }
    }


    public class UserRole
    {
        public int id { get; set; }
        public int userID { get; set; }
        public string userGUID { get; set; }
        public string userName { get; set; }
        public string empCode { get; set; }
        public string titleName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string positionName { get; set; }
        public int roleID { get; set; }
        public string roleCode { get; set; }
        public string roleName { get; set; }
        public string assignType { get; set; }
        public string sourceType { get; set; }
        public string remark { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string phoneExt { get; set; }
        public string mobile { get; set; }
        public string mobile1 { get; set; }
    }




    public class Response
    {
        public bool success { get; set; }
        public User[] data { get; set; }
        public string message { get; set; }
    }

    public class EmployeeResponse
    {
        public bool success { get; set; }
        public EmployeeDetail[] data { get; set; }
        public string message { get; set; }
    }


    public class EmployeeDetail
    {
        public int userID { get; set; }
        public string userGUID { get; set; }
        public string userName { get; set; }
        public string empID { get; set; }
        public string empCode { get; set; }
        public string titleName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string position { get; set; }
        public string devision { get; set; }
        public string department { get; set; }
        public int? appCount { get; set; }
        public int? roleCount { get; set; }
        public int? projectCount { get; set; }
        public int? leaderID { get; set; }
        public string leaderName { get; set; }
        public int? positionID { get; set; }
        public int? departmentID { get; set; }
        public int? divisionID { get; set; }
        public object companyID { get; set; }
        public string titleEN { get; set; }
        public string nameEN { get; set; }
        public string lastNameEN { get; set; }
        public string nameTH { get; set; }
        public string titleTH { get; set; }
        public string lastNameTH { get; set; }
        public string nickName { get; set; }
        public DateTime? birthDate { get; set; }
        public string empSex { get; set; }
        public DateTime? hiringDate { get; set; }
        public object resignDate { get; set; }
        public object companyEN { get; set; }
        public object companyTH { get; set; }
        public object group_Div { get; set; }
        public string branch { get; set; }
        public string section { get; set; }
        public string unit { get; set; }
        public object project { get; set; }
        public string expr1 { get; set; }
        public string phoneExt { get; set; }
        public string status { get; set; }
        public string costCenter { get; set; }
        public string mobile { get; set; }
        public string mobile1 { get; set; }
        public string divisionCode { get; set; }
        public string departmentCode { get; set; }
        public string sectionCode { get; set; }
        public string unitCode { get; set; }
        public object companyCode { get; set; }
        public string leaderCode { get; set; }
        public string positionCode { get; set; }
    }


    public class User
    {
        public string departmentName { get; set; }
        public string empID { get; set; }
        public string titleEN { get; set; }
        public string nameEN { get; set; }
        public string lastNameEN { get; set; }
        public string titleTH { get; set; }
        public string nameTH { get; set; }
        public string lastNameTH { get; set; }
        public string nickName { get; set; }
        public DateTime birthDate { get; set; }
        public string empSex { get; set; }
        public string positionKey { get; set; }
        public string positionCode { get; set; }
        public DateTime hiringDate { get; set; }
        public DateTime? resignDate { get; set; }
        public string companyCode { get; set; }
        public string branch { get; set; }
        public string divisionCode { get; set; }
        public string departmentCode { get; set; }
        public string sectionCode { get; set; }
        public string unitCode { get; set; }
        public string project { get; set; }
        public string email { get; set; }
        public string phoneExt { get; set; }
        public string status { get; set; }
        public string mobile { get; set; }
        public string workFloor { get; set; }
        public string costCenter { get; set; }
        public string leaderName { get; set; }
        public string mobileOther { get; set; }
        public object mobile1 { get; set; }
    }


    public class EmployeeModel
    {
        public string TitleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string EmployeeID { get; set; }
        public string Email { get; set; }
        public object PositionCode { get; set; }
        public object PositionName { get; set; }
        public object DivisionCode { get; set; }
        public object DivisionName { get; set; }
        public object DepartmentCode { get; set; }
        public object DepartmentName { get; set; }
        public object SectionCode { get; set; }
        public object SectionName { get; set; }
        public object UnitCode { get; set; }
        public object UnitName { get; set; }
        public object CompanyCode { get; set; }
        public object CompanyName { get; set; }
        public string LeaderCode { get; set; }
        public object LeaderName { get; set; }
        public object CostCenter { get; set; }
        public object Status { get; set; }
    }


    public class CompanyModel
    {
        public int CompanyID { get; set; }
        public string CompanyCode { get; set; }
        public object CompanyShortCode { get; set; }
        public string CompanySAPCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyNameEng { get; set; }
        public string TaxID { get; set; }
        public string AddressThai { get; set; }
        public string BuildingThai { get; set; }
        public string SoiThai { get; set; }
        public string RoadThai { get; set; }
        public string SubDistrictThai { get; set; }
        public string DistrictThai { get; set; }
        public string ProvinceThai { get; set; }
        public string AddressEng { get; set; }
        public string BuildingEng { get; set; }
        public string SoiEng { get; set; }
        public string RoadEng { get; set; }
        public string SubDistrictEng { get; set; }
        public string DistrictEng { get; set; }
        public string ProvinceEng { get; set; }
        public string PostCode { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string FullAddressThai { get; set; }
        public string FullAddressEng { get; set; }
        public string RefCode { get; set; }
        public object IsActive { get; set; }
    }


    public class UserRoleModel
    {
        public string UserId { get; set; }
        public Role[] Roles { get; set; }
    }

    public class Role
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string UserGUID { get; set; }
        public string UserName { get; set; }
        public string EmpCode { get; set; }
        public string TitleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PositionName { get; set; }
        public int RoleID { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public string AssignType { get; set; }
        public string SourceType { get; set; }
        public string Remark { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }


    public class AuthenModel
    {
        public bool loginResult { get; set; }
        public string loginResultMessage { get; set; }
        public string userPrincipalName { get; set; }
        public string domainUserName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string displayName { get; set; }
        public string employeeID { get; set; }
        public string email { get; set; }
        public string division { get; set; }
        public DateTime accountExpirationDate { get; set; }
        public DateTime lastLogon { get; set; }
        public string authenticationProvider { get; set; }
        public string sysUserId { get; set; }
        public string sysUserData { get; set; }
        public string sysUserRoles { get; set; }
        public string sysAppCode { get; set; }
        public string userProject { get; set; }
        public string userApp { get; set; }
    }

}
