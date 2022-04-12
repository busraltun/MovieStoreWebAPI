namespace MovieStore.WebAPI.Authentication
{
    public interface IJWTAuthenticationManager
    {
        string Authenticate(string username, string password);
    }

}
