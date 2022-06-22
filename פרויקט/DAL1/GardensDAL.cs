using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL1
{
    public class GardensDAL
    {
        
        public static Gardens AddGarden(Gardens g)//creates new garden
        {
            using (FlowerProjectEntities db = new FlowerProjectEntities())
            {
               
                if (g != null) { //אם הגינה לא ריקה 
                try
                {                    
                    db.Gardens.Add(g);
                    db.SaveChanges();
                        return g;
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }                    
                }
                else
                {
                    return null;
                }
            }
        }        
        public static List<FlowerInGarden> GetAllFlowersInGarden(int id)//return all the flowers in a garden
        {
            using (FlowerProjectEntities db = new FlowerProjectEntities())
            {
                try
                {
                    var g = db.Gardens.FirstOrDefault(f1 => f1.gardenId == id);
                    if (g != null&&g.FlowerInGarden!=null)
                        return g.FlowerInGarden.ToList();
                    else
                        return null;

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }       
        public static void DeleteFlowerFromGarden(FlowerInGarden f)//delete a flower from garden
        {
            using (FlowerProjectEntities db = new FlowerProjectEntities())
            {
                try
                {
                    var f1 = db.FlowerInGarden.FirstOrDefault(f2 => f2.flowerInGardenId == f.flowerInGardenId);
                    if (f1 != null)
                    {                       
                            db.FlowerInGarden.Remove(f1);
                            db.SaveChanges();
                    }                   
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }
        public static FlowerInGarden AddFlowerToGarden(FlowerInGarden f)//add flower to garden
        {
            using (FlowerProjectEntities db = new FlowerProjectEntities())
            {
                try
                {
                    var g = db.Gardens.FirstOrDefault(f1 => f1.gardenId == f.gardenId);
                    if (f != null)
                    {
                        db.FlowerInGarden.Add(f);
                        db.SaveChanges();
                        return f;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }
        public static void ChangeGardenDetails(Gardens g)//update garden
        {
            using (FlowerProjectEntities db = new FlowerProjectEntities())
            {                
                    try
                    {
                        var g1 = db.Gardens.FirstOrDefault(f1 => f1.gardenId == g.gardenId);
                        if (g1 != null)
                        {
                            g1 = g;
                            db.SaveChanges();
                        }
                    }
                                   
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public static void DeleteGarden(Gardens g)//delete garden
        {
            using(FlowerProjectEntities db = new FlowerProjectEntities())
            {
                try
                {

                    var g1 = db.Gardens.FirstOrDefault(f1 => f1.gardenId == g.gardenId);
                    if (g1 != null)
                    {
                    List <FlowerInGarden> lst = GetAllFlowersInGarden(g1.gardenId).ToList();
                    foreach(FlowerInGarden item in lst) {
                         var f = db.FlowerInGarden.FirstOrDefault(f1 => f1.flowerInGardenId == item.flowerInGardenId);
                        //FlowerInGarden f = lst[i];
                        db.FlowerInGarden.Remove(f);
                    }                              
                        db.Gardens.Remove(g1);
                        db.SaveChanges();
                        
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }
        public static Gardens CheckGarden(int id)
        {
            using (FlowerProjectEntities db = new FlowerProjectEntities())
            {
                var g = db.Gardens.FirstOrDefault(f1 => f1.userID == id);
                if (g != null)
                { //אם הגינה לא ריקה 
                    try
                    {
                        return g;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    
                }
                else
                {
                    return null;
                }
            }
        }//checks if user has a garden
    }
}
