using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ConfigMgrClientHealthWebservice.Models;

namespace ConfigMgrClientHealthWebservice.Pages
{
    public class ListModel : PageModel
    {
        private readonly ConfigMgrClientHealthWebservice.Models.ClientHealthContext _context;

        public ListModel(ConfigMgrClientHealthWebservice.Models.ClientHealthContext context)
        {
            _context = context;
        }

        public IList<Clients> Clients { get;set; }

        public async Task OnGetAsync()
        {
            Clients = await _context.Clients.ToListAsync();
        }
    }
}
