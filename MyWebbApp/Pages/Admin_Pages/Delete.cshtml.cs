using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebbApp.Data;
using MyWebbApp.Models;

namespace MyWebbApp.Pages.Admin_Pages
{
    public class DeleteModel : PageModel
    {
        private readonly MyWebbApp.Data.MyWebbAppContext _context;

        public DeleteModel(MyWebbApp.Data.MyWebbAppContext context)
        {
            _context = context;
        }

        [BindProperty]
      public My_Projects_Model My_Projects_Model { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.My_Projects_Model == null)
            {
                return NotFound();
            }

            var my_projects_model = await _context.My_Projects_Model.FirstOrDefaultAsync(m => m.ID == id);

            if (my_projects_model == null)
            {
                return NotFound();
            }
            else 
            {
                My_Projects_Model = my_projects_model;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.My_Projects_Model == null)
            {
                return NotFound();
            }
            var my_projects_model = await _context.My_Projects_Model.FindAsync(id);

            if (my_projects_model != null)
            {
                My_Projects_Model = my_projects_model;
                _context.My_Projects_Model.Remove(My_Projects_Model);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
