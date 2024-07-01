namespace Project_API.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? Fullname { get; set; }
        public string? Phone { get; set; }
        public string? Gmail { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public int? Role { get; set; }
    }
}
