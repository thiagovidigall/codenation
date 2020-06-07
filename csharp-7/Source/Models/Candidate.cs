using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Codenation.Challenge.Models
{
    public class Candidate
    {

        //chaves estrangeiras
        public int User_Id { get; set; }
        public int Acceleration_Id { get; set; }
        public int Company_Id { get; set; }
        //chaves estrangeiras

        public int Status { get; set; }      
        public DateTime Created_At { get; set; }


        //propriedade de navegação
        public User User { get; set; }

        public Acceleration Acceleration { get; set; }
        
        public Company Company { get; set; }
        //propriedade de navegação
    }
}
