namespace PnP.Data.BindingModels
{
    public class RegisterBindingModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IdNumber { get; set; }

        public bool IsSubscribed { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public int IdentificationTypeId { get; set; }
        public string Role { get; set; }
    }

    public class LoginBindingModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
