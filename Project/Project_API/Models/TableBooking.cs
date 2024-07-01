using System;
using System.Collections.Generic;

namespace Project_API.Models
{
    public partial class TableBooking
    {
        public int Id { get; set; }
        public int? TableId { get; set; }
        public int? BookingId { get; set; }
        public int? Status { get; set; }

        public virtual Booking? Booking { get; set; }
        public virtual Table? Table { get; set; }
    }
}
