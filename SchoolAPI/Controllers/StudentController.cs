using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SchoolAPI.Controllers
{
    public class StudentController : Controller
    {
        IEnumerable<Student> students = null;
        // GET: Student
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult GetAll()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:47484/api");

                var responseTask = client.GetAsync("students");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Student>>();
                    readTask.Wait();

                    students = readTask.Result;
                }
                else
                {
                    students = Enumerable.Empty<Student>();
                    ModelState.AddModelError(string.Empty, "Server error. Please check connection");
                }
            }
            return Json(new { data = students });
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44348//api");

                var postTask = client.PostAsJsonAsync<Student>("student", student);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server error");
            return View(student);
        }
    }
}