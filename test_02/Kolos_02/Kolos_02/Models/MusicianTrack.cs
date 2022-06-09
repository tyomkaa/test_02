using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos_02.Models
{
    public class MusicianTrack
    {
        public int IdMusicianTrack { get; set; }
        public int IdTrack { get; set; }
        public int IdMusician { get; set; }

        public virtual Track Track { get; set; }
        public virtual Musician Musician { get; set; }
    }
}
