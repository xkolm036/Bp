using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Model
{
    class User
    {
        public int userID { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public Role role { get; set; }

        /// <summary>
        /// podle username vrati uzivatele a jeho roli
        /// </summary>
        public static User vyberZDb(string username)
        {
            User user = new User();
            using (UsersEntities User_table = new UsersEntities())
            {


                try
                {

                    Users DB_User = new Users();
                    DB_User = User_table.Users.FirstOrDefault(u => u.UserName == username); //vybere uzivatele z db

                    user.name = DB_User.UserName;
                    user.password = DB_User.UserPassword;


                    Role r = new Role();
                    r.RoleId = DB_User.Role.RoleId;
                    r.RoleDescription = DB_User.Role.RoleDescription;
                    r.RoleName = DB_User.Role.RoleName;
                    user.role = r;

                }
                catch
                {
                    return null;
                }
            }
            return user;
        }


    }
}
