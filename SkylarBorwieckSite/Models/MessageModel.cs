using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SkylarBorwieckSite.Models
{
    public class MessageModel
    { 
      		
        public string Sender { get; set; }


        public string Receipient { get; set; }

   
        public string Subject { get; set; }

        
        public string Message { get; set; }

    }
}

