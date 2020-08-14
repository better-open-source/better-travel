﻿using BetterTravel.Common.Configurations;
using Microsoft.EntityFrameworkCore.Design;

namespace BetterTravel.DataAccess.EF
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        private const string ConnectionString =
            "Server=localhost,1433;Database=BetterTravel;User=SA;Password=Your_password123;";
        
        public AppDbContext CreateDbContext(string[] args)
        {
            var connectionString = new DbConnectionString(ConnectionString);
            var eventDispatcher = new EventDispatcher(new MessageBus(new Bus()));

            return new AppDbContext(eventDispatcher, connectionString);
        }
    }
}