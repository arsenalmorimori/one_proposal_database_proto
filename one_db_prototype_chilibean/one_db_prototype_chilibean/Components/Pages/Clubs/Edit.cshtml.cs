using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using one_db_prototype_chilibean.Data;
using one_db_prototype_chilibean.Model;

namespace one_db_prototype_chilibean.Components_Pages_Clubs
{
    public class EditModel : PageModel
    {
        private readonly one_db_prototype_chilibean.Data.AppDbContext _context;

        public EditModel(one_db_prototype_chilibean.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Club Club { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club =  await _context.club_main_tbl.FirstOrDefaultAsync(m => m.club_id == id);
            if (club == null)
            {
                return NotFound();
            }
            Club = club;
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

            _context.Attach(Club).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClubExists(Club.club_id))
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

        private bool ClubExists(int id)
        {
            return _context.club_main_tbl.Any(e => e.club_id == id);
        }
    }
}
