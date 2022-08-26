using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CasesView.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CasesView.Controllers
{
   
    public class HomeController : Controller
    {
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.CaseForCases.ToListAsync());
        }




        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Case case1)
        {
            if (!ModelState.IsValid)
            {
                return View(case1);
            }
            
            
            else
            { 
                db.CaseForCases.Add(case1);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
        }
        
        
        
        public async Task<IActionResult> Details(int? id) // подробнее
        {
            if (id != null)
            {
                Case caseone = await db.CaseForCases.FirstOrDefaultAsync(p => p.Id == id);
                if (caseone != null)
                    return View(caseone);
            }
            return NotFound();
        }

        
        
        public async Task<IActionResult> Edit(int? id)
        {
            if(id!=null)
            {
                Case? case1 = await db.CaseForCases.FirstOrDefaultAsync(p=>p.Id==id);
                if (case1 != null) return View(case1);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Case case1)
        {
            if (!ModelState.IsValid)
            {
                return View(case1);
            }
            else
            {
                
                db.CaseForCases.Update(case1);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Case caseone  = await db.CaseForCases.FirstOrDefaultAsync(p => p.Id == id);
                if (caseone != null)
                    return View(caseone);
            }
            return NotFound();
        }

        
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Case caseone = new Case { Id = id.Value };
                db.Entry(caseone).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }


       
    }

    }  