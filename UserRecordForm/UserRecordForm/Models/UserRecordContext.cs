namespace UserRecordForm.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class UserRecordContext : DbContext
    {
        public UserRecordContext()
            : base("name=UserRecordEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<UserRecord> UserRecord { get; set; }
    }
}
