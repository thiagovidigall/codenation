using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Codenation.Challenge.Models
{
    [Table("submission")]
    public class SubMission
    {
        
        //Chave estrangeira
        [Column("user_id")]
        public int User_Id { get; set; }

        //Chave estrangeira
        [Column("challenge_id")]
        public int Challenge_Id { get; set; }

        [Required]
        [Column("score")]
        public string Score { get; set; }

        [Required]        
        [Column("created_at")]
        public DateTime Created_At { get; set; }


        //propriedade de navegação
        public User User { get; set; }

        //propriedade de navegação
        public Challenge Challenge { get; set; }      
        
    }
}
