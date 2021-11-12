using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public string Genre { get; set; }
        public bool Valid { get; set; }
        public int Sales { get; set; }
        public int Year { get; set; }
        public string RecordLabel { get; set; }
        
    }
}
