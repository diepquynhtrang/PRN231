using System;
using System.Collections.Generic;

namespace Project_API.Models
{
    public partial class Table
    {
        public Table()
        {
            TableBookings = new HashSet<TableBooking>();
            TableFoods = new HashSet<TableFood>();
        }

        public int Id { get; set; }
        public int? Number { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? UpdatedUserId { get; set; }
        public byte? Status { get; set; }

        public virtual User? CreatedUser { get; set; }
        public virtual User? UpdatedUser { get; set; }
        public virtual ICollection<TableBooking> TableBookings { get; set; }
        public virtual ICollection<TableFood> TableFoods { get; set; }
    }
}
