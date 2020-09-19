namespace MiniProjekti2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ToDoDB : DbContext
    {
        public ToDoDB()
            : base("name=ToDoDBs")
        {
        }

        public virtual DbSet<TaskInfo> TaskInfoes { get; set; }
        public virtual DbSet<UserInfo> UserInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskInfo>()
                .Property(e => e.TaskName)
                .IsUnicode(false);

            modelBuilder.Entity<TaskInfo>()
                .Property(e => e.TaskDesc)
                .IsUnicode(false);

            modelBuilder.Entity<TaskInfo>()
                .Property(e => e.LocationData)
                .IsUnicode(false);

            modelBuilder.Entity<TaskInfo>()
                .Property(e => e.Picture)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.NickName)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.PassW)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .HasMany(e => e.TaskInfoes)
                .WithRequired(e => e.UserInfo)
                .WillCascadeOnDelete(false);
        }
    }
}
