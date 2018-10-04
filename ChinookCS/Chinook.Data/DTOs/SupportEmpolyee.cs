using Chinook.Data.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Data.DTOs
{
    public class SupportEmpolyee
    {
        public string name { get; set; }
        public int clientcount { get; set; }
        public List<PlayListCustomer> clientlist { get; set; }
    }
}
