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
    public class IndexModel : PageModel
    {
        private readonly MyWebbApp.Data.MyWebbAppContext _context;

        public IndexModel(MyWebbApp.Data.MyWebbAppContext context)
        {
            _context = context;
        }

        public IList<My_Projects_Model> My_Projects_Model { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.My_Projects_Model != null)
            {
                My_Projects_Model = await _context.My_Projects_Model.ToListAsync();
            }
        }
    }
}
