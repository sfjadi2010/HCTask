using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HCTask.Models
{
    public class PersonRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public string Interests { get; set; }

        [Required]
        [MaxLength(256)]
        public string Street { get; set; }

        [Required]
        [MaxLength(64)]
        public string City { get; set; }

        [Required]
        public string PostalCode { get; set; }

        public string State { get; set; }

        public string PictureName { get; set; }

        [NotMapped]
        public string FileAsBase64 { get; set; }

        [NotMapped]
        public byte[] FileAsByteArray { get; set; }
    }
}
