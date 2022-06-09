using Kolos_02.Models;
using Kolos_02.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos_02.Services
{
    public class DBMusician : IDBMusician
    {
        private readonly s22527Context _context;

        public DBMusician(s22527Context context)
        {
            _context = context;
        }

        public void DTORequestAddMusician(DTORequestAddMusician request)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if(request.Track != null)
                    {
                        var track = GetTrackWithName(request.Track.TrackName);
                        if(track == null)
                        {
                            _context.Add(request.Track);
                            _context.SaveChanges();
                        }
                    }
                    var Idtrack = GetTrackWithName(request.Track.TrackName).IdTrack;
                    var Musician = new Musician
                    {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Nickname = request.Nickname,
                    };
                    _context.Musicians.Add(Musician);
                    var MusicianTrack = new MusicianTrack
                    {
                        IdTrack = Idtrack,
                        IdMusician = _context.Musicians.Where(m => m.FirstName == Musician.FirstName && m.LastName == Musician.LastName).FirstOrDefault().IdMusician
                    };
                    _context.MusicianTracks.Add(MusicianTrack);
                    _context.SaveChanges();

                    transaction.Commit();
                }catch(Exception ex)
                {
                    transaction.Rollback();

                }
            }
        }

        public DTOResponseGetMusician getMusician(int id)
        {
            var musician = _context.Musicians.Include(m => m.MusicianTracks).FirstOrDefault(m => m.IdMusician == id);

            if (musician == null)
            {
                throw new Exception();
            }

            var tracks = _context.MusicianTracks.Where(m => m.IdMusician == id).Include(m => m.Track).Select(m => m.Track).ToList();

            var response = new DTOResponseGetMusician
            {
                Musician = musician,
                Tracks = tracks
            };
            return response;
        }

        public Track GetTrackWithName(string trackname)
        {
            return _context.Tracks.SingleOrDefault(m => m.TrackName.Equals(trackname));
    }
    }


    public interface IDBMusician
    {
        public DTOResponseGetMusician getMusician(int id);
        public void DTORequestAddMusician(DTORequestAddMusician request);
    }
}
