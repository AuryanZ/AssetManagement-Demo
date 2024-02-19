namespace AssetManagement.Dtos
{
    public class AccountUpdateDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime LastLogin { get; set; }
    }
}