using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using one_db_prototype_chilibean.Data;
using one_db_prototype_chilibean.Model;

namespace one_db_prototype_chilibean.Components_Pages_Clubs
{
    public class DetailsModel : PageModel
    {
        private readonly one_db_prototype_chilibean.Data.AppDbContext _context;

        public DetailsModel(one_db_prototype_chilibean.Data.AppDbContext context)
        {
            _context = context;
        }

        public Club Club { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.club_main_tbl.FirstOrDefaultAsync(m => m.club_id == id);
            if (club == null)
            {
                return NotFound();
            }
            else
            {
                Club = club;
            }
            return Page();
        }
    }
}
