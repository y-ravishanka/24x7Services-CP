using Services1.Shared;

namespace Services1.Server.Services
{
    internal interface IDatabase
    {
        bool CheckDatabase();

        #region User Login Section
        bool CheckUser(string email);
        UsersData GetLogin(string email);
        bool InsertUser(UsersData user);
        #endregion

        #region User About Section
        UserAboutData GetUserAbout(int id);
        #endregion

        #region User Contact Section
        List<UserContactData> GetUserContact(int id);
        bool InsertNumber(UserContactData user);
        #endregion

        #region User Location Section
        UserLocationData GetUserLocation(int id);
        bool InsertUserLocation(UserLocationData us);
        bool UpdateUserLocation(UserLocationData us);
        #endregion

        #region User Education Section
        List<UserEducation> GetUserEducationsAll(int id);
        UserEducation GetUserEducation(int no);
        bool UpdateUserEducation(UserEducation us);
        bool DeleteUserEducation(int no);
        #endregion

        #region User Qualification Section
        List<UserQualification> GetUserQualificationAll(int id);
        UserQualification GetUserQualification(int no);
        bool UpdateUserQualification(UserQualification us);
        bool DeleteUserQualification(int no);
        #endregion

        #region User Skill Section
        List<UserSkills> GetUserSkillAll(int id);
        UserSkills GetUserSkill(int no);
        bool UpdateUserSkill(UserSkills us);
        bool DeleteUserSkill(int no);
        #endregion

        #region Admin Login Section
        bool CheckAdmin(string email);
        UsersData GetAdminLogin(string email);
        bool InsertAdminLogin(UsersData admin);
        List<UsersData> GetInactiveAdmins();
        bool ActiveAdmin(int adminId);
        #endregion

        #region Admin Data Section
        AdminData GetAdminData(int id);
        bool InsertAdmin(AdminData admin);
        #endregion

        #region Report Section
        bool InsertReport(Reports rep);
        Reports GetReports_byId(int id);
        List<Reports> GetReports_byMark(int id, int value);
        bool UpdateReports(int id, int admin);
        #endregion

        string Test(int id);
    }
}
