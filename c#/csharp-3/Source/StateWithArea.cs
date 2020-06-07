using System;

namespace Codenation.Challenge
{
    public class StateWithArea : State
    {
        public StateWithArea(string name, string acronym, decimal area) : base(name, acronym)
        {
            Name = name;
            Acronym = acronym;
            Area = area;
        }

        public decimal Area { get; set; }
    }

}
