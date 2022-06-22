using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL1;
using DTO1;

namespace BL1
{
  public  class FlowerBl
    {
         static int id;
        //update the pot size of a flower
        public static void UpdateFlower(FlowerInGardenDTO f) {
            FlowerInGardenDAL.UpdateFlowerInGarden(FlowerInGardenDTO.ToflowerInGarden(f));
        }
        public static List<FlowersDTO> GetAllFlowers()
        {
            var flowerList = FlowerDAL.GetAllFlowers().ToList();
            if (flowerList != null)
            {
                var flowerListDTO = DTO1.FlowersDTO.ToListFlowerDTO(flowerList);
                return flowerListDTO;
            }
            return null;
        
    }       
       

        public static int CalcWateringId(int soilType)
        {          
            if (soilType == 1)
                id = 1;
           else if (soilType == 2)
                id = 2;
            else
                id = 3;
            return id;
        }
    }
}
