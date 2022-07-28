﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Washyn.Domain.Data
{
    public class DbMigrationService : ITransientDependency
        // , IDbSchemaMigrator
    {
        private readonly IEnumerable<IDbSchemaMigrator> _schemaMigrators;
        private readonly IDataSeeder _dataSeeder;
        public ILogger<DbMigrationService> Logger;
        
        public DbMigrationService(IEnumerable<IDbSchemaMigrator> schemaMigrators,
            IDataSeeder dataSeeder)
        {
            _schemaMigrators = schemaMigrators;
            _dataSeeder = dataSeeder;
            Logger = NullLogger<DbMigrationService>.Instance;
        }
        
        public async Task MigrateAsync()
        {
            var initialMigrationAdded = AddInitialMigrationIfNotExist();
            
            if (initialMigrationAdded)
            {
                return;
            }
            
            Logger.LogInformation("Started database migrations...");
            
            await MigrateDatabaseSchemaAsync();
            await SeedDataAsync();
            
            Logger.LogInformation("Successfully completed all database migrations.");
            Logger.LogInformation("You can safely end this process...");
        }
        
        private async Task MigrateDatabaseSchemaAsync()
        {
            Logger.LogInformation(
                $"Migrating schema for host database...");

            foreach (var migrator in _schemaMigrators)
            {
                await migrator.MigrateAsync();
            }
        }
        
        private async Task SeedDataAsync()
        {
            Logger.LogInformation($"Executing {("host")} database seed...");
            await _dataSeeder.SeedAsync(new DataSeedContext());
        }

        
        private bool AddInitialMigrationIfNotExist()
        {
            try
            {
                if (!DbMigrationsProjectExists())
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            try
            {
                if (!MigrationsFolderExists())
                {
                    AddInitialMigration();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Logger.LogWarning("Couldn't determinate if any migrations exist : " + e.Message);
                return false;
            }
        }
        
        private bool DbMigrationsProjectExists()
        {
            var dbMigrationsProjectFolder = GetEntityFrameworkCoreProjectFolderPath();

            return dbMigrationsProjectFolder != null;
        }

        private bool MigrationsFolderExists()
        {
            var dbMigrationsProjectFolder = GetEntityFrameworkCoreProjectFolderPath();

            return Directory.Exists(Path.Combine(dbMigrationsProjectFolder, "Migrations"));
        }

        private void AddInitialMigration()
        {
            Logger.LogInformation("Creating initial migration...");

            string argumentPrefix;
            string fileName;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                argumentPrefix = "-c";
                fileName = "/bin/bash";
            }
            else
            {
                argumentPrefix = "/C";
                fileName = "cmd.exe";
            }

            var procStartInfo = new ProcessStartInfo(fileName,
                $"{argumentPrefix} \"abp create-migration-and-run-migrator \"{GetEntityFrameworkCoreProjectFolderPath()}\"\""
            );

            try
            {
                Process.Start(procStartInfo);
            }
            catch (Exception)
            {
                throw new Exception("Couldn't run ABP CLI...");
            }
        }
        
        private string GetEntityFrameworkCoreProjectFolderPath()
        {
            var slnDirectoryPath = GetSolutionDirectoryPath();

            if (slnDirectoryPath == null)
            {
                throw new Exception("Solution folder not found!");
            }

            var srcDirectoryPath = Path.Combine(slnDirectoryPath, "src");

            return Directory.GetDirectories(srcDirectoryPath)
                .FirstOrDefault(d => d.EndsWith(".EntityFrameworkCore"));
        }
        
        private string GetSolutionDirectoryPath()
        {
            var currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());

            while (Directory.GetParent(currentDirectory.FullName) != null)
            {
                currentDirectory = Directory.GetParent(currentDirectory.FullName);

                if (Directory.GetFiles(currentDirectory.FullName).FirstOrDefault(f => f.EndsWith(".sln")) != null)
                {
                    return currentDirectory.FullName;
                }
            }

            return null;
        }
    }
}