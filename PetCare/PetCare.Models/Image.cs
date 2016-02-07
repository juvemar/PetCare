using System.ComponentModel.DataAnnotations;

namespace PetCare.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        public byte[] Content { get; set; }

        public string Extension { get; set; }
    }
}
