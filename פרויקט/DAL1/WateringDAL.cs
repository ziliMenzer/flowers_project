using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL1
{
    class WateringDAL
    {
        public static int GetWateringKind(int id)
        {
            using (FlowerProjectEntities db = new FlowerProjectEntities())
            {
                try
                {
                    var f = db.Watering.FirstOrDefault(f1 => f1.wateringId == id);
                    if (f != null)
                        return f.wateringId;
                    else
                        return 0;

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
