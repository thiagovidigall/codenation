using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Codenation.Challenge.Models
{
    [Table("challenge")]
    public class Challenge
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

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

        //propriedade de navegação
        public ICollection<SubMission> SubMissions { get; set; }
        public ICollection<Acceleration> Accelerations { get; set; }

        //construtor
        public Challenge()
        {
            SubMissions = new Collection<SubMission>();
            Accelerations = new Collection<Acceleration>();
        }
    }
}
