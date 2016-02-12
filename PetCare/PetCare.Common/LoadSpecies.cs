namespace PetCare.Common
{
    using System;
    using System.Collections.Generic;

    public class LoadSpecies
    {
        private List<string> species;

        public List<string> ReadSpecies()
        {
            species = new List<string>();

            foreach (var item in Enum.GetValues(typeof(SpeciesType)))
            {
                species.Add(item.ToString());
            }

            return species;
        }
    }
}
