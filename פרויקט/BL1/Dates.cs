using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL1;
using DTO1;
namespace BL1
{

    public class Dates
    {
        public static int NumDays { get; set; }
        //checks if the current year is a "Shmita" year
        public static bool IsShmita(DateTime date)
        {
            HebrewCalendar hc = new HebrewCalendar();
            if (hc.GetYear(date) % 7 == 0)
            {
                return true;
            }
            return false;
        }
        //checks the season
        public static int Season(DateTime date)
        {
            int season;
            if (date.Month == 12 || date.Month <= 3)
            {
                season = 1;//winter=1
            }
            else if (date.Month == 11 || date.Month == 4)
            {
                season = 2;//autmn and spring =2-transition season
            }
            else
            {
                season = 3;//summer =3
            }
            return season;
        }
        //convert the user living area to an id
        public static int Area(string livingArea)
        {
            int area;
            if (livingArea == "צפון")//אזור ההרים
            {
                area = 1;
            }

            else if (livingArea == "מישור החוף והשפלה")//מישור החוף והשפלה
            {
                area = 2;
            }
            else if (livingArea == "הנגב")
                area = 3;//הנגב    
            else
                area = 4;//אילת ,הערבה
            return area;
        }

        //calculate how many times in a week the user should water his flower
        public static int CalcTimesPerWeek(string livingArea, FlowerInGardenDTO f1,int userPreference)
        {
            int numDays=0;
            DateTime date = DateTime.Now;
            FlowerInGarden f = FlowerInGardenDTO.ToflowerInGarden(f1);
            if (userPreference != 0)
            {
                NumDays = userPreference;
            }
            else if (Area(livingArea)==1 && Season(date) == 1)
                NumDays = 20;//In the north,at winter,heavy ground,or easy-no watering neccessary
            else if (Area(livingArea) == 1 && Season(date) == 2)
            {
                NumDays = (int)f.Watering.maxDays;//In the north,at transition season-a little watering is neccessary
            }
            else if (Area(livingArea) == 1 && Season(DateTime.Now) == 3)
            {
                NumDays = (((int)f.Watering.maxDays + (int)f.Watering.minDays) / 2);//In the north ,at summer-a medium watering is neccessary
            }
            else if (Area(livingArea) == 2 && (Season(date) == 1||Season(date)==2))
            {
                NumDays = (int)(((int)f.Watering.maxDays + (int)f.Watering.minDays) / 2);//In the lowlands,at winter or transition -a medium watering is neccessary
            }
            else if (Area(livingArea) != 1 && Season(date) == 3)
            {
                NumDays = (int)f.Watering.minDays;//At summer -a maximum watering is neccessary except from the north
            }
            else if ((Area(livingArea) == 3|| Area(livingArea)==4) && Season(date) == 1)
            {
                NumDays = ((int)f.Watering.maxDays + (int)f.Watering.minDays) / 2;//At winter in the south a medium watering is neccessary
            }
            else
            {
                NumDays = (int)f.Watering.minDays;
            }
            numDays = NumDays;
            return numDays;
        }

        //calculate how many times in a week the user should water his flower on a "Shmita" year
        public static int ShmitaCalcWatering(string livingArea,string sun, FlowerInGardenDTO f1)
        {
            
            FlowerInGarden f = FlowerInGardenDTO.ToflowerInGarden(f1);
                if (sun == "לא"|| f.potType =="נקוב" )
                {
                NumDays = FlowerInGardenDAL.GetMaxDays(f);// בשמיטה צריך להשקות במינימום האפשרי כשהעציץ נקוב ולא מקורה
                }
                else if (f.potType == "לא נקוב" && sun == "כן")
                {
                    NumDays = CalcTimesPerWeek(livingArea, f1,0);//כשהעציץ מקורה והוא לא נקוב ניתן להשקות כרגיל.
                }
            
            return NumDays;
        }
        //calculate the amount of water the user should use
       public static double CalcAmount(FlowerInGardenDTO f,int userId,string sun,int userPreference,double lat,double lon)
        {
            UsersDTO u = UsersDTO.ToUserDTO(UserDAL.GetUserById(userId));
            string livingArea = u.LivingArea;
            DateTime date = DateTime.Now;
            double amount;
            //WeatheAPI.RootObject myWeather = Task.Run(() => W.GetWeather(20.0, 30.0)).Result
             WeatherAPI.RootObject myWeather = Task.Run(() => WeatherAPI.WeatherForecastAsync(lat, lon)).Result;
            //double myHumidity =  myWeather.main.humidity;
            List<WeatherAPI.Weather> myRain = myWeather.weather;
            //Console.WriteLine(myWeather.name + " - " + ((int)myWeather.main.temp).ToString());
            if (sun == "לא")//אם הגינה לא מקורה תבדוק האם צפויים משקעים
            {
                foreach (var item in myRain)
                {
                    if (item.id > 200 && item.id < 621)//אם צפויים משקעים
                    {
                        amount = 0;//לא צריך להשקות
                    }

                }
            }
                        
            if (IsShmita(date) == true)
            {
                amount = f.PotSize * AmountArea(livingArea) * ShmitaCalcWatering(livingArea,sun, f);
                
            }
            else
            {
                amount = f.PotSize * AmountArea(livingArea) * CalcTimesPerWeek(livingArea, f, userPreference);
            }               
            if (MailSending.ActivateGetLaters(date))
            {
                UserBL.SendAlert(f.FlowerName, amount, u.UserMail);
            }
            return amount;
        } 
        //מקדם ההשקיה לפי אזורים
        public static double AmountArea(string livingArea)
        {
            double calc;
            if (Area(livingArea) == 1)
            {
                calc = 6;
            }
            else if (Area(livingArea) == 2)
            {
                calc = 5;
            }
            else if (Area(livingArea) == 3)
            {
                calc = 6.5;
            }
            else
            {
                calc = 11;
            }
            return calc;
        }
        
    }
}
