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
    public class IndexModel : PageModel
    {
        private readonly one_db_prototype_chilibean.Data.AppDbContext _context;

        public IndexModel(one_db_prototype_chilibean.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Club> Club { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Club = await _context.club_main_tbl.ToListAsync();
        }
    }
}
