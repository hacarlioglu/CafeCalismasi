using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Amsterdam
{
    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<tblCategory> tblCategory { get; set; }
        public virtual DbSet<tblInfo> tblInfo { get; set; }
        public virtual DbSet<tblLog> tblLog { get; set; }
        public virtual DbSet<tblMail> tblMail { get; set; }
        public virtual DbSet<tblProduct> tblProduct { get; set; }
        public virtual DbSet<tblUser> tblUser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblCategory>()
                .HasMany(e => e.tblProducts)
                .WithOptional(e => e.tblCategory)
                .HasForeignKey(e => e.CategoryNo);

            modelBuilder.Entity<tblInfo>()
                .Property(e => e.Adress)
                .IsUnicode(false);

            modelBuilder.Entity<tblInfo>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<tblInfo>()
                .Property(e => e.Mail)
                .IsUnicode(false);

            modelBuilder.Entity<tblInfo>()
                .Property(e => e.Ilce)
                .IsUnicode(false);

            modelBuilder.Entity<tblInfo>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .HasMany(e => e.tblLogs)
                .WithOptional(e => e.tblUser)
                .HasForeignKey(e => e.UserNo);
        }
    }
}
