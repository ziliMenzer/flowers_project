using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL1
{


    public class UserDAL
    {
        
        public static Users GetUser(string mail, string password)//שליפת משתמש באמצעות סיסמא 
        {
            using (FlowerProjectEntities db = new FlowerProjectEntities())
            {
                try
                {
                    var u = db.Users.FirstOrDefault(u1 => u1.userMail == mail && u1.userPass == password);
                    if (u != null)
                        return u;
                    else
                        return null;

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public static Users AddUser(Users u)
        {
            using (FlowerProjectEntities db = new FlowerProjectEntities())
            {
                try
                {
                    if (u != null)
                    {
                        db.Users.Add(u);
                        db.SaveChanges();
                        return u;
                    }
                    else
                        return null;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }
        public static void DeleteUser(Users u)
        {
            using (FlowerProjectEntities db = new FlowerProjectEntities())
            {
                try
                {
                    db.Users.Remove(u);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }
        //בדיקה אם משתמש קיים לפי מייל וסיסמא 
        public static bool ChekUser(string mail,string pass)
        {
            using (FlowerProjectEntities db = new FlowerProjectEntities())
            {
                try
                {
                    var user = db.Users.FirstOrDefault(u => u.userMail == mail && u.userPass == pass);
                    if (user != null)
                        return true;
                    return false;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public static Users GetUserById(int id)
        {
            using (FlowerProjectEntities db = new FlowerProjectEntities())
            {
                try
                {
                    var user = db.Users.FirstOrDefault(u => u.userId == id);
                    if (user != null)
                        return user;
                    return null;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        //בדיקה אם משתמש קיים לפי מייל וסיסמה
        public static bool ChekUserByPassword(string Mail, string Password)
        {
            using (FlowerProjectEntities db = new FlowerProjectEntities())
            {
                try
                {
                    var user = db.Users.FirstOrDefault(u => u.userPass == Password && u.userMail == Mail);
                    if (user != null)
                        return true;
                    return false;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public static Users ChangePassword(string mail, string password)
        {
            using (FlowerProjectEntities db = new FlowerProjectEntities())
            {
                try
                {
                    Users res = db.Users.FirstOrDefault(user => user.userMail == mail);
                    if (res != null)
                    {
                        res.userPass = password;
                        db.SaveChanges(); 
                    }
                    return res;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public static Users GetUserByMail(string mail)
        {
            using (FlowerProjectEntities db = new FlowerProjectEntities())
            {
                try
                {
                    return db.Users.FirstOrDefault(u => u.userMail == mail);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public static List<string> GetAllUsersMail()
        {
            using (FlowerProjectEntities db = new FlowerProjectEntities())
            {
                try
                {
                    List<string> Users = db.Users.Select(u => u.userMail).ToList();
                    return Users;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public static void ChangeArea(int id, string newArea)
        {
            using (FlowerProjectEntities db = new FlowerProjectEntities())
            {
                try
                {
                    var u = db.Users.FirstOrDefault(u1 => u1.userId == id);
                    if (u != null)
                    {
                        if (u != null && newArea != null)
                            u.livingArea = newArea;
                            db.SaveChanges();

                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }

}

