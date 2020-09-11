using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupportPagesPro.Data;
using SupportPagesPro.Models;

namespace SupportPagesPro.Pages.SupportTickets
{
    public class DeleteModel : PageModel
    {
        private readonly SupportPagesPro.Data.SupportPagesProContext _context;

        public DeleteModel(SupportPagesPro.Data.SupportPagesProContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SupportTicket SupportTicket { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SupportTicket = await _context.SupportTicket.FirstOrDefaultAsync(m => m.Id == id);

            if (SupportTicket == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SupportTicket = await _context.SupportTicket.FindAsync(id);

            if (SupportTicket != null)
            {
                _context.SupportTicket.Remove(SupportTicket);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
