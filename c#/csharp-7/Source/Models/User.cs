using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Codenation.Challenge.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("full_name")]
        public string Full_Name { get; set; }

        [Required]
        [StringLength(100)]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [Column("nickname")]
        public string NickName { get; set; }

        [Required]
        [StringLength(255)]
        [Column("password")]
        public string Password { get; set; }

        [Required]        
        [Column("created_at")]
        public DateTime Created_At { get; set; }

        //propriedade de navegação
        public ICollection<SubMission> SubMissions { get; set; }

        //propriedade de navegação
        public ICollection<Candidate> Candidates { get; set; }

        //contrutor
        public User()
        {
            SubMissions = new Collection<SubMission>();
            Candidates = new Collection<Candidate>();
        }

        

    }
}
