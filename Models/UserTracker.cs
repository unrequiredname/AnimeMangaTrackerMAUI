using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace AnimeMangaTrackerMAUI.Models
{
    public class UserTracker
    {
        public int Id { get; set; }
        public int MediaItemId { get; set; }
        public MediaItem MediaItem { get; set; }
        public string UserEmail { get; set; }
        public int CurrentProgress { get; set; } // episodul sau capitolul la care a ajuns utilizatorul
        public string Status { get; set; }//daca l-a terminat, l-a inceput, l-a abandonat 
    }
}
