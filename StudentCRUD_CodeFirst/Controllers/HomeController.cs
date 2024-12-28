using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCRUD_CodeFirst.Models;

namespace StudentCRUD_CodeFirst.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDbContext context;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(StudentDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var std = await context.Students.ToListAsync();
            return View(std);
        }


        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student std)
        {
            if (ModelState.IsValid)
            {
                await context.Students.AddAsync(std);

                await context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");// OR RedirectToAction(nameof(Index))
            }

            return View();
        }

        public async Task<IActionResult> Details(int? id) // this tell id is nullable by keeping int? id
        {
            if (id == null || context.Students == null)
            {
                return NotFound();
            }
            var std = await context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (std == null)
            {
                return NotFound();
            }

            return View(std);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || context.Students == null)
            {
                return NotFound();
            }
            var std = await context.Students.FindAsync(id);
            if (std == null)
            {
                return NotFound();
            }
            return View(std);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Student std)
        {
            if (id != std.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)

            {
                context.Students.Update(std);
                await context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(std);

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var std = await context.Students.FindAsync(id);
            if (std == null)
            {
                return NotFound();
            }
            return View(std);

        }

        [HttpPost, ActionName("Delete")]   // since here two delete method cant exist so changing its name to Deleteconfirmed due to which we should tell framework 
                                           // that this DeleteConfirmed is the http  post method of Delete by writtin ActionName(" ") keyword
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {

            var std = await context.Students.FindAsync(id);
            if (std != null)
            {
                context.Students.Remove(std);
            }
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
