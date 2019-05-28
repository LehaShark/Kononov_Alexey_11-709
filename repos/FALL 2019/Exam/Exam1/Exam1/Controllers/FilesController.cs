using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exam1.Controllers
{
    public class FilesController : Controller
    {
        ApplicationContext db;
        public FilesController(ApplicationContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Files.ToList());
        }
        [HttpGet]
        public IActionResult Info(int id)
        {
            ViewBag.FileId = id;
            return View(db.Files.ToList());
        }
    }
}