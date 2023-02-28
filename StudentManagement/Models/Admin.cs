namespace StudentManagement.Models
{
    public class Admin
    {
        public string? email { get; set; } = "admin@gmail.com";
        public byte[]? passwordhash { get; set; }
        public byte[]? passwordsalt { get; set; }
    }
}
