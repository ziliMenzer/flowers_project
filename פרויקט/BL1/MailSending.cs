using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Threading;
using DAL1;
namespace BL1
{
    public class MailSending
    {
        public static CancellationTokenSource m_ctSource;
        //send an email to the user
        public static void Send(string toEmail, string subject, string message)
        {
            string your_id = "michal100zili@gmail.com"; //חשבון ג'ימייל
            string your_password = "michal&zili100";//סיסמה
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(your_id, your_password)
                };
                //MailMessage mail = new MailMessage
                //{
                //    From = new MailAddress("michal100zili@gmail.com")//כתובת המייל ממנה נשלח המייל
                //};

                //mail.To.Add(UserDAL.GetMail(id));//- כתובת המייל אליה שולחים את המייל
                //mail.To.Add("zilimenzer@gmail.com");
                //mail.Subject = "תזכורת מהגינה שלך"; //- נושא המייל
                //mail.IsBodyHtml = true;
                //mail.Body = "<h1>הפרח שלך זקוק לך!<h1><p>הגיע הזמן להשקות את הפרח שלך.<p>"; //- html-תוכן המייל. ניתן לבנות כ
                MailMessage mm = new MailMessage(your_id, toEmail, subject, message)
                {
                    From = new MailAddress("michal100zili@gmail.com")//תובת המייל ממנה נשלח המייל   
                };
                //mm.To.Add(toEmail);
                ////mail.To.Add(UserDAL.GetMail(id));//- כתובת המייל אליה שולחים את המייל
                //mm.Subject = subject;
                //mm.IsBodyHtml = true;
                ////mm.Body ="<h1>"+"שלום"+" "+toEmail+"</h1>"+"<p>"+message+"</p>";
   
                client.Send(mm);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //schedule when to send the email
        public static void RunDaily(DateTime date)
        {
            m_ctSource = new CancellationTokenSource();

            var dateNow = DateTime.Now;

            TimeSpan ts;//אובייקט שמייצג את מרווח הזמן שנותר עד להפעלת התהליך

            if (date > dateNow)

                ts = date - dateNow;

            else//אם התאריך המבוקש עבר כבר-מקדם אותו למועד הבא

            {
                date = date.AddDays(1);//במקרה שלנו- קידום התאריך ביום(יכול להיות גם הוספת דקות/שעות)

                ts = date - dateNow;
            }
            //שימתין את פרק הזמן שנקבע, ואח"כ יקרא לפונקציה שרצינו שתופעל פעם ב... threadהפעלת ה
            Task.Delay(ts).ContinueWith((x) =>

            {
                ActivateGetLaters(DateTime.Now.AddDays(1));//קריאה לפונקציה המבוקשת

                        RunDaily(date);//קריאה חוזרת לפונקציה...

                    }, m_ctSource.Token);
        }
        //enables sending the email 
        public static bool ActivateGetLaters(DateTime dateTime)
        {
            if (dateTime == DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }

}

