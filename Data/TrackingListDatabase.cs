using SQLite;
using AnimeMangaTrackerMAUI.Models;

namespace AnimeMangaTrackerMAUI.Data
{
    public class TrackingListDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public TrackingListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
        }

       
        async Task Init()
        {
            await _database.CreateTableAsync<MediaItem>();
            await _database.CreateTableAsync<Category>();
 
        }

        // ------------------ MEDIA ITEM METHODS ------------------

        public async Task<List<MediaItem>> GetMediaItemsAsync()
        {
            await Init();
            return await _database.Table<MediaItem>().ToListAsync();
        }

        public async Task<MediaItem> GetMediaItemAsync(int id)
        {
            await Init();
            return await _database.Table<MediaItem>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<int> SaveMediaItemAsync(MediaItem item)
        {
            await Init();
            if (item.Id != 0)
            {
                return await _database.UpdateAsync(item);
            }
            else
            {
                return await _database.InsertAsync(item);
            }
        }

        public async Task<int> DeleteMediaItemAsync(MediaItem item)
        {
            await Init();
            return await _database.DeleteAsync(item);
        }

        // ------------------ CATEGORY METHODS ------------------

        public async Task<List<Category>> GetCategoriesAsync()
        {
            await Init();
            return await _database.Table<Category>().ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            await Init();
            return await _database.Table<Category>()
                            .Where(c => c.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<int> SaveCategoryAsync(Category category)
        {
            await Init();
            if (category.Id != 0)
            {
                return await _database.UpdateAsync(category);
            }
            else
            {
                return await _database.InsertAsync(category);
            }
        }

        public async Task<int> DeleteCategoryAsync(Category category)
        {
            await Init();
            return await _database.DeleteAsync(category);
        }
    }
}