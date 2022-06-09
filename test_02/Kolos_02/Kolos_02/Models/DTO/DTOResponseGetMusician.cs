using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos_02.Models.DTO
{
    public class DTOResponseGetMusician
    {
        public Musician Musician { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
