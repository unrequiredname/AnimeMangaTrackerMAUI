using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace AnimeMangaTrackerMAUI.Models
{
    public class Review
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int MediaItemId { get; set; }
        [cite_start]
        [Range(1, 10, ErrorMessage = "Rating-ul trebuie să fie între 1 și 10")]
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string UserEmail { get; set; }
        public int StarRating { get; internal set; }
    }

    internal class cite_startAttribute : Attribute
    {
    }
}
