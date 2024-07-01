using System;
using System.Collections.Generic;

namespace Project_API.Models
{
    public partial class User
    {
        public User()
        {
            BillBookedUsers = new HashSet<Bill>();
            BillCreatedStaffs = new HashSet<Bill>();
            BillUpdatedStaffs = new HashSet<Bill>();
            BookingBookedUsers = new HashSet<Booking>();
            BookingCreatedUsers = new HashSet<Booking>();
            BookingUpdatedUsers = new HashSet<Booking>();
            CategoryCreatedUsers = new HashSet<Category>();
            CategoryUpdatedUsers = new HashSet<Category>();
            FoodCreatedUsers = new HashSet<Food>();
            FoodUpdatedUsers = new HashSet<Food>();
            TableCreatedUsers = new HashSet<Table>();
            TableUpdatedUsers = new HashSet<Table>();
        }

        public int Id { get; set; }
        public string? Fullname { get; set; }
        public string? Phone { get; set; }
        public string? Gmail { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public int? Role { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public byte? Status { get; set; }

        public virtual ICollection<Bill> BillBookedUsers { get; set; }
        public virtual ICollection<Bill> BillCreatedStaffs { get; set; }
        public virtual ICollection<Bill> BillUpdatedStaffs { get; set; }
        public virtual ICollection<Booking> BookingBookedUsers { get; set; }
        public virtual ICollection<Booking> BookingCreatedUsers { get; set; }
        public virtual ICollection<Booking> BookingUpdatedUsers { get; set; }
        public virtual ICollection<Category> CategoryCreatedUsers { get; set; }
        public virtual ICollection<Category> CategoryUpdatedUsers { get; set; }
        public virtual ICollection<Food> FoodCreatedUsers { get; set; }
        public virtual ICollection<Food> FoodUpdatedUsers { get; set; }
        public virtual ICollection<Table> TableCreatedUsers { get; set; }
        public virtual ICollection<Table> TableUpdatedUsers { get; set; }
    }
}
