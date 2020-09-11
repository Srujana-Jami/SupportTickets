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
    public class IndexModel : PageModel
    {
        private readonly SupportPagesPro.Data.SupportPagesProContext _context;

        

        public IndexModel(SupportPagesPro.Data.SupportPagesProContext context)
        {
            _context = context;
        }
        
        
        [BindProperty]


        public IList<SupportTicket> SupportTicket { get; set; }
        

        public async Task OnGetAsync()
        {
            SupportTicket = await _context.SupportTicket.ToListAsync();
        }

        /*public async Task<SupportTicket> Update(SupportTicket updatedSupportTicket)
        {
            SupportTicket = (IList<SupportTicket>)await _context.SupportTicket.FirstOrDefaultAsync(m => m.Id == updatedSupportTicket.Id);
            if (SupportTicket != null)
            {
                SupportTicket.YourMail = updatedSupportTicket.YourMail;
                SupportTicket.Subject = updatedSupportTicket.Subject;
                SupportTicket.Description = updatedSupportTicket.Description;
                SupportTicket.CreatedDate = updatedSupportTicket.CreatedDate;
                SupportTicket.UpdatedDate = updatedSupportTicket.UpdatedDate;
                SupportTicket.Status = updatedSupportTicket.Status;
                SupportTicket.Assigned = updatedSupportTicket.Assigned;

            }

            return (SupportTicket)SupportTicket;
        }*/

       
        public int Commit()
        {
            return 0;
        }
    
    
    }





    

}
