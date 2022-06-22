using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL1;
namespace DTO1
{
    public class FlowerInGardenDTO
    {
        public int FlowerInGardenId { get; set; }
        //public int FlowerId { get; set; }
        public int GardenId { get; set; }
        public string PotType { get; set; }
        public int PotSize { get; set; }
        public int WateringId { get; set; }
        public string FlowerName { get; set; }
        public string Colour { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }


        public static FlowerInGardenDTO ToflowerInGardenDTO(FlowerInGarden f)
        {
            FlowerInGardenDTO f1 = new FlowerInGardenDTO
            {
                FlowerInGardenId = f.flowerInGardenId,                
                GardenId = (int)f.gardenId,
                PotType = f.potType,
                PotSize = (int)f.potSize,
                WateringId = (int)f.wateringId,
                FlowerName = f.flowerName,
                Colour = f.colour,
                Description = f.description,
                Picture = f.picture
            };

            return f1;
        }
        public static FlowerInGarden ToflowerInGarden(FlowerInGardenDTO f)
        {
            FlowerInGarden f1 = new FlowerInGarden
            {
                
                flowerInGardenId = f.FlowerInGardenId,                
                
                gardenId = (short)f.GardenId,
                potType = f.PotType,
                potSize = f.PotSize,
                wateringId = (short)f.WateringId,
                flowerName = f.FlowerName,
                colour = f.Colour,
                description = f.Description,
                picture = f.Picture
            };
            return f1;
        }
        public static List<FlowerInGardenDTO> ToListFlowerInGardenDTO(List<FlowerInGarden> l)
        {
            List<FlowerInGardenDTO> l1 = new List<FlowerInGardenDTO>();
            foreach (var item in l)
            {
                l1.Add(ToflowerInGardenDTO(item));
            }
            return l1;
        }
        public static List<FlowerInGarden> ToListFlowerInGarden(List<FlowerInGardenDTO> l)
        {
            List<FlowerInGarden> l1 = new List<FlowerInGarden>();
            foreach (var item in l)
            {
                l1.Add(ToflowerInGarden(item));
            }
            return l1;
        }
    }
}
