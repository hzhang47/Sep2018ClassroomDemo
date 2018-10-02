using Chinook.Data.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Data.DTOs
{
    public class AlbumInfo
    {
        public string artist { get; set; }
        public string title { get; set; }
        public List<TracksInfo> song { get; set; }
    }
}
