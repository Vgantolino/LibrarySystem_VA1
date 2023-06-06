using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LibrarySystem_VA.Authorization.Roles;
using LibrarySystem_VA.Authorization.Users;
using LibrarySystem_VA.MultiTenancy;
using LibrarySystem_VA.Entities;

namespace LibrarySystem_VA.EntityFrameworkCore
{
    public class LibrarySystem_VADbContext : AbpZeroDbContext<Tenant, Role, User, LibrarySystem_VADbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public LibrarySystem_VADbContext(DbContextOptions<LibrarySystem_VADbContext> options)
            : base(options)
        {
        }

        //*ADDED-Table/Entity/TableName*//Departments
        public virtual DbSet<Department> Department { get; set; }
        //*END*//


        //Students
        public virtual DbSet<Student> Students { get; set; }

        //Book Category
        public virtual DbSet<BookCategory> BookCategories { get; set; }

        //Books
        public virtual DbSet<Book> Books { get; set; }

        //Authors
        public virtual DbSet<Author> Authors { get; set; }

        //Borrowers
        public virtual DbSet<Borrower> Borrowers { get; set; }

    }
}
