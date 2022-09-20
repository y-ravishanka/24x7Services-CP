using Microsoft.Data.SqlClient;
using Services1.Shared;

namespace Services1.Server.Services
{
    internal class Database : IDatabase
    {
        private readonly SqlConnection con = new(@"Data Source=DESKTOP-1G3ODQ5;Initial Catalog=services1;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        private readonly string pw = "hduwlnj231ndwlwn42du3";
        private string? que = null;
        private int i = 0, j = 0;

        bool IDatabase.CheckDatabase()
        {
            bool test = false;
            que = "select 1";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    test = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                test = false;
            }
            finally
            { con.Close(); }
            GC.Collect();
            return test;
        }

        #region User Login Section
        UsersData IDatabase.GetLogin(string email)
        {
            UsersData log = new();
            que = "select id,email,password from users where nic = '" + email + "'";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        log.id = dr.GetInt32(0);
                        log.email = dr.GetString(1);
                        log.password = dr.GetString(2);
                    }

                }
                dr.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return log;
        }

        bool IDatabase.CheckUser(string email)
        {
            bool t = false;
            int tmp = 0;
            que = "select count(id) from users where email = '" + email + "'";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        tmp = dr.GetInt32(0);
                    }

                }
                dr.Close();
                if (tmp == 0)
                { t = false; }
                else
                { t = true; }
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }

        bool IDatabase.InsertUser(UsersData user)
        {
            bool test = false;
            que = "insert into users (email,password) values('" + user.email + "','" + user.password + "')";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                test = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                test = false;
            }
            finally
            { con.Close(); }
            GC.Collect();
            return test;
        }
        #endregion

        #region User Data Section
        UserAboutData IDatabase.GetUserAbout(int id)
        {
            UserAboutData log = new();
            que = "select id,nic,fname,lname,dname,gender,bio from user_about where id = '" + id + "'";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        log.id = dr.GetInt32(0);
                        log.nic = dr.GetString(1);
                        log.fname = dr.GetString(2);
                        log.lname = dr.GetString(3);
                        log.dname = dr.GetString(4);
                        log.gender = dr.GetString(5);
                        log.bio = dr.GetString(6);
                    }

                }
                dr.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return log;
        }

        List<UserContactData> IDatabase.GetUserContact(int id)
        {
            List<UserContactData> log = new();
            UserContactData cont;
            que = "select id,number from user_contact where id = '" + id + "'";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cont = new UserContactData
                        {
                            id = dr.GetInt32(0),
                            number = dr.GetString(1)
                        };
                        log.Add(cont);
                    }

                }
                dr.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return log;
        }

        bool IDatabase.InsertNumber(UserContactData user)
        {
            bool test = false;
            que = "insert into user_contact (id,number) values(" + user.id + ",'" + user.number + "')";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                test = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                test = false;
            }
            finally
            { con.Close(); }
            GC.Collect();
            return test;
        }
        #endregion

        #region Admin Login Section
        bool IDatabase.CheckAdmin(string email)
        {
            bool t = false;
            int tmp = 0;
            que = "select count(id) from admins where email = '" + email + "' and active = 1";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        tmp = dr.GetInt32(0);
                    }

                }
                dr.Close();
                if (tmp == 0)
                { t = false; }
                else
                { t = true; }
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }

        UsersData IDatabase.GetAdminLogin(string email)
        {
            UsersData log = new();
            que = "select id,email,password from admins where email = '" + email + "' and active = 1";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        log.id = dr.GetInt32(0);
                        log.email = dr.GetString(1);
                        log.password = dr.GetString(2);
                    }

                }
                dr.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return log;
        }

        List<UsersData> IDatabase.GetInactiveAdmins()
        {
            List<UsersData> list = new();
            UsersData log;
            que = "select id,email from admins where active = 0";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        log = new UsersData
                        {
                            id = dr.GetInt32(0),
                            email = dr.GetString(1)
                        };
                        list.Add(log);
                    }

                }
                dr.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return list;
        }

        bool IDatabase.InsertAdminLogin(UsersData admin)
        {
            bool test = false;
            que = "insert into admins (email,password) values('" + admin.email + "','" + admin.password + "')";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                test = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                test = false;
            }
            finally
            { con.Close(); }
            GC.Collect();
            return test;
        }

        bool IDatabase.ActiveAdmin(int adminId)
        {
            bool test = false;
            que = "update admins set active = 1 where id = " + adminId;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                test = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                test = false;
            }
            finally
            { con.Close(); }
            GC.Collect();
            return test;
        }
        #endregion

        #region Admin Data Section
        AdminData IDatabase.GetAdminData(int id)
        {
            AdminData log = new();
            que = "select id,name,nic,gender,address,contact1,contact2 from admin_data where id = '" + id + "'";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        log.id = dr.GetInt32(0);
                        log.name = dr.GetString(1);
                        log.nic = dr.GetString(2);
                        log.gender = dr.GetString(3);
                        log.address = dr.GetString(4);
                        log.contact1 = dr.GetString(5);
                        log.contact2 = dr.GetString(6);
                    }

                }
                dr.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return log;
        }

        bool IDatabase.InsertAdmin(AdminData admin)
        {
            bool test = false;
            que = "insert into admin_data (id,name,nic,gender,address,contact1,contact2) values(" + admin.id + "+'" + admin.name + "'+'" + admin.nic + "'+'" + admin.gender + "'+'" + admin.address + "'+'" + admin.contact1 + "'+'" + admin.contact2 + "')";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                test = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                test = false;
            }
            finally
            { con.Close(); }
            GC.Collect();
            return test;
        }
        #endregion

        string IDatabase.Test(int id)
        {
            string t = "";
            que = "select name from test where id = 1";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        t = dr[0].ToString();
                    }

                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            { con.Close(); }
            GC.Collect();
            return t;
        }

        #region Report Section
        bool IDatabase.InsertReport(Reports rep)
        {
            bool test = false;
            que = "insert into reports (title,message) values('" + rep.title + "','" + rep.message + "')";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                test = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                test = false;
            }
            finally
            { con.Close(); }
            GC.Collect();
            return test;
        }

        Reports IDatabase.GetReports_byId(int id)
        {
            Reports log = new();
            que = "select id,title,message,mark_read,read_admin from reports where id = " + id;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        log.id = dr.GetInt32(0);
                        log.title = dr.GetString(1);
                        log.message = dr.GetString(2);
                        log.read = dr.GetInt32(3);
                        log.admin = dr.GetInt32(4);
                    }

                }
                dr.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return log;
        }

        List<Reports> IDatabase.GetReports_byMark(int id, int value)
        {
            List<Reports> reports = new();
            Reports log;
            if (id == 0)
            {
                que = "select id,title,message,mark_read,read_admin from reports where mark_read = " + value;
            }
            else if (id == 1)
            {
                que = "select id,title,message,mark_read,read_admin from reports where read_admin = " + value;
            }
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        log = new Reports
                        {
                            id = dr.GetInt32(0),
                            title = dr.GetString(1),
                            message = dr.GetString(2),
                            read = dr.GetInt32(3),
                            admin = dr.GetInt32(4)
                        };
                        reports.Add(log);
                    }

                }
                dr.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return reports;
        }

        bool IDatabase.UpdateReports(int id, int admin)
        {
            bool test = false;
            que = "update reports set mark_read = " + 1 + " , read_admin = " + admin + " where id = " + id;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                test = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                test = false;
            }
            finally
            { con.Close(); }
            GC.Collect();
            return test;
        }
        #endregion

        UserLocationData IDatabase.GetUserLocation(int id)
        {
            UserLocationData log = new();
            que = "select id,address,province,district,town from user_location where id = " + id;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        log.id = dr.GetInt32(0);
                        log.address = dr.GetString(1);
                        log.province = dr.GetString(2);
                        log.district = dr.GetString(3);
                        log.town = dr.GetString(4);
                    }

                }
                dr.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return log;
        }

        bool IDatabase.InsertUserLocation(UserLocationData us)
        {
            bool test = false;
            que = "insert into user_location(id,address,province,district,town) values(" + us.id + ",'" + us.address + "','" + us.province + "','" + us.district + "','" + us.town + "')";
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                test = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                test = false;
            }
            finally
            { con.Close(); }
            GC.Collect();
            return test;
        }

        bool IDatabase.UpdateUserLocation(UserLocationData us)
        {
            bool test = false;
            que = "update user_location set address = '" + us.address + "', province = '" + us.province + "', district='" + us.district + "', town='" + us.town + "' where id = " + us.id;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                test = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                test = false;
            }
            finally
            { con.Close(); }
            GC.Collect();
            return test;
        }

        List<UserEducation> IDatabase.GetUserEducationsAll(int id)
        {
            List<UserEducation> test = new();
            UserEducation log = new();
            que = "select no,id,title,institute,deuration from user_education where id = " + id;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        log = new UserEducation
                        {
                            no = dr.GetInt32(0),
                            id = dr.GetInt32(1),
                            title = dr.GetString(2),
                            inst = dr.GetString(3),
                            time = dr.GetString(4)
                        };
                    }

                }
                dr.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return test;
        }

        UserEducation IDatabase.GetUserEducation(int no)
        {
            UserEducation log = new();
            que = "select no,id,title,institute,deuration from user_education where no = " + no;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        log.no = dr.GetInt32(0);
                        log.id = dr.GetInt32(1);
                        log.title = dr.GetString(2);
                        log.inst = dr.GetString(3);
                        log.time = dr.GetString(4);
                    }

                }
                dr.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return log;
        }

        bool IDatabase.UpdateUserEducation(UserEducation us)
        {
            bool test = false;
            que = "update user_education set title = '" + us.title + "', institute = '" + us.inst + "', deuration = '" + us.time + "' where no = " + us.no;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                test = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                test = false;
            }
            finally
            { con.Close(); }
            GC.Collect();
            return test;
        }

        bool IDatabase.DeleteUserEducation(int no)
        {
            bool test = false;
            que = "delete from user_education where no = " + no;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                test = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                test = false;
            }
            finally
            { con.Close(); }
            GC.Collect();
            return test;
        }

        List<UserQualification> IDatabase.GetUserQualificationAll(int id)
        {
            List<UserQualification> list = new();
            UserQualification log = new();
            que = "select no,id,title,place,details from user_qualification where id = " + id;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        log = new UserQualification
                        {
                            no = dr.GetInt32(0),
                            id = dr.GetInt32(1),
                            title = dr.GetString(2),
                            place = dr.GetString(3),
                            details = dr.GetString(4)
                        };
                        list.Add(log);
                    }

                }
                dr.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return list;
        }

        UserQualification IDatabase.GetUserQualification(int no)
        {
            UserQualification log = new();
            que = "select no,id,title,place,details from user_qualification where no = " + no;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        log.no = dr.GetInt32(0);
                        log.id = dr.GetInt32(1);
                        log.title = dr.GetString(2);
                        log.place = dr.GetString(3);
                        log.details = dr.GetString(4);
                    }

                }
                dr.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return log;
        }

        bool IDatabase.UpdateUserQualification(UserQualification us)
        {
            bool test = false;
            que = "update user_qualification set title = '" + us.title + "', place = '" + us.place + "', details = '" + us.details + "' where no = " + us.no;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                test = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                test = false;
            }
            finally
            { con.Close(); }
            GC.Collect();
            return test;
        }

        bool IDatabase.DeleteUserQualification(int no)
        {
            bool test = false;
            que = "delete from user_qualification where no = " + no;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                test = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                test = false;
            }
            finally
            { con.Close(); }
            GC.Collect();
            return test;
        }

        List<UserSkills> IDatabase.GetUserSkillAll(int id)
        {
            List<UserSkills> list = new();
            UserSkills log = new();
            que = "select no,id,name from user_skills where id = " + id;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        log = new UserSkills
                        {
                            no = dr.GetInt32(0),
                            id = dr.GetInt32(1),
                            name = dr.GetString(2)
                        };
                        list.Add(log);
                    }

                }
                dr.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return list;
        }

        UserSkills IDatabase.GetUserSkill(int no)
        {
            UserSkills log = new();
            que = "select no,id,name from user_skills where no = " + no;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        log.no = dr.GetInt32(0);
                        log.id = dr.GetInt32(1);
                        log.name = dr.GetString(2);
                    }

                }
                dr.Close();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { con.Close(); }
            GC.Collect();
            return log;
        }

        bool IDatabase.UpdateUserSkill(UserSkills us)
        {
            bool test = false;
            que = "update user_skills set name = '" + us.name + "' where no = " + us.no;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                test = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                test = false;
            }
            finally
            { con.Close(); }
            GC.Collect();
            return test;
        }

        bool IDatabase.DeleteUserSkill(int no)
        {
            bool test = false;
            que = "delete from user_skills where no = " + no;
            SqlCommand cmd = new(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                test = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                test = false;
            }
            finally
            { con.Close(); }
            GC.Collect();
            return test;
        }

    }
}
