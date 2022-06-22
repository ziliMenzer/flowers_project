using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL1
{
    public class FlowerDAL
    {      
        //public static List<string> GetAllFlowersNames()
        //{
        //    using (FlowerProjectEntities1 db = new FlowerProjectEntities1())
        //    {
        //        try
        //        {
        //            List<string> Flowers = db.Flowers.Select(f => f.flowerName).ToList();
        //            return Flowers;
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //    }
        //}
        public static List<Flowers> GetAllFlowers()//return all the flowers in the database
        {
            using (FlowerProjectEntities db = new FlowerProjectEntities())
            {
                try
                {
                    List<Flowers> Flowers = db.Flowers.ToList();
                    return Flowers;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        
        
    }
}

