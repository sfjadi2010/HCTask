using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HCTask.Models
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }

        public string PictureName { get; set; }

        public int PersonId { get; set; }
    }
}
