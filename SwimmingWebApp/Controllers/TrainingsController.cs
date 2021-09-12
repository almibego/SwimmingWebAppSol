using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwimmingWebApp.DAL.Data;
using SwimmingWebApp.DAL.Entities;
using SwimmingWebApp.Models;
using SwimmingWebApp.Extensions;


namespace SwimmingWebApp.Controllers
{
    public class TrainingsController : Controller
    {
        ApplicationDbContext _context;

        int _pageSize;

        public TrainingsController(ApplicationDbContext context)
        {
            _pageSize = 3;
            _context = context;
        }

        [Route("Trainings")]
        [Route("Trainings/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            var trainingsFiltered = _context.Trainings
                                .Where(d => !group.HasValue || d.SwimmerId == group.Value);
            // Поместить список групп во ViewData
            ViewData["Swimmers"] = _context.Swimmers;
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentSwimmer"] = group ?? 0;

            var model = ListViewModel<Training>.GetModel(trainingsFiltered, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }
    }
}