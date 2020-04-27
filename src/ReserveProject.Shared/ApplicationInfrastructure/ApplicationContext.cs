namespace ReserveProject.Shared.ApplicationInfrastructure
{
    public class ApplicationContext
    {
        public ApplicationContext(string clientIpAddress)
        {
            ClientIpAddress = clientIpAddress;
        }

        public string ClientIpAddress { get; set; }

        public int CurrentEmployeeId { get; set; } = 1;
    }
}