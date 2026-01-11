using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace AnimeMangaTrackerMAUI.Models
{
    public class MediaItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Titlul este obligatoriu!")]
        public string Title { get; set; } = string.Empty;
        public string? Type { get; set; }
        public int TotalVolumes { get; set; }

        [ForeignKey(typeof(Category))]
        public int? CategoryId { get; set; }

        
        [ManyToOne]
        public virtual Category? Category { get; set; }


        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Review>? Reviews { get; set; }
    }
}
