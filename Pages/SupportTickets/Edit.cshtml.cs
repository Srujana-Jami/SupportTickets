using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SupportPagesPro.Data;
using SupportPagesPro.Models;

namespace SupportPagesPro.Pages.SupportTickets
{
    public class EditModel : PageModel
    {
        private readonly SupportPagesPro.Data.SupportPagesProContext _context;
        private readonly IHtmlHelper htmlHelper;


        public EditModel(SupportPagesPro.Data.SupportPagesProContext context,IHtmlHelper htmlHelper)
        {
            _context = context;
            this.htmlHelper = htmlHelper;
        }

        [BindProperty]
        public SupportTicket SupportTicket { get; set; }
        public IEnumerable<SelectListItem> Status { get; set; }
        public IEnumerable<SelectListItem> Assigned { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Status = htmlHelper.GetEnumSelectList<Status>();
            Assigned = htmlHelper.GetEnumSelectList<Assigned>();
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



        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
          ///*SupportTicket = SupportTicket.Update(SupportTicket);
          // SupportTicket.Commit();
             
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SupportTicket).State = EntityState.Modified;

            try
            {
                SupportTicket.UpdatedDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupportTicketExists(SupportTicket.Id))
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

        private bool SupportTicketExists(int id)
        {
            return _context.SupportTicket.Any(e => e.Id == id);
        }
    }
}
