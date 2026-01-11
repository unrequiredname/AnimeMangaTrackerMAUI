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

        [Indexed]
        public int MediaItemId { get; set; }
        
        public string UserEmail { get; set; }
        public string Comment { get; set; }
        private int _rating;
        public int Rating
        {
            get => _rating;
            set => _rating = Math.Clamp(value, 1, 10);
        }
        public double StarRating { get; set; }
    }

    internal class cite_startAttribute : Attribute
    {
    }
}
