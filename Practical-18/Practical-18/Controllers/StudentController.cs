using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Practical_18.Interface;
using Practical_18.Models;
using Practical_18.ViewModels;


namespace Practical_18.Controllers
{
    public class StudentController : Controller
    {
        //private readonly HttpClient _httpClient;
        //public StudentController(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string apiUrl = "https://localhost:7065/api/Student";



            HttpClient client = new HttpClient();
            var students = new List<StudentViewModel>();
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                students = JsonConvert.DeserializeObject<List<StudentViewModel>>(response.Content.ReadAsStringAsync().Result);
            }
            return View(students); 
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentViewModel student)
        {
            if (ModelState.IsValid)
            {


                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7065/api/Student");
                var postTask = client.PostAsJsonAsync<StudentViewModel>("student", student);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            }

            return View(student);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            string apiUrl = $"https://localhost:7065/api/Student/{id}";

            HttpClient client = new HttpClient();
            var student = new StudentViewModel();
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                student = JsonConvert.DeserializeObject<StudentViewModel>(response.Content.ReadAsStringAsync().Result);
            }
            return View(student);


        }
        [HttpPost]
        public ActionResult Edit(StudentViewModel student)
        {
            if (ModelState.IsValid)
            {


                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7065/api/Student");
                var postTask = client.PutAsJsonAsync<StudentViewModel>("student", student);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            }

            return View(student);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            string apiUrl = $"https://localhost:7065/api/Student/{id}";

            HttpClient client = new HttpClient();
            
            var deleteTask = client.DeleteAsync(apiUrl);
            deleteTask.Wait();
            var response = deleteTask.Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id) {
            string apiUrl = $"https://localhost:7065/api/Student/{id}";



            HttpClient client = new HttpClient();
            var student = new StudentViewModel();
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                student = JsonConvert.DeserializeObject<StudentViewModel>(response.Content.ReadAsStringAsync().Result);
            }
            return View(student);
        }

    }
}
