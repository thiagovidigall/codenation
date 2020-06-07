using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("company")]
    public class Company
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("slug")]
        public string Slug { get; set; }

        [Required]
        [Column("created_at")]
        public DateTime Created_At { get; set; }

        //propriedade de navegação + construtor
        public ICollection<Candidate> Candidates { get; } = new List<Candidate>();
    }
}