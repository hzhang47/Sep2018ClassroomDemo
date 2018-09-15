using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using ChinookSystem.DAL;
#endregion

namespace ChinookSystem.BLL
{
    public class AlbumController
    {
        [DataObject]
        public class ArtistController
        {
            [DataObjectMethod(DataObjectMethodType.Select, false)]
            public List<Album> Album_List()
            {
                using (var context = new ChinookContext())
                {
                    return context.Albums.ToList();
                }
            }

            [DataObjectMethod(DataObjectMethodType.Select, false)]
            public Album Album_GetByAlbumID(int albumid)
            {
                using (var context = new ChinookContext())
                {
                    return context.Albums.Find(albumid);
                }
            }

            public List<Album> Album_GetByArtistID(int artistid)
            {
                using (var context = new ChinookContext())
                {
                    var results = from arowon in context.Albums
                                  where arowon.ArtistId.Equals(artistid)
                                  select arowon;
                    return results.ToList();    
                }
            }
        }
    }
}
