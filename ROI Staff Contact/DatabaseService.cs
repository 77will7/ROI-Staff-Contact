// DatabaseService.cs
using ROI_Staff_Contact;
using SQLite;
using System.IO;

public class DatabaseService
{
    SQLiteAsyncConnection _database;

    public DatabaseService()
    {
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Staff.db");
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Staff>().Wait();
    }

    #region C R U D Operations
    public async Task AddStaffAsync(Staff staff)
    {
        await _database.InsertAsync(staff);
    }

    public async Task<List<Staff>> GetStaffAsync()
    {
        return await _database.Table<Staff>().ToListAsync();
    }
    public async Task UpdateStaffAsync(Staff staff)
    {
        await _database.UpdateAsync(staff);
    }

    public async Task DeleteStaffAsync(Staff staff)
    {
        await _database.DeleteAsync(staff);
    }
    #endregion

}
