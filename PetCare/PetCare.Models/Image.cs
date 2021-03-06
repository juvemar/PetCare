﻿namespace PetCare.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Image : IDeletableEntity, IAuditInfo
    {
        public Image()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Key]
        public int Id { get; set; }

        public byte[] Content { get; set; }

        public string Extension { get; set; }
    }
}
