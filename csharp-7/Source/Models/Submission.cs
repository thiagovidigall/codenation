using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Codenation.Challenge.Models
{
    public class Submission
    {

        public int User_Id { get; set; }
        public int Challenge_Id { get; set; }
        public decimal Score { get; set; }      
        public DateTime Created_At { get; set; }
        public User User { get; set; }        
        public Challenge Challenge { get; set; }
   
    }
}
