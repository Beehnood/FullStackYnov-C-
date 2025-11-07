namespace MonHttpCs.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public User() { }

        public User(int id, string name, int age, string email = "")
        {
            Id = id;
            Name = name;
            Age = age;
            Email = email;
        }
    }
}