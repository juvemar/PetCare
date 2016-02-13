namespace PetCare.Common
{
    using System;
    using System.Collections.Generic;

    public static class LoadSpecies
    {
        private static List<string> species;

        public static List<string> ReadSpecies()
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
