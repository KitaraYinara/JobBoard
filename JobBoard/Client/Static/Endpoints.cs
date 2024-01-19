namespace JobBoard.Client.Static
{
    public class Endpoints
    {
        public static readonly string Prefix = "api";

        public static readonly string AdminsEndpoint = $"{Prefix}/admins";
        public static readonly string ApplicantsEndpoint = $"{Prefix}/applicants";
        public static readonly string CompaniesEndpoint = $"{Prefix}/companies";
        public static readonly string EmployersEndpoint = $"{Prefix}/employers";
        public static readonly string IndustriesEndpoint = $"{Prefix}/industries";
        public static readonly string JobsEndpoint = $"{Prefix}/jobs";
        public static readonly string JobApplicationsEndpoint = $"{Prefix}/jobapplications";
        public static readonly string MessagesEndpoint = $"{Prefix}/messages";
        public static readonly string SearchesEndpoint = $"{Prefix}/searches";
    }
}
