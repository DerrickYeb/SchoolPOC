using SchoolAPI.DataAccess;
using SchoolAPI.Models;
using SchoolAPI.Models.ViewModels;
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
        ApplicationDbContext context = new ApplicationDbContext();
        IEnumerable<Student> students = null;
        // GET: Student
        public ActionResult Index()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44348//api/");

                var responseTask = client.GetAsync("student");
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
            return View(students);
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:47484/api/student");

                var responseTask = client.GetAsync("student");
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
            return View(students);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44348//api/student");

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
        public ActionResult Assign(int? id)
        {
            StudentVM studentVM = new StudentVM()
            {
                Student = new Student(),
                CoursesList = context.Courses.Select(i => new SelectListItem
                {
                    Text = i.Title,
                    Value = i.Id.ToString()
                }),
               
            };

            if (id == null)
            {
                return View(studentVM);
            }
            studentVM.Student = context.Students.Find(id.GetValueOrDefault());
            if (studentVM.Student == null)
            {
                return HttpNotFound();
            }
            return View(studentVM);
        }
    }
}