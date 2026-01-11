using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SQLiteNetExtensions.Attributes;


namespace AnimeMangaTrackerMAUI.Models
{
    [Table("MediaItems")]
    public class MediaItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Title { get; set; }
        public string Type { get; set; }
        public int TotalVolumes { get; set; }
        public int CategoryId { get; set; }
    }
}
