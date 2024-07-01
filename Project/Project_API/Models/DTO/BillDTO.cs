namespace Project_API.Models.DTO
{
    public class BillDTO
    {
        public int Id { get; set; }
        public int? BookedUserId { get; set; }
        public double? TotalPrice { get; set; }
        public DateTime? BookedTime { get; set; }
        public int? CreatedStaffId { get; set; }
        public DateTime? PaidTime { get; set; }
        public int? UpdatedStaffId { get; set; }
        public byte? Status { get; set; }
    }
}
