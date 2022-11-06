using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Repositories;

namespace TaskManager.Controllers
{
    public class TaskControler : Controller
    {
        private readonly ITaskRepository _taskRepository;

        public TaskControler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // GET: TaskControler
        public ActionResult Index()
        {
            return View(_taskRepository.GetAllActive());
        }

        // GET: TaskControler/Details/5
        public ActionResult Details(int id)
        {
            return View(_taskRepository.Get(id));
        }

        // GET: TaskControler/Create
        public ActionResult Create()
        {
            return View(new TaskModel());
        }

        // POST: TaskControler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskModel taskModel)
        {
            _taskRepository.Add(taskModel);

            return RedirectToAction(nameof(Index));
        }

        // GET: TaskControler/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_taskRepository.Get(id));
        }

        // POST: TaskControler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskModel taskModel)
        {
            _taskRepository.Update(id, taskModel);

            return RedirectToAction(nameof(Index));
        }

        // GET: TaskControler/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_taskRepository.Get(id));
        }

        // POST: TaskControler/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TaskModel taskModel)
        {
            _taskRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        // GET: TaskControler/Done
        public ActionResult Done(int id)
        {
            TaskModel task = _taskRepository.Get(id);
            task.Done = true;
            _taskRepository.Update(id, task);

            return RedirectToAction(nameof(Index));
        }
    }
}
