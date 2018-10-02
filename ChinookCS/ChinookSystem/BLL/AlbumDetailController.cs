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
using Chinook.Data.DTOs;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class AlbumDetailController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<AlbumInfo> Album_GetAlbumDetail()
        {
            using (var context = new ChinookContext())
            {
                var results10 = from x in context.Albums
                                where x.Tracks.Count() > 24
                                select new AlbumInfo
                                {
                                    artist = x.Artist.Name,
                                    title = x.Title,
                                    song = (from y in x.Tracks
                                            select new TracksInfo
                                            {
                                                name = y.Name,
                                                length = y.Milliseconds / 60000 + ":" + (y.Milliseconds % 60000 / 1000)
                                            }).ToList()
                                };
                return results10.ToList();
            }
        }
    }
}
