using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos_02.Models.DTO
{
    public class DTORequestAddMusician
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public Track Track { get; set; }
    }
}
