using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Codenation.Challenge.Models
{
    [Table("acceleration")]
    public class Acceleration
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("challenge_id")]
        public int Challenge_Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Column("slug")]
        public string Slug { get; set; }

        [Required]        
        [Column("created_at")]
        public DateTime Created_At { get; set; }

        public Challenge Challenge { get; set; }

        //propriedade de navegação
        public ICollection<Candidate> Candidates { get; set; }

        public Acceleration()
        {
            Candidates = new Collection<Candidate>();
        }
    }
}
