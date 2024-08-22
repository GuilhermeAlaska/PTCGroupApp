namespace Api.Configs
{
    public static class NotificationConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
        }
    }
}