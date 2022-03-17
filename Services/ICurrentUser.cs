namespace MovieShopAPI.Services
{
    public interface ICurrentUser
    {
        bool IsAuthenticated { get; }
        int UserId { get; }
        string Email { get; }
        string FirstName { get; }
        String LastName { get; }    
        bool IsAdmin { get; }   
        List<string> Roles { get; }
        string IpAdress { get; }
    }
}
