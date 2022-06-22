using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL1;
using DTO1;
namespace BL1
{
    public class UserBL
    {
       
        //adds a new user to the database - register
            public static UsersDTO AddUser(UsersDTO u)
            {
                try
                {
                   UsersDTO u1 =UsersDTO.ToUserDTO(UserDAL.AddUser(UsersDTO.ToUsers(u)));
                return u1;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        //checks if the user exsist - login
            public static UsersDTO CheckUser(string mail,string pass)
        {
            if (UserDAL.ChekUser(mail, pass) == true) {
                //Users u = new Users();
                var u=UserDAL.GetUser(mail, pass);
                return UsersDTO.ToUserDTO(u);
            }
                
            return null;
        }
            //send a new password
            public static bool SendNewPassword(string Mail)
            {
                //בדיקה אם המשתמש קיים
                //if (UserDAL.ChekUser(Mail) == true)
                //{
                    Random r = new Random();
                    int password = r.Next(1000, 9999);
                    UserDAL.ChangePassword(Mail, password.ToString());
                    //שליחת סיסמא חדשה

                    string body = @"<html>
                    <body>
                    <p style='color: goldenrod; font-size:170%  '> !שלום וברכה </p>
                    <p style='color: darkblue; font-size:150%  '> הסיסמה החדשה היא: " + Convert.ToString(password) + @"</p>
                    </body>";

                    MailSending.Send(Mail, "סיסמה חדשה", body);
                    return true;
                //}
                //return false;
            }
        //send an alert to water your flower
           public static void SendAlert(string flowerName,double amount,string mail)
           {
            string body = @"<html>
                    <body>
                    <p style='color: goldenrod; font-size:170%  '> !שלום וברכה </p>
                    <p style='color: darkblue; font-size:150%  '> הגיע הזמן להשקות את: " + flowerName + "הכמות להשקית הפרח היא:"+ Convert.ToString(amount)+@"</p>
                    </body>";
            MailSending.Send(mail, "תזכורת להשקית פרח", body);
        }
            //changes the password
            public static void ChangePassword(string mail, string password)
            {
                UserDAL.ChangePassword(mail, password);
            }

            //returns the user by mail
            public static UsersDTO GetUserByMail(string mail)
            {
                return UsersDTO.ToUserDTO(UserDAL.GetUserByMail(mail));
            }
        //returns list of all the users' mails
            public static List<string> GetAllUsersMail()
            {
                return UserDAL.GetAllUsersMail();
            }
        //updates the living area of the user
            public static void UpdateUser(int id,string livingArea) {
            try
            {
                UserDAL.ChangeArea(id, livingArea);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        }
    }


