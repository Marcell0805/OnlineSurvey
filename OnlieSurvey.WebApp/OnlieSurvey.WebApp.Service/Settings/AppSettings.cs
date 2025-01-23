namespace OnlineSurvey.WebApp.Service.Settings
{
    public class AppSettings
    {
        public ApplicationDetail ApplicationDetail { get; set; }
    }
    public class ApplicationDetail
    {
        public string ApiBaseUrl { get; set; }
        public string ContactWebsite { get; set; }
    }
}
