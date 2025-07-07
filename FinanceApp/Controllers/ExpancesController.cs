using FinanceApp.Data;
using FinanceApp.Data.Services;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Controllers
{
    public class ExpancesController : Controller
    {
        private readonly IExpancesService _expancesService;
        
        //constructor
        public ExpancesController(IExpancesService expancesService)
        {
            _expancesService = expancesService;
        }
        public async Task<IActionResult> Index()
        {
            var expanses = await _expancesService.GetAll();
            return View(expanses);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Expances expances)
        {
            if(ModelState.IsValid)
            {

                await _expancesService.Add(expances);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult GetChart()
        {
            var data = _expancesService.GetChartData();
            return Json(data);
        }
    }
}
