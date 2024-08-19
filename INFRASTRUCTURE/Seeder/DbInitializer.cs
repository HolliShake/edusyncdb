using DOMAIN.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace INFRASTRUCTURE.Seeder;

public class DbInitializer
{
    private readonly ModelBuilder modelBuilder;

    public DbInitializer(ModelBuilder builder)
    {
        modelBuilder = builder;
    }

    public void Seed()
    {
        modelBuilder.Entity<AccessList>().HasData(
               new AccessList
               {
                   Id = 1,
                   Subject = "Auth",
                   IsGroup = true
               },
               new AccessList
               {
                   Id = 2,
                   Subject = "User",
                   IsGroup = true
               },
               new AccessList
               {
                   Id = 3,
                   Subject = "Student",
                   IsGroup = true
               },
               new AccessList
               {
                   Id = 4,
                   Subject = "Admin",
                   IsGroup = true
               },
               new AccessList
               {
                   Id = 5,
                   Subject = "SuperAdmin",
                   IsGroup = true
               }
        );

        modelBuilder.Entity<AccessListAction>().HasData(
            // Auth
            new AccessListAction
            {
                Id = 1,
                Action = "all",
                AccessListId = 1
            },
            new AccessListAction
            {
                Id = 2,
                Action = "read",
                AccessListId = 1
            },
            new AccessListAction
            {
                Id = 3,
                Action = "create",
                AccessListId = 1
            },
            new AccessListAction
            {
                Id = 4,
                Action = "update",
                AccessListId = 1
            },
            new AccessListAction
            {
                Id = 5,
                Action = "delete",
                AccessListId = 1
            },
            // User
            new AccessListAction
            {
                Id = 6,
                Action = "all",
                AccessListId = 2
            },
            new AccessListAction
            {
                Id = 7,
                Action = "read",
                AccessListId = 2
            },
            new AccessListAction
            {
                Id = 8,
                Action = "create",
                AccessListId = 2
            },
            new AccessListAction
            {
                Id = 9,
                Action = "update",
                AccessListId = 2
            },
            new AccessListAction
            {
                Id = 10,
                Action = "delete",
                AccessListId = 2
            },
            // Student
            new AccessListAction
            {
                Id = 11,
                Action = "all",
                AccessListId = 3
            },
            new AccessListAction
            {
                Id = 12,
                Action = "read",
                AccessListId = 3
            },
            new AccessListAction
            {
                Id = 13,
                Action = "create",
                AccessListId = 3
            },
            new AccessListAction
            {
                Id = 14,
                Action = "update",
                AccessListId = 3
            },
            new AccessListAction
            {
                Id = 15,
                Action = "delete",
                AccessListId = 3
            },
            // Admin
            new AccessListAction
            {
                Id = 16,
                Action = "all",
                AccessListId = 4
            },
            new AccessListAction
            {
                Id = 17,
                Action = "read",
                AccessListId = 4
            },
            new AccessListAction
            {
                Id = 18,
                Action = "create",
                AccessListId = 4
            },
            new AccessListAction
            {
                Id = 19,
                Action = "update",
                AccessListId = 4
            },
            new AccessListAction
            {
                Id = 20,
                Action = "delete",
                AccessListId = 4
            },
            // SuperAdmin
            new AccessListAction
            {
                Id = 21,
                Action = "all",
                AccessListId = 5
            },
            new AccessListAction
            {
                Id = 22,
                Action = "read",
                AccessListId = 5
            },
            new AccessListAction
            {
                Id = 23,
                Action = "create",
                AccessListId = 5
            },
            new AccessListAction
            {
                Id = 24,
                Action = "update",
                AccessListId = 5
            },
            new AccessListAction
            {
                Id = 25,
                Action = "delete",
                AccessListId = 5
            }
        );
    }

}