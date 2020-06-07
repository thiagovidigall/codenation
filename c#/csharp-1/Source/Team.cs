using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Challenge
{
    public class Team : IIdentifier
    {
        public Team(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            Id = id;
            Name = name;
            CreateDate = createDate;
            MainShirtColor = mainShirtColor;
            SecondaryShirtColor = secondaryShirtColor;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string MainShirtColor { get; set; }
        public string SecondaryShirtColor { get; set; }

        public override bool Equals(object obj)
        {
            Team t = obj as Team;

            if (t == null)
            {
                return false;
            }
            else
            {
                return (Id == t.Id);
            }
        }

    }
}
