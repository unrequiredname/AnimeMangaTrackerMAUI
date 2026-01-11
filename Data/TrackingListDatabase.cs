using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;
using AnimeMangaTrackerMAUI.Models;

namespace AnimeMangaTrackerMAUI.Data
{ 
    public class TrackingListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public TrackingListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);

            _database.CreateTableAsync<MediaItem>().Wait();
            _database.CreateTableAsync<Category>().Wait();
            _database.CreateTableAsync<UserTracker>().Wait();
            _database.CreateTableAsync<Review>().Wait();

        }

        // ------------------MEDIA ITEM METHODS ------------------

        public Task<List<MediaItem>> GetMediaItemsAsync()
        {
            return _database.Table<MediaItem>().ToListAsync();
        }
        public Task<MediaItem> GetMediaItemAsync(int id)
        {
            return _database.Table<MediaItem>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveMediaItemAsync(MediaItem item)
        {
            if (item.Id != 0)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }

        public Task<int> DeleteMediaItemAsync(MediaItem item)
        {
            return _database.DeleteAsync(item);
        }



        // ------------------CATEGORY METHODS ------------------
        public Task<List<Category>> GetCategoriesAsync()
        {
            return _database.Table<Category>().ToListAsync();
        }

        public Task<Category> GetCategoryAsync(int id)
        {
            return _database.Table<Category>()
                            .Where(c => c.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveCategoryAsync(Category category)
        {
            if (category.Id != 0)
            {
                return _database.UpdateAsync(category);
            }
            else
            {
                return _database.InsertAsync(category);
            }
        }

        public Task<int> DeleteCategoryAsync(Category category)
        {
            return _database.DeleteAsync(category);
        }

        
    }
}