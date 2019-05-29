namespace CrmManager.CrmDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using CrmManager;
    using System.Data.Entity.Infrastructure;
    using System.Data.SQLite;
    using System.Data.SQLite.EF6;
    using System.IO;
    using System.Windows.Forms;

  
    static class Provider
    {

        public static SQLiteConnection CreateConnection(string path)
        {
            var builder = (SQLiteConnectionStringBuilder)SQLiteProviderFactory.Instance.CreateConnectionStringBuilder();
            if (builder == null) return null;

            builder.DataSource = path;
            builder.FailIfMissing = false;
            
           return new SQLiteConnection(builder.ToString());

        }
    }

    public partial class Model1 : DbContext
    {
        #region Commit
        //public Model1()
        //    : base("name=CrmDBModel")
        //{

        //}

        //  public Model1() : base (Provider.CreateConnection(SettingFilePath.dbConnectionName), false)
        #endregion
        public  Model1() : base(Provider.CreateConnection(PathSettings.Default.dbConnectionName), false)
        {
            

        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<DefCode> DefCodes { get; set; }
        public virtual DbSet<Operator> Operators { get; set; }
        public virtual DbSet<PhoneAfterCall> PhoneAfterCalls { get; set; }
        public string DataBaseConnectionString { get; private set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            if (!File.Exists(PathSettings.Default.dbConnectionName))
            {
                MessageBox.Show("Файл отсутствует");

                var initializer = new SQLite.CodeFirst.SqliteDropCreateDatabaseAlways<Model1>(modelBuilder);
                Database.SetInitializer(initializer);
                base.OnModelCreating(modelBuilder);
            }
            #region Commit2
            //modelBuilder.Entity<City>()
            //    .Property(e => e.id_city);
            //modelBuilder.Entity<City>()
            //    .Property(e => e.Name)
            //    .IsUnicode(false);
            //modelBuilder.Entity<City>()

            //  .Property(e => e.id_crm_city);
            //modelBuilder.Entity<DefCode>()
            //   .Property(e => e.id_city);
            //modelBuilder.Entity<DefCode>()
            //   .Property(e => e.id_operator);
            //modelBuilder.Entity<DefCode>()
            //   .Property(e => e.Name)
            //   .IsUnicode(false);

            //modelBuilder.Entity<Operator>()
            //  .Property(e => e.id_operator);
            //modelBuilder.Entity<Operator>()
            //   .Property(e => e.id_crm_operator);
            //modelBuilder.Entity<Operator>()
            //   .Property(e => e.Name)
            //   .IsUnicode(false);

            //modelBuilder.Entity<PhoneAfterCall>()
            //   .Property(e => e.id_number);
            //modelBuilder.Entity<PhoneAfterCall>()
            //   .Property(e => e.last_attempt);
            //modelBuilder.Entity<PhoneAfterCall>()
            //   .Property(e => e.manager)
            //   .IsUnicode(false);
            //modelBuilder.Entity<PhoneAfterCall>()
            //    .Property(e => e.notice)
            //    .IsUnicode(false);
            //modelBuilder.Entity<PhoneAfterCall>()
            //   .Property(e => e.result);
            //modelBuilder.Entity<PhoneAfterCall>()
            //   .Property(e => e.call_duration);           
            //modelBuilder.Entity<PhoneAfterCall>()
            //   .Property(e => e.condition)
            //   .IsUnicode(false);
            #endregion
        }
    }
}
