using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Codenation.Challenge
{
    public class Country
    {        
        public State[] Top10StatesByArea()
        {
            return GetStatesWithArea().OrderByDescending(x => x.Area).Take(10).Select(x=> new StateWithArea(x.Name, x.Acronym, x.Area)).ToArray();
        }

        private List<StateWithArea> GetStatesWithArea()
        {
            List<StateWithArea> list = new List<StateWithArea>();

            list.Add(new StateWithArea("Rondonia", "RO", 237590.547m));
            list.Add(new StateWithArea("Acre", "AC", 164123.040m));
            list.Add(new StateWithArea("Amazonas", "AM", 1559159.148m));
            list.Add(new StateWithArea("Para", "PA", 1247954.666m));
            list.Add(new StateWithArea("Amapa", "AP", 142828.521m));
            list.Add(new StateWithArea("Tocantins", "TO", 277720.520m));
            list.Add(new StateWithArea("Maranhao", "MA", 331937.450m));
            list.Add(new StateWithArea("Piaui", "PI", 251577.738m));
            list.Add(new StateWithArea("Ceara", "CE", 148920.472m));
            list.Add(new StateWithArea("Rio Grande do Norte", "RN", 52811.047m));
            list.Add(new StateWithArea("Paraiba", "PB", 56585.000m));
            list.Add(new StateWithArea("Pernambuco", "PE", 98311.616m));
            list.Add(new StateWithArea("Alagoas", "SE", 27778.506m));
            list.Add(new StateWithArea("Sergipe", "AL", 21915.116m));
            list.Add(new StateWithArea("Bahia", "BA", 564733.177m));
            list.Add(new StateWithArea("Minas Gerais", "MG", 586522.122m));
            list.Add(new StateWithArea("Espirito Santo", "ES", 46095.583m));
            list.Add(new StateWithArea("Rio de Janeiro", "RJ", 43780.172m));
            list.Add(new StateWithArea("Sao Paulo", "SP", 248222.362m));
            list.Add(new StateWithArea("Parana", "PR", 199307.922m));
            list.Add(new StateWithArea("Santa Catarina", "SC", 95736.165m));
            list.Add(new StateWithArea("Rio Grande do Sul", "RS", 281730.223m));
            list.Add(new StateWithArea("Mato Grosso do Sul", "MS", 357145.532m));
            list.Add(new StateWithArea("Mato Grosso", "MT", 903366.192m));
            list.Add(new StateWithArea("Goias", "GO", 340111.783m));
            list.Add(new StateWithArea("Distrito Federal", "DF", 5779.999m));
            list.Add(new StateWithArea("Roraima", "RR", 224300.506m));

            return list;
        }


    }
}
