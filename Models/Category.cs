using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace AnimeMangaTrackerMAUI.Models
{
    [Table("Cattegory")]
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        [Unique]
        public string Name { get; set; }
    }
}
