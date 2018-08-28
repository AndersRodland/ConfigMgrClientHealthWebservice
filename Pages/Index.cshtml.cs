using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ConfigMgrClientHealthWebservice.Models;

namespace ConfigMgrClientHealthWebservice.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ConfigMgrClientHealthWebservice.Models.ClientHealthContext _context;

        public IndexModel(ConfigMgrClientHealthWebservice.Models.ClientHealthContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Clients Clients { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Clients.Add(Clients);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}