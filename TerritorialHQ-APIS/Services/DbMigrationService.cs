﻿using Microsoft.EntityFrameworkCore;
using TerritorialHQ_APIS.Models.Data;

namespace TerritorialHQ_APIS.Services
{
    public static class DbMigrationService
    {
        public static void MigrationInitialization(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<ApplicationDbContext>()?.Database.Migrate();
            }
        }
    }
}
