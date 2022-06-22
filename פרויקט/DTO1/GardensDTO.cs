using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL1;
namespace DTO1
{
    public class GardensDTO 
    {
        public int GardenId  { get; set; }
    
        public int UserId { get; set; }
        public string Sun { get; set; }
        public string Position { get; set; } 


        public static GardensDTO ToGardensDTO(Gardens g)
        {
            GardensDTO g1 = new GardensDTO
            {
                GardenId = g.gardenId,
                UserId = (int)g.userID,
                Sun = g.sun,
                Position = g.position
            };
            return g1;
        }
        
        public static Gardens ToGardens(GardensDTO g)
        {
            
            Gardens g1 = new Gardens
            {
                gardenId = g.GardenId,           
                userID = (short)g.UserId,
                sun = g.Sun,
                position = g.Position
        };
            return g1;
        }
        
        public static List<GardensDTO> ToListGardensDTO(List<Gardens> l)
        {
            List<GardensDTO> l1 = new List<GardensDTO>();
            foreach (var item in l)
            {
                l1.Add(ToGardensDTO(item));
            }
            return l1;
        }
        public static List<Gardens> ToListGardens(List<GardensDTO> l)
        {
            List<Gardens> l1 = new List<Gardens>();
            foreach (var item in l)
            {
                l1.Add(ToGardens(item));
            }
            return l1;
        }
    }
}
