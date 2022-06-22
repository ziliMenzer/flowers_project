using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL1
{
    public class FlowerInGardenDAL
    {
        public static int GetMaxDays(FlowerInGarden f)
        {
            int maxDays;
            using (FlowerProjectEntities db = new FlowerProjectEntities())
            {
                FlowerInGarden f1 = db.FlowerInGarden.FirstOrDefault(x => x.flowerInGardenId == f.flowerInGardenId);
                try
                {
                    maxDays = (int)f1.Watering.maxDays;
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }             
            }
            return maxDays;
        }
        public static void UpdateFlowerInGarden(FlowerInGarden f)
        {
            using (FlowerProjectEntities db = new FlowerProjectEntities())
            {
                try
                {
                    var f2 = db.FlowerInGarden.FirstOrDefault(f1 => f1.flowerInGardenId == f.flowerInGardenId);
                    if (f2 != null)
                    {
                        f2 = f;
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
