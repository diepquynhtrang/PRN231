using System;
using System.Collections.Generic;

namespace Project_API.Models
{
    public partial class Food
    {
        public Food()
        {
            TableFoods = new HashSet<TableFood>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? UpdatedUserId { get; set; }
        public byte? Status { get; set; }

        public virtual Category? Category { get; set; }
        public virtual User? CreatedUser { get; set; }
        public virtual User? UpdatedUser { get; set; }
        public virtual ICollection<TableFood> TableFoods { get; set; }
    }
}
