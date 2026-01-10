using Microsoft.AspNetCore.Mvc;
using BeyazEsya.Models;
using Newtonsoft.Json;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
namespace BeyazEsya.Controllers
{
    public class BrandApiController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7188/api/Brands");
        private readonly HttpClient _httpClient;    

        public BrandApiController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Brands> brands = new List<Brands>();
            HttpResponseMessage response=_httpClient.GetAsync(baseAddress).Result;
            if (response.IsSuccessStatusCode)
            {
                string data=response.Content.ReadAsStringAsync().Result;
                brands=JsonConvert.DeserializeObject<List<Brands>>(data);
            }
            return View(brands);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Brands brands)
        {
            try
            {
                string data=JsonConvert.SerializeObject(brands);
                StringContent content=new StringContent(data,Encoding.UTF8,"Application/Json");
                HttpResponseMessage response=_httpClient.PostAsync(_httpClient.BaseAddress, content).Result;
            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Brands brands = new Brands();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/BrandApi/Get/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                brands = JsonConvert.DeserializeObject<Brands>(data);
                View(brands);
            }
            return View();
        }
        [HttpPost("id")]
        public IActionResult Edit(Brands brand,int id)
        {
            try
            {
                string data= JsonConvert.SerializeObject(brand);
                StringContent content = new StringContent(data, Encoding.UTF8, "Application/Json");
                HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress + "/BrandApi/Put", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "İşlem Başarılı";
                    return RedirectToAction("Index");
                }
                    

            }
            catch(Exception ex)
            {
                TempData["Error"]=ex.Message;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
