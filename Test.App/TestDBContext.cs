using Microsoft.EntityFrameworkCore;
using Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection.Metadata;
using Windows.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using EntityFramework.Exceptions.Sqlite;

namespace Test.App
{
    public class TestDBContext : DbContext
    {                
        public DbSet<Player> Players { get; set; }
        public DbSet<Client> Clients { get; set; }

        public DbSet<TestModel> Tests { get; set; }
        
        public DbSet<Address> Addresses { get; set; }
        
        public DbSet<Suburb> Suburbs { get; set; }        
        
       
        public TestDBContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Debug.WriteLine("OnConfiguring Called");
            optionsBuilder.UseExceptionProcessor();            
            optionsBuilder.UseSqlite("Data Source=database.db");
            optionsBuilder.EnableSensitiveDataLogging(true);                       
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SetupContext(this.Database.IsSqlite()); // Identify if we are using a SQLite database            
            

            //Table Per Type TPT
            //https://www.learnentityframeworkcore.com/inheritance/table-per-type
            modelBuilder.Entity<Person>().UseTptMappingStrategy();            

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                //https://blog.dangl.me/archive/handling-datetimeoffset-in-sqlite-with-entity-framework-core/
                // SQLite does not have proper support for DateTimeOffset via Entity Framework Core, see the limitations
                // here: https://docs.microsoft.com/en-us/ef/core/providers/sqlite/limitations#query-limitations
                // To work around this, when the Sqlite database provider is used, all model properties of type DateTimeOffset
                // use the DateTimeOffsetToBinaryConverter
                // Based on: https://github.com/aspnet/EntityFrameworkCore/issues/10784#issuecomment-415769754
                // This only supports millisecond precision, but should be sufficient for most use cases.
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(DateTimeOffset)
                                                                                || p.PropertyType == typeof(DateTimeOffset?));
                    foreach (var property in properties)
                    {
                        modelBuilder
                            .Entity(entityType.Name)
                            .Property(property.Name)
                            .HasConversion(new DateTimeOffsetToBinaryConverter());
                    }
                }
            }
        }       
    }

    public static class DbSetExtensions
    {
        public static EntityEntry<T> AddIfNotExists<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null) where T : class, new()
        {
            var exists = predicate != null ? dbSet.Any(predicate) : dbSet.Any();
            return !exists ? dbSet.Add(entity) : null;
        }
    }

    public static class ContextSetup
    {
        public static void SetupContext(this ModelBuilder modelBuilder, bool isSQLite)
        {
            // Model building ...

            // Handle datetimes in SQLite src: https://blog.dangl.me/archive/handling-datetimeoffset-in-sqlite-with-entity-framework-core/
            if (isSQLite) // We found this in Context.cs
            {
                // SQLite does not have proper support for DateTimeOffset via Entity Framework Core, see the limitations
                // here: https://docs.microsoft.com/en-us/ef/core/providers/sqlite/limitations#query-limitations
                // To work around this, when the Sqlite database provider is used, all model properties of type DateTimeOffset
                // use the DateTimeOffsetToBinaryConverter
                // Based on: https://github.com/aspnet/EntityFrameworkCore/issues/10784#issuecomment-415769754
                // This only supports millisecond precision, but should be sufficient for most use cases.
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(DateTimeOffset)
                                                                                || p.PropertyType == typeof(DateTimeOffset?));
                    foreach (var property in properties)
                    {
                        modelBuilder
                            .Entity(entityType.Name)
                            .Property(property.Name)
                            .HasConversion(new DateTimeOffsetToBinaryConverter()); // The converter!
                    }
                }
            }
        }
    }
}
