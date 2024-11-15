using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWebbApp.Data;
using MyWebbApp.Models;

namespace MyWebbApp.Pages.Admin_Pages
{
    public class EditModel : PageModel
    {
        private readonly MyWebbApp.Data.MyWebbAppContext _context;

        public EditModel(MyWebbApp.Data.MyWebbAppContext context)
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

            var my_projects_model =  await _context.My_Projects_Model.FirstOrDefaultAsync(m => m.ID == id);
            if (my_projects_model == null)
            {
                return NotFound();
            }
            My_Projects_Model = my_projects_model;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(My_Projects_Model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!My_Projects_ModelExists(My_Projects_Model.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool My_Projects_ModelExists(int id)
        {
          return (_context.My_Projects_Model?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
