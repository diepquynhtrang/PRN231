using System;
using System.Collections.Generic;

namespace Project_API.Models
{
    public partial class Bill
    {
        public int Id { get; set; }
        public int? BookedUserId { get; set; }
        public double? TotalPrice { get; set; }
        public DateTime? BookedTime { get; set; }
        public int? CreatedStaffId { get; set; }
        public DateTime? PaidTime { get; set; }
        public int? UpdatedStaffId { get; set; }
        public byte? Status { get; set; }

        public virtual User? BookedUser { get; set; }
        public virtual User? CreatedStaff { get; set; }
        public virtual User? UpdatedStaff { get; set; }
    }
}
