using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Codenation.Challenge.Models
{
    [Table("candidate")]
    public class Candidate
    {
        //chaves estrangeiras
        [Column("user_id")]
        public int User_Id { get; set; }
        
        [Column("acceleration_id")]
        public int Acceleration_Id { get; set; }
       
        [Column("company_id")]
        public int Company_Id { get; set; }

        [Required]
        [Column("status")]
        public int Status { get; set; }

        [Required]        
        [Column("created_at")]
        public DateTime Created_At { get; set; }

        //propriedades de navegação
        public User User { get; set; }

        //propriedade de navegação
        public Acceleration Acceleration { get; set; }

        //propriedade de navegação
        public Company Company { get; set; }
    }
}
