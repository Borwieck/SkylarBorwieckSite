using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace SkylarBorwieckSite.Models
{
    public class QuizModel
    { 
        
        [Display(Name ="Answer")]
        public string SelectedAnswer { get; set; }
        
        public static string Check { get; set; }

        public static bool CheckAnswer(string submit,string answer)
        {
            if(submit==answer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
}
    }


 