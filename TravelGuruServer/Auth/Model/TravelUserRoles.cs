namespace TravelGuruServer.Auth.Model
{
    public class TravelUserRoles
    {

        public const string Admin = nameof(Admin);
        public const string Moderator = nameof(Moderator);
        public const string TravellerUser = nameof(TravellerUser);


        public static readonly IReadOnlyCollection<string> All = new[] { Admin, Moderator, TravellerUser };

    }
}
