using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel;  //ODS
using Chinook.Data.POCOs;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class TrackController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Track> Track_List()
        {
            using (var context = new ChinookContext())
            {
                return context.Tracks.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Track Track_Find(int trackid)
        {
            using (var context = new ChinookContext())
            {
                return context.Tracks.Find(trackid);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Track> Track_GetByAlbumId(int albumid)
        {
            using (var context = new ChinookContext())
            {
                var results = from aRowOn in context.Tracks
                              where aRowOn.AlbumId.HasValue
                              && aRowOn.AlbumId == albumid
                              select aRowOn;
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<TrackList> List_TracksForPlaylistSelection(string tracksby, int argid)
        {
            using (var context = new ChinookContext())
            {
                {
                    var results = from x in context.Tracks
                                  where tracksby.Equals("Artist") && x.Album.ArtistId.Equals(argid)
                                  || tracksby.Equals("Genre") && x.Genre.GenreId.Equals(argid)
                                  || tracksby.Equals("MediaType") && x.MediaType.MediaTypeId.Equals(argid)
                                  || tracksby.Equals("Album") && x.Album.AlbumId.Equals(argid)
                                  orderby x.Name
                                  select new TrackList
                                  {
                                      TrackID = x.TrackId,
                                      Name = x.Name,
                                      Title = x.Album.Title,
                                      MediaName = x.MediaType.Name,
                                      GenreName = x.Genre.Name,
                                      Composer = x.Composer,
                                      Milliseconds = x.Milliseconds,
                                      Bytes = x.Bytes == null ? x.Bytes : x.Bytes / 1024,
                                      UnitPrice = x.UnitPrice
                                  };
                    return results.ToList();
                }          
            }
        }//eom
    }
}

