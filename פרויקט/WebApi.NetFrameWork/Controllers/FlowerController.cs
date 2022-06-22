using BL1;
using DTO1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;

namespace WebApi.NetFrameWork.Controllers
{
    [RoutePrefix("api/flower")]//שם כללי לקונטרולר
    [EnableCors(headers: "*", methods: "*", origins: "*")]

    public class FlowerController : ApiController
    {

        [HttpPost]
        [Route("getFromAPI")]
        public IHttpActionResult GetFromAPI()
        {

            var httpReqest = HttpContext.Current.Request;
            // upload image
            var postedFile = httpReqest.Files["Image"];
           
           
            byte[] buffer = new byte[16 * 1024];
            byte[] g;

            using (MemoryStream ms = new  MemoryStream())
            {
                int read;
                while ((read = postedFile.InputStream.Read(buffer, 0,buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                //return ms.ToArray();
                g = ms.ToArray();
            }
            var t = HttpCalls.Newfunc("identify",Convert.ToBase64String(g));
            //var t = HttpCalls.newfunc("https://plant.id/identification/kblrpaR5gMQLIdo");
            return Ok(t);
        }

        [HttpGet]
        [Route("weatherForcast")]
        public async Task<IHttpActionResult> GetWeatherAsync(double lat, double lon)
        {
            //BL1.WeatherAPI.RootObject  myWeather = Task.Run(() => WeatherAPI.WeatherForecastAsync(lat, lon)).Result;
            WeatherAPI.RootObject myWeather = (await WeatherAPI.WeatherForecastAsync(lat, lon));
            return Ok(myWeather);
        }

        [HttpGet]
        [Route("getGardenFlowers")]
        public IEnumerable<FlowerInGardenDTO> GetAllFlowers(int id)
       {
            //if (GardensBL.CheckGarden(id) != null) {
                return GardensBL.GetAllUserFlowers(id).ToList();
           // }
            //else
            //{
            //    return null;
            //}
        }
        [HttpGet]
        [Route("checkIsGarden")]
        public GardensDTO CheckGarden(int userId)
        {
             return GardensBL.CheckGarden(userId);
        }
        
        
        [HttpPost]
        [Route("deletFlowerFromGarden")]
        public string DelFlowerFromGarden([FromBody] FlowerInGardenDTO flower)
        {
            
            if (flower == null)
            {

                return "wrong";
            }
            GardensBL.DeleteFlowerFromGarden(flower);
            return "good";
        }
        [HttpPost]
        [Route("addFlowerToGarden")]
        public FlowerInGardenDTO AddFlowerToGarden([FromBody] FlowerInGardenDTO flower)
        {
            if (flower == null)
            {
                return null;
            }
            FlowerInGardenDTO f1 = GardensBL.AddFlowerToGarden(flower);
            return f1;
        }
        [HttpGet]
        [Route("calcWatering")]
        public int CalcNumDays([FromBody] FlowerInGardenDTO f,int userPreference,string livingArea,string sun)
        {
            DateTime date = DateTime.Now;
            int numDays;
            if (Dates.IsShmita(date) == true)
            {
                numDays = Dates.ShmitaCalcWatering(livingArea,sun,f );
            }
            else
            {
                numDays = Dates.CalcTimesPerWeek(livingArea, f, userPreference);
            }
            return numDays;
        }
        [HttpPost]
        [Route("calcAmount")]
        public void CalcAmount([FromBody] FlowerInGardenDTO f,string sun, int userPreference,int userId,double lat,double lon)
        {
            
            double amount=0;
                        
            amount = Dates.CalcAmount(f,userId,sun,userPreference,lat,lon);
                                       
            //return amount;
        }

        [HttpPost]
        [Route("createGarden")]
        public GardensDTO CreateGarden([FromBody]GardensDTO g)
        {            
            try
            {
               GardensDTO g1 =  GardensBL.CreateNewGarden(g);
               return g1;
            }
            catch(Exception e)
            {
               throw e;
            }
        }
        [HttpPost]
        [Route("deletGarden")]
        public IHttpActionResult DelGarden([FromBody] GardensDTO g)
        {
            if (g == null)
            {

                return BadRequest();
            }
            GardensBL.DeleteGarden(g);
            return Ok();
        }
        [HttpPut]
        [Route("updateGarden")]
        public GardensDTO UpdateGarden([FromBody] GardensDTO g)
        {
            
                GardensBL.UpdateGardenDetails(g);
                return g;
            
        }        
        [HttpPut]
        [Route("updateFlower")]
        public FlowerInGardenDTO UpdateFlower([FromBody] FlowerInGardenDTO f)
        {            
                FlowerBl.UpdateFlower(f);
                return f;
           
        }
        [HttpGet]
        [Route("getAllFlowers")]
        public IEnumerable<FlowersDTO> GetAllFLowers()
        {
            
           return FlowerBl.GetAllFlowers();
            
        }
        [HttpGet]
        [Route("isShmita")]
        public  bool CheckShmita()
        {
            DateTime date = DateTime.Now;
            return Dates.IsShmita(date);
        }
        //[HttpGet]
        //[Route("wateringId")]
        //public int CalcWatwringId(int soilType)
        //{
        //    return FlowerBl.CalcWateringId(soilType);
        //}
    }
}
