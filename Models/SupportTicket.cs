using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace SupportPagesPro.Models
{
    public class SupportTicket
    {
        [Key]
        public int Id { get; set; }


        public string YourMail { get; set; }


        public string Subject { get; set; }



        public string Description { get; set; }

            
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public Status Status { get; set; }

        public Assigned Assigned { get; set; }

       
    }
}
