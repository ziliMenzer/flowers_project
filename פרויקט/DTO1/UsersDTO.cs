using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL1;
namespace DTO1
{
    public class UsersDTO
    {
        public int UserId { get; set; } 
        public string UserPass { get; set; }
        public string UserMail { get; set; }
        public string LivingArea { get; set; }
        

        public static UsersDTO ToUserDTO(Users u)
        {
            UsersDTO u1 = new UsersDTO
            {
                UserId = u.userId,                
                UserPass = u.userPass,
                UserMail = u.userMail,
                LivingArea = u.livingArea,
               
            };
            return u1;
        }
        public static Users ToUsers(UsersDTO u)
        {
            Users u1 = new Users
            {
                userId = (short)u.UserId,              
                userPass = u.UserPass,
                userMail = u.UserMail,
                livingArea = u.LivingArea,
               
            };
            return u1;
        }
        public static List<UsersDTO> ToListUsersDTO(List<Users> l)
        {
            List<UsersDTO> l1 = new List<UsersDTO>();
            foreach (var item in l)
            {
                l1.Add(ToUserDTO(item));
            }
            return l1;
        }
        public static List<Users> ToListUsers(List<UsersDTO> l)
        {
            List<Users> l1 = new List<Users>();
            foreach (var item in l)
            {
                l1.Add(ToUsers(item));
            }
            return l1;
        }
    }
}
