namespace LystfiskerPortalen.Domain.Models
{
    public class Profile
    {
        public int Followers { get; set; }
        public int Following { get; set; }
        public string Picture { get; set; }

        public string Bio { get; set; }
        public string Feed { get; set; }
    }
}
