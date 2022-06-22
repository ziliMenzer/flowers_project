using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL1;
using DTO1;

namespace BL1
{
    public class GardensBL
    {
        //creates a new garden in the first tim the user saves a flower
        public static GardensDTO CreateNewGarden(GardensDTO g) {
            
           GardensDTO g1 =GardensDTO.ToGardensDTO(GardensDAL.AddGarden(GardensDTO.ToGardens(g)));
            return g1;
                       
        }
        //deletes the garden
        public static void DeleteGarden(GardensDTO g) {
            GardensDAL.DeleteGarden(GardensDTO.ToGardens(g));
        }
        //deletes a flower from the garden
        public static string DeleteFlowerFromGarden(FlowerInGardenDTO f)
        {
            try
            {
                GardensDAL.DeleteFlowerFromGarden(FlowerInGardenDTO.ToflowerInGarden(f));
                return "success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        //returns all the flowers in the garden
        public static List<FlowerInGardenDTO> GetAllUserFlowers(int id)
        {
            //if (GardensDAL.CheckGarden(id) != null)
            //{
            var flowerList = GardensDAL.GetAllFlowersInGarden(id).ToList();
                if (flowerList != null)
                {
                    var flowerListDTO = DTO1.FlowerInGardenDTO.ToListFlowerInGardenDTO(flowerList);
                    return flowerListDTO;
                }
           // }
            
            return null;
        }
        //adds a flower to the garden
        public static FlowerInGardenDTO AddFlowerToGarden(FlowerInGardenDTO f)
        {
           FlowerInGardenDTO f1 = FlowerInGardenDTO.ToflowerInGardenDTO( GardensDAL.AddFlowerToGarden(FlowerInGardenDTO.ToflowerInGarden(f)));
            return f1;
        }
        //update the garden data
        public static void UpdateGardenDetails(GardensDTO g)
        {
           GardensDAL.ChangeGardenDetails(GardensDTO.ToGardens(g));
        }
        
        public static GardensDTO CheckGarden(int id)
        {
            GardensDTO g = GardensDTO.ToGardensDTO(GardensDAL.CheckGarden(id));
            return g;
        }
    }
}
