using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SupportPagesPro.Data;
using SupportPagesPro.Models;


namespace SupportPagesPro.Pages.SupportTickets
{
    public class CreateModel : PageModel
    {
        private readonly SupportPagesPro.Data.SupportPagesProContext _context;

        public CreateModel(SupportPagesPro.Data.SupportPagesProContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SupportTicket SupportTicket { get; set; }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SupportTicket.CreatedDate = DateTime.Now;

            _context.SupportTicket.Add(SupportTicket);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Response");
        }

       

    }
}
