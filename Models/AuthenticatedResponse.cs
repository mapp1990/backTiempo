namespace arq_micro_pru_tiempo.Models
{
    public class AuthenticatedResponse
    {
        public string? Token { get; set; }
        public User user { get; set; }
    }
}
