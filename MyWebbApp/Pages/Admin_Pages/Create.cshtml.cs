using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebbApp.Data;
using MyWebbApp.Models;

namespace MyWebbApp.Pages.Admin_Pages
{
    public class CreateModel : PageModel
    {
        private readonly MyWebbApp.Data.MyWebbAppContext _context;

        public CreateModel(MyWebbApp.Data.MyWebbAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public My_Projects_Model My_Projects_Model { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.My_Projects_Model == null || My_Projects_Model == null)
            {
                return Page();
            }

            _context.My_Projects_Model.Add(My_Projects_Model);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
