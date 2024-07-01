namespace Project_API.Models.DTO
{
    public class TableFoodDTO
    {
        //Input: int table number, List<int> food id, int booking id
        public int Id { get; set; }
        public int? TableId { get; set; }
        public List<int?> FoodIdList { get; set; }
        public int? FoodIdUpdate { get; set; }
        public int? BookingId { get; set; }
        public int? Status { get; set; }
    }
}
