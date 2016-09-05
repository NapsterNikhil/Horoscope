using Horoscope.Models;
using System;
using System.Web.Mvc;
using HtmlAgilityPack;
using System.Net;
using System.IO;

namespace Horoscope.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult DisplayHoroscope()
        {
            Models.HoroscopeModel.Day = Convert.ToInt32(Request.Form["Day"]);
            Models.HoroscopeModel.Month = Convert.ToInt32(Request.Form["Month"]);
            GetHoroscope();
            return View();
        }

        public ActionResult GetDOB()
        {
            return View();
        }

        public string GetZodiac()
        {

            DateTime date = new DateTime(2000, HoroscopeModel.Month, HoroscopeModel.Day);
            if ((date.Month == 12 && date.Day >= 22 && date.Day <= 31) || (date.Month == 1 && date.Day >= 1 && date.Day <= 19))
                return "capricorn";
            else if ((date.Month == 1 && date.Day >= 20 && date.Day <= 31) || (date.Month == 2 && date.Day >= 1 && date.Day <= 17))
                return "aquarius";
            else if ((date.Month == 2 && date.Day >= 18 && date.Day <= 29) || (date.Month == 3 && date.Day >= 1 && date.Day <= 19))
                return "pisces";
            else if ((date.Month == 3 && date.Day >= 20 && date.Day <= 31) || (date.Month == 4 && date.Day >= 1 && date.Day <= 19))
                return "aries";
            else if ((date.Month == 4 && date.Day >= 20 && date.Day <= 30) || (date.Month == 5 && date.Day >= 1 && date.Day <= 20))
                return "taurus";
            else if ((date.Month == 5 && date.Day >= 21 && date.Day <= 31) || (date.Month == 6 && date.Day >= 1 && date.Day <= 20))
                return "gemini";
            else if ((date.Month == 6 && date.Day >= 21 && date.Day <= 30) || (date.Month == 7 && date.Day >= 1 && date.Day <= 22))
                return "cancer";
            else if ((date.Month == 7 && date.Day >= 23 && date.Day <= 31) || (date.Month == 8 && date.Day >= 1 && date.Day <= 22))
                return "leo";
            else if ((date.Month == 8 && date.Day >= 23 && date.Day <= 31) || (date.Month == 9 && date.Day >= 1 && date.Day <= 22))
                return "virgo";
            else if ((date.Month == 9 && date.Day >= 23 && date.Day <= 30) || (date.Month == 10 && date.Day >= 1 && date.Day <= 22))
                return "libra";
            else if ((date.Month == 10 && date.Day >= 23 && date.Day <= 31) || (date.Month == 11 && date.Day >= 1 && date.Day <= 21))
                return "scorpio";
            else
                return "sagittarius";
        }
        public void GetHoroscope()
        {
            var doc = new HtmlDocument();
            HtmlAgilityPack.HtmlNode.ElementsFlags["br"] = HtmlAgilityPack.HtmlElementFlag.Empty;
            doc.OptionWriteEmptyNodes = true;

            string zodiac = GetZodiac();
            TempData["sign"] = zodiac;
            var webRequest = HttpWebRequest.Create("http://www.astrology.com/horoscope/daily/" + zodiac + ".html");
            Stream stream = webRequest.GetResponse().GetResponseStream();
            doc.Load(stream);
            stream.Close();
            string testDivSelector = "//div[@class='page-horoscope-text']";
            TempData["name"] = Request.Form["name"];
            TempData["print"] = doc.DocumentNode.SelectSingleNode(testDivSelector).InnerHtml.ToString();
        }
    }
}