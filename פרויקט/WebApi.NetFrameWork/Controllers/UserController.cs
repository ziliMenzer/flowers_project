using BL1;
using DTO1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;

namespace WebApi.NetFrameWork.Controllers
{
    [RoutePrefix("api/user")]//שם כללי לקונטרולר
    [EnableCors(headers: "*", methods: "*", origins: "*")]
    public class UserController : ApiController
    {
        
        [HttpGet]
        [Route("checkUser")]
        public UsersDTO CheckUser(string mail,string pass)
            {
            UsersDTO u;
            u = UserBL.CheckUser(mail,pass);
            return u;
        }
        [HttpPost]
        [Route("addUser")]
        public UsersDTO AddUser([FromBody] UsersDTO user)
        {
            if (user == null)
            {

                return null;
            }
            UsersDTO u1 = UserBL.AddUser(user);
            return u1;
        }

        [HttpGet]
        [Route("sendMail")]
        public string SendMail(string mail)
        {
            try
            {               
                MailSending.Send(mail, "תזכורת על השקיית פרח", "הפרח שלך זקוק לך!\n.הגיע הזמן להשקות את הפרח שלך");
                return "success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpGet]
        [Route("sendPass")]
        public string ChangePass(string mail)
        {
            try
            {
                UserBL.SendNewPassword(mail);
                return "success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [HttpPut]
        [Route("updateUser")]
        public string UpdateUser(int id,string newArea)
        {
            try
            {
                UserBL.UpdateUser(id, newArea);
                return "success";
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
    }
}