using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class SessionList
    {
        public string Color { get; set; }
        public int ID { get; set; }
        public Film Film { get; set; }

        public DateTime StartingDate { get; set; }
    }
}
