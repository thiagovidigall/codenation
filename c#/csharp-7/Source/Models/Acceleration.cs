using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Codenation.Challenge.Models
{
    public class Acceleration
    {
        public int Id { get; set; }

        //chaves estrangeiras
        public int Challenge_Id { get; set; }
        //chaves estrangeiras

        public string Name { get; set; }
        public string Slug { get; set; }
        public DateTime Created_At { get; set; }

        //propriedade de navegação
        public Challenge Challenge { get; set; }      

        //propriedade de navegação + construtor
        public ICollection<Candidate> Candidates { get; } = new List<Candidate>();
    }
}
