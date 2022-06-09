﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos_02.Models
{
    public class Musician
    {
        public int IdMusician { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }

        public virtual ICollection<MusicianTrack> MusicianTracks { get; set; }
    }
}
