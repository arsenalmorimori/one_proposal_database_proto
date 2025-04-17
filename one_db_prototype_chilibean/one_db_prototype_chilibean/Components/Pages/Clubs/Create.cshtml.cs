using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using one_db_prototype_chilibean.Data;
using one_db_prototype_chilibean.Model;

namespace one_db_prototype_chilibean.Components_Pages_Clubs
{
    public class CreateModel : PageModel
    {
        private readonly one_db_prototype_chilibean.Data.AppDbContext _context;

        public CreateModel(one_db_prototype_chilibean.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Club Club { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.club_main_tbl.Add(Club);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
