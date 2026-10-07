using System.ComponentModel.DataAnnotations;

namespace Honda_Project.ViewsModels.Accounts
{
    public class AccountProfile
    {
        public int UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
