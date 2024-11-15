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
    public class Details_AccountModel : PageModel
    {
        private readonly MyWebbApp.Data.MyWebbAppContext _context;

        public Details_AccountModel(MyWebbApp.Data.MyWebbAppContext context)
        {
            _context = context;
        }

        public Users Users { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user_var = await _context.Users.FirstOrDefaultAsync(m => m.ID == id);
            if (user_var == null)
            {
                return NotFound();
            }
            else
            {
                Users = user_var;
            }
            return Page();
        }
    }
}
