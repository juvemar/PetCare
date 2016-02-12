namespace PetCare.Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web;

    public class ReadSpeciesData
    {
        private ICollection<string> species;

        public ICollection<string> ReadSpecies()
        {
            species = new HashSet<string>();

            string path = HttpContext.Current.Server.MapPath("~/../PetCare.Data/Species.txt");

            string line;
            using (StreamReader reader = new StreamReader(path))
            {
                line = reader.ReadLine();
                var separated = line.Split(GlobalConstants.Delimiters,
                     StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < separated.Length; i++)
                {
                    species.Add(separated[i]);
                }
            }

            return species;
        }
    }
}
