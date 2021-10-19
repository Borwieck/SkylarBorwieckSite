using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SkylarBorwieckSite.Models
{
    public class MessageModel
    { 

      	[Required]
        public string Sender { get; set; }

        [Required]
        public string Receipient { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        public string MsgTime { get; set; }


    }
}

