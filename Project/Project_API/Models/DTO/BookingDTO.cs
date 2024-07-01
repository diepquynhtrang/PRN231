namespace Project_API.Models.DTO
{
    public class BookingDTO
    {
        //Input: string customer phone, string name, datetime eating time,
        //int total people, int total table

        public int Id { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerName { get; set; }
        public DateTime? EatingTime { get; set; }
        public int? TotalNumberOfPeople { get; set; }
        public int? TotalNumberOfTable { get; set; }
        public List<int>? TableList { get; set; }

    }

}
