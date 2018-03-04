using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JWAppApi.DbEntities
{
    public partial class JWAppContext : DbContext
    {
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Congregation> Congregation { get; set; }
        public virtual DbSet<FieldServiceSymbol> FieldServiceSymbol { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonServicePrivilegeLink> PersonServicePrivilegeLink { get; set; }
        public virtual DbSet<ServicePrivilege> ServicePrivilege { get; set; }
        public virtual DbSet<Territory> Territory { get; set; }
        public virtual DbSet<TerritoryActivity> TerritoryActivity { get; set; }
        public virtual DbSet<TerritoryAddressLink> TerritoryAddressLink { get; set; }
        public virtual DbSet<TerritoryAssignment> TerritoryAssignment { get; set; }

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                 optionsBuilder.UseSqlServer(@"Connection String");
//             }
//         }

        public JWAppContext(DbContextOptions<JWAppContext> options): base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(117)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(((((((([Number]+isnull(' '+[PreDir],''))+' ')+[Street])+' ')+[Suffix])+isnull(' '+[PostDir],''))+isnull(', '+[Sec],''))+isnull(' '+[SecNumber],''))");

                entity.Property(e => e.AddressLine2)
                    .IsRequired()
                    .HasMaxLength(68)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(((isnull([City]+',','')+isnull(' '+[State],''))+isnull(' '+[Zip],''))+isnull('-'+[Zip4],''))");

                entity.Property(e => e.City)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.County)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CountyFp)
                    .HasColumnName("CountyFP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.GeoPrecision)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Number)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PostDir)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PreDir)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SecNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StateFp)
                    .HasColumnName("StateFP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Suffix)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Zip4).HasColumnType("char(4)");
            });

            modelBuilder.Entity<Congregation>(entity =>
            {
                entity.Property(e => e.CongregationId).HasColumnName("CongregationID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.CongregationEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CongregationName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CongregationNameLong)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CongregationPhoneNo)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Congregation)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Congregation_Address");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Congregation)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Congregation_Language");
            });

            modelBuilder.Entity<FieldServiceSymbol>(entity =>
            {
                entity.HasKey(e => e.FieldServiceSymbol1);

                entity.Property(e => e.FieldServiceSymbol1)
                    .HasColumnName("FieldServiceSymbol")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CongregationId).HasColumnName("CongregationID");

                entity.Property(e => e.FieldServiceSymbolDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Congregation)
                    .WithMany(p => p.FieldServiceSymbol)
                    .HasForeignKey(d => d.CongregationId)
                    .HasConstraintName("FK_FieldServiceSymbol_Congregation");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LanguageName)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.BaptismDate).HasColumnType("date");

                entity.Property(e => e.CongregationId).HasColumnName("CongregationID");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FormattedName)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(([FirstName]+' ')+[LastName])");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleInitial).HasColumnType("char(1)");

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Person_Address");

                entity.HasOne(d => d.Congregation)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.CongregationId)
                    .HasConstraintName("FK_Person_Congregation");
            });

            modelBuilder.Entity<PersonServicePrivilegeLink>(entity =>
            {
                entity.Property(e => e.PersonServicePrivilegeLinkId).HasColumnName("PersonServicePrivilegeLinkID");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.ServicePrivilegeId).HasColumnName("ServicePrivilegeID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonServicePrivilegeLink)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_PersonServicePrivilegeLink_Person");

                entity.HasOne(d => d.ServicePrivilege)
                    .WithMany(p => p.PersonServicePrivilegeLink)
                    .HasForeignKey(d => d.ServicePrivilegeId)
                    .HasConstraintName("FK_PersonServicePrivilegeLink_ServicePrivilege");
            });

            modelBuilder.Entity<ServicePrivilege>(entity =>
            {
                entity.Property(e => e.ServicePrivilegeId).HasColumnName("ServicePrivilegeID");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ServicePrivilegeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Territory>(entity =>
            {
                entity.Property(e => e.TerritoryId).HasColumnName("TerritoryID");

                entity.Property(e => e.AssignedOn).HasColumnType("datetime");

                entity.Property(e => e.CongregationId).HasColumnName("CongregationID");

                entity.Property(e => e.CurrentlyAssignedLong)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastPreached).HasColumnType("datetime");

                entity.Property(e => e.TerritoryDescription)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TerritoryLocation)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TerritoryMapLink)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UserAddedLong)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserModifiedLong)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Congregation)
                    .WithMany(p => p.Territory)
                    .HasForeignKey(d => d.CongregationId)
                    .HasConstraintName("FK_Territory_Congregation");
            });

            modelBuilder.Entity<TerritoryActivity>(entity =>
            {
                entity.HasKey(e => e.FieldServiceActivityId);

                entity.Property(e => e.FieldServiceActivityId).HasColumnName("FieldServiceActivityID");

                entity.Property(e => e.ActivityDate).HasColumnType("datetime");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.FieldServiceSymbol)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HouseholderFirstName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.HouseholderLastName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.HouseholderPhoneNumber)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UserAddedLong)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserModifiedLong)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.TerritoryActivity)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TerritoryActivity_Address");

                entity.HasOne(d => d.FieldServiceSymbolNavigation)
                    .WithMany(p => p.TerritoryActivity)
                    .HasForeignKey(d => d.FieldServiceSymbol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TerritoryActivity_FieldServiceSymbol");
            });

            modelBuilder.Entity<TerritoryAddressLink>(entity =>
            {
                entity.Property(e => e.TerritoryAddressLinkId).HasColumnName("TerritoryAddressLinkID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.HouseholderFirstName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.HouseholderLastName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.HouseholderPhoneNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.TerritoryId).HasColumnName("TerritoryID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.TerritoryAddressLink)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_TerritoryAddressLink_Address");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TerritoryAddressLink)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_TerritoryAddressLink_Person");

                entity.HasOne(d => d.Territory)
                    .WithMany(p => p.TerritoryAddressLink)
                    .HasForeignKey(d => d.TerritoryId)
                    .HasConstraintName("FK_TerritoryAddressLink_Territory");
            });

            modelBuilder.Entity<TerritoryAssignment>(entity =>
            {
                entity.Property(e => e.TerritoryAssignmentId).HasColumnName("TerritoryAssignmentID");

                entity.Property(e => e.AssignedDate).HasColumnType("datetime");

                entity.Property(e => e.AssignedToLong)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.ReturnedDate).HasColumnType("datetime");

                entity.Property(e => e.TerritoryId).HasColumnName("TerritoryID");

                entity.HasOne(d => d.Territory)
                    .WithMany(p => p.TerritoryAssignment)
                    .HasForeignKey(d => d.TerritoryId)
                    .HasConstraintName("FK_TerritoryAssignment_Territory");
            });
        }
    }
}
