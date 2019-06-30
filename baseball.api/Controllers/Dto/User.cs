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
    }
}
