using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Challenge
{
    public class Player : IIdentifier, ITeamIdentifier
    {
        
        public long Id  { get; set; }

        public string Name { get; set; }

        public long TeamId { get; set; }

        public DateTime BirthDate { get; set; }

        public int SkillLevel { get; set; }

        public decimal Salary { get; set; }

        public bool isCaptain { get; set; }

        public Player(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            TeamId = teamId;
            Id = id;
            Name = name;
            BirthDate = birthDate;
            SkillLevel = skillLevel;
            Salary = salary;
            isCaptain = false;
        }

        public override bool Equals(object obj)
        {
            Player p = obj as Player;
            if (p == null)
                return false;
            else
                return Id.Equals(p.Id);
        }
    }
}
