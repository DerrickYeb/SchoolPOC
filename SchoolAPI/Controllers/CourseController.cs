using SchoolAPI.DataAccess;
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SchoolAPI.Controllers
{
    public class CourseController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        IEnumerable<Course> courses = null;
        // GET: Course
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44348/api/");

                var responseTask = client.GetAsync("course");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Course>>();
                    readTask.Wait();

                    courses = readTask.Result;
                }
                else
                {
                    courses = Enumerable.Empty<Course>();
                    ModelState.AddModelError(string.Empty, "Server error. Please check connection");
                }
            }
            return View(courses);
        }

        public ActionResult GetAll()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44348/api/");

                var responseTask = client.GetAsync("course");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Course>>();
                    readTask.Wait();

                    courses = readTask.Result;
                }
                else
                {
                    courses = Enumerable.Empty<Course>();
                    ModelState.AddModelError(string.Empty, "Server error. Please check connection");
                }
            }
            return View(courses);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44348/api/course");

                    var postTask = client.PostAsJsonAsync<Course>("course", course);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                ModelState.AddModelError(string.Empty, "Server error");
                
            }
            return View(course);
        }
    }
}