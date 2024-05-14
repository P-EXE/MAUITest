﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUITest
{
    public class TaskDatabase // Change this line to make the class public
    {
        readonly SQLiteAsyncConnection _database;

        public TaskDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TaskItem>().Wait();
        }

        public Task<List<TaskItem>> GetTasksAsync()
        {
            return _database.Table<TaskItem>().ToListAsync();
        }

        public Task<TaskItem> GetTaskAsync(int id)
        {
            return _database.Table<TaskItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveTaskAsync(TaskItem task)
        {
            if (task.ID != 0)
            {
                return _database.UpdateAsync(task);
            }
            else
            {
                return _database.InsertAsync(task);
            }
        }

        public Task<int> DeleteTaskAsync(TaskItem task)
        {
            return _database.DeleteAsync(task);
        }
    }
}