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
    public class Delete_AccountModel : PageModel
    {
        private readonly MyWebbApp.Data.MyWebbAppContext _context;

        public Delete_AccountModel(MyWebbApp.Data.MyWebbAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Users Users { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var Users_Var = await _context.Users.FirstOrDefaultAsync(m => m.ID == id);
            if (Users_Var == null)
            {
                return NotFound();
            }
            else
            {
                Users = Users_Var;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }
            var Users_Var = await _context.Users.FindAsync(id);
            
            if (Users_Var != null)
            {
                Users = Users_Var;
                _context.Users.Remove(Users);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}