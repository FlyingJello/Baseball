namespace Baseball.Controllers.Dto
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Models.User ToModel()
        {
            return new Models.User {Username = Username};
        }

        public static User ToDto(Models.User user)
        {
            return new User {Username = user.Username};
        }
    }
}
