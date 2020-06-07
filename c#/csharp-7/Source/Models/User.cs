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
        [MaxLength(100)]
        [Column("full_name")]
        public string Full_Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("nickname")]
        public string NickName { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("password")]
        public string Password { get; set; }

        [Required]        
        [Column("created_at")]
        public DateTime Created_At { get; set; }

        //propriedade de navegação + construtor
        public ICollection<Submission> Submissions{ get; } = new List<Submission>();
        public ICollection<Candidate> Candidates { get; } = new List<Candidate>();

    }
}
