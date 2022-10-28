using Microsoft.AspNetCore.Mvc;
using Mini_Project_Sample.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Mini_Project_Sample.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> ViewEmployee()
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7229");
            List<EmployeeDetailsMvc>? employee = new List<EmployeeDetailsMvc>();

            HttpResponseMessage res = await client.GetAsync("api/Employee/get");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<List<EmployeeDetailsMvc>>(result);
            }
            return View(employee);

        }

        public async Task<IActionResult> Post()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7229");
            List<DesignationMvc>? designTemp = new List<DesignationMvc>();

            HttpResponseMessage res = await client.GetAsync("api/Designation/GET");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                designTemp = JsonConvert.DeserializeObject<List<DesignationMvc>>(result);
                ViewData["designationtemp"] = designTemp;
            }
            return View();
        }
        [HttpPost]


        public IActionResult Post(EmployeeDetailsMvc modelobj)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7229");
            var postTask = client.PostAsJsonAsync<EmployeeDetailsMvc>("api/Employee/post", modelobj);
            postTask.Wait();
            var Result = postTask.Result;
            if (Result.IsSuccessStatusCode)
            {
                return RedirectToAction("ViewEmployee");
            }
            return View();
        }
        public async Task<IActionResult> Delete(string UserName)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7229");
            await client.DeleteAsync($"api/Employee/delete/{UserName}");
            return RedirectToAction("ViewEmployee");

        }
        [HttpGet]
        public async Task<IActionResult> Edit(string username)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7229");
            List<DesignationMvc>? designTemp = new List<DesignationMvc>();

            HttpResponseMessage des = await client.GetAsync("api/Designation/GET");

            if (des.IsSuccessStatusCode)
            {
                var result = des.Content.ReadAsStringAsync().Result;
                designTemp = JsonConvert.DeserializeObject<List<DesignationMvc>>(result);
                ViewData["designationtemp"] = designTemp;
            }

            TempClass tempdata = new TempClass();
            HttpResponseMessage res = await client.GetAsync($"api/Employee/get/{username}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                tempdata = JsonConvert.DeserializeObject<TempClass>(result);
            }
            return View(tempdata);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(TempClass temp1)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7229");
            List<DesignationMvc>? designTemp = new List<DesignationMvc>();

            HttpResponseMessage des = await client.GetAsync("api/Designation/GET");

            if (des.IsSuccessStatusCode)
            {
                var result = des.Content.ReadAsStringAsync().Result;
                designTemp = JsonConvert.DeserializeObject<List<DesignationMvc>>(result);
                ViewData["designationtemp"] = designTemp;
            }
            var postTask = client.PostAsJsonAsync<TempClass>("api/Employee/Edit", temp1);
            postTask.Wait();
            var Result = postTask.Result;
            if (Result.IsSuccessStatusCode)
            {
                return RedirectToAction("ViewEmployee");
            }
            return View();
        }
        public ActionResult Designation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Designation(DesignationMvc designationClass)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7229");
            var postTask = client.PostAsJsonAsync<DesignationMvc>("api/Designation/designation", designationClass);
            postTask.Wait();
            var Result = postTask.Result;
            if (Result.IsSuccessStatusCode)
            {
                return RedirectToAction("DashBoard");
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AdminMvc loginDetails)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7229");
            var postTask = client.PostAsJsonAsync("api/Admin/login", loginDetails);
            postTask.Wait();
            var Result = postTask.Result;
            if (!Result.IsSuccessStatusCode)
            {
                return BadRequest("User wrong");
            }
            return RedirectToAction("DashBoard");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(AdminMvc user2)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7229");
            var postTask = client.PostAsJsonAsync<AdminMvc>("api/Admin/Register", user2);
            postTask.Wait();
            var Result = postTask.Result;
            if (Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        public ActionResult DashBoard()
        {
            return View();
        }
        public ActionResult LogOut()
        {

            return RedirectToAction("Login", "AdminMvc");
        }
    }
}
    