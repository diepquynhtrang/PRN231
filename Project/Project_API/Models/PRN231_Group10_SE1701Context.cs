using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project_API.Models
{
    public partial class PRN231_Group10_SE1701Context : DbContext
    {
        public PRN231_Group10_SE1701Context()
        {
        }

        public PRN231_Group10_SE1701Context(DbContextOptions<PRN231_Group10_SE1701Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Food> Foods { get; set; } = null!;
        public virtual DbSet<Table> Tables { get; set; } = null!;
        public virtual DbSet<TableBooking> TableBookings { get; set; } = null!;
        public virtual DbSet<TableFood> TableFoods { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
.SetBasePath(Directory.GetCurrentDirectory())
.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyCnn"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("Bill");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("booked_time");

                entity.Property(e => e.BookedUserId).HasColumnName("booked_user_id");

                entity.Property(e => e.CreatedStaffId).HasColumnName("created_staff_id");

                entity.Property(e => e.PaidTime)
                    .HasColumnType("datetime")
                    .HasColumnName("paid_time");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");

                entity.Property(e => e.UpdatedStaffId).HasColumnName("updated_staff_id");

                entity.HasOne(d => d.BookedUser)
                    .WithMany(p => p.BillBookedUsers)
                    .HasForeignKey(d => d.BookedUserId)
                    .HasConstraintName("FK_Bill_User");

                entity.HasOne(d => d.CreatedStaff)
                    .WithMany(p => p.BillCreatedStaffs)
                    .HasForeignKey(d => d.CreatedStaffId)
                    .HasConstraintName("FK_Bill_User1");

                entity.HasOne(d => d.UpdatedStaff)
                    .WithMany(p => p.BillUpdatedStaffs)
                    .HasForeignKey(d => d.UpdatedStaffId)
                    .HasConstraintName("FK_Bill_User2");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookedUserId).HasColumnName("booked_user_id");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("created_time");

                entity.Property(e => e.CreatedUserId).HasColumnName("created_user_id");

                entity.Property(e => e.EatingTime)
                    .HasColumnType("datetime")
                    .HasColumnName("eating_time");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TotalNumberOfPeople).HasColumnName("total_number_of_people");

                entity.Property(e => e.TotalNumberOfTable).HasColumnName("total_number_of_table");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_time");

                entity.Property(e => e.UpdatedUserId).HasColumnName("updated_user_id");

                entity.HasOne(d => d.BookedUser)
                    .WithMany(p => p.BookingBookedUsers)
                    .HasForeignKey(d => d.BookedUserId)
                    .HasConstraintName("FK_Booking_User");

                entity.HasOne(d => d.CreatedUser)
                    .WithMany(p => p.BookingCreatedUsers)
                    .HasForeignKey(d => d.CreatedUserId)
                    .HasConstraintName("FK_Booking_User1");

                entity.HasOne(d => d.UpdatedUser)
                    .WithMany(p => p.BookingUpdatedUsers)
                    .HasForeignKey(d => d.UpdatedUserId)
                    .HasConstraintName("FK_Booking_User2");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("created_time");

                entity.Property(e => e.CreatedUserId).HasColumnName("created_user_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_time");

                entity.Property(e => e.UpdatedUserId).HasColumnName("updated_user_id");

                entity.HasOne(d => d.CreatedUser)
                    .WithMany(p => p.CategoryCreatedUsers)
                    .HasForeignKey(d => d.CreatedUserId)
                    .HasConstraintName("FK_Category_User");

                entity.HasOne(d => d.UpdatedUser)
                    .WithMany(p => p.CategoryUpdatedUsers)
                    .HasForeignKey(d => d.UpdatedUserId)
                    .HasConstraintName("FK_Category_User1");
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("Food");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("created_time");

                entity.Property(e => e.CreatedUserId).HasColumnName("created_user_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_time");

                entity.Property(e => e.UpdatedUserId).HasColumnName("updated_user_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Foods)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Food_Category");

                entity.HasOne(d => d.CreatedUser)
                    .WithMany(p => p.FoodCreatedUsers)
                    .HasForeignKey(d => d.CreatedUserId)
                    .HasConstraintName("FK_Food_User");

                entity.HasOne(d => d.UpdatedUser)
                    .WithMany(p => p.FoodUpdatedUsers)
                    .HasForeignKey(d => d.UpdatedUserId)
                    .HasConstraintName("FK_Food_User1");
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.ToTable("Table");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("created_time");

                entity.Property(e => e.CreatedUserId).HasColumnName("created_user_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_time");

                entity.Property(e => e.UpdatedUserId).HasColumnName("updated_user_id");

                entity.HasOne(d => d.CreatedUser)
                    .WithMany(p => p.TableCreatedUsers)
                    .HasForeignKey(d => d.CreatedUserId)
                    .HasConstraintName("FK_Table_User");

                entity.HasOne(d => d.UpdatedUser)
                    .WithMany(p => p.TableUpdatedUsers)
                    .HasForeignKey(d => d.UpdatedUserId)
                    .HasConstraintName("FK_Table_User1");
            });

            modelBuilder.Entity<TableBooking>(entity =>
            {
                entity.ToTable("Table_Booking");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TableId).HasColumnName("table_id");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.TableBookings)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK_Table_Booking_Booking");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.TableBookings)
                    .HasForeignKey(d => d.TableId)
                    .HasConstraintName("FK_Table_Booking_Table");
            });

            modelBuilder.Entity<TableFood>(entity =>
            {
                entity.ToTable("Table_Food");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.FoodId).HasColumnName("food_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TableId).HasColumnName("table_id");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.TableFoods)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK_Table_Food_Booking");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.TableFoods)
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK_Table_Food_Food");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.TableFoods)
                    .HasForeignKey(d => d.TableId)
                    .HasConstraintName("FK_Table_Food_Table");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .HasColumnName("address");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("created_time");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(200)
                    .HasColumnName("fullname");

                entity.Property(e => e.Gmail)
                    .HasMaxLength(200)
                    .HasColumnName("gmail");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_time");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
