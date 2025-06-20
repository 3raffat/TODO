using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TODO.Models;
using TODO.Models.Repository;

namespace TODO.Controllers
{
    public class TodoController : Controller
    {
        public IRepository<Todo> Todo { get; }

        public TodoController(IRepository<Todo> todo)
        {
            Todo = todo;
        }
        // GET: TodoController
        public ActionResult Index()
        {
            return View(Todo.View());
        }

        // GET: TodoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TodoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TodoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Todo collection)
        {
            try
            {
                Todo.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Todo.Find(id));
        }

        // POST: TodoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Todo collection)
        {
            try
            {
                Todo.Update(id,collection);    
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Todo.Find(id));
        }

        // POST: TodoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Todo collection)
        {
            try
            {
                Todo.Delete(id,collection);    
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
