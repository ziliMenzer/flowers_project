using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL1;
namespace DTO1
{
     public class FlowersDTO
    {
        public int FlowerId { get; set; }
        public string FlowerName { get; set; }
        public string Colour { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
       
        public static FlowersDTO ToflowerDTO(Flowers f)
        {
            FlowersDTO f1 = new FlowersDTO
            {
                FlowerId = f.flowerId,
                FlowerName = f.flowerName,
                Colour = f.colour,
                Description = f.description,
                Picture = f.picture
            };
            return f1;
        }
        public static Flowers Toflower(FlowersDTO f)
        {
            Flowers f1 = new Flowers
            {
                flowerId = (short)f.FlowerId,
                flowerName = f.FlowerName,
                colour = f.Colour,
                description = f.Description,
                picture = f.Picture
            };
            return f1;
        }
        public static List<FlowersDTO> ToListFlowerDTO(List<Flowers> l)
        {
            List<FlowersDTO> l1 = new List<FlowersDTO>();
            foreach(var item in l)
            {
                l1.Add(ToflowerDTO(item));
            }
            return l1;
        }
        public static List<Flowers> ToListFlower(List<FlowersDTO> l)
        {
            List<Flowers> l1 = new List<Flowers>();
            foreach (var item in l)
            {
                l1.Add(Toflower(item));
            }
            return l1;
        }
    }
}
