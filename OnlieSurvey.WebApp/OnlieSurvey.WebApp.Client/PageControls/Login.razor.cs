using Microsoft.AspNetCore.Components;
using OnlineSurvey.DataAccessLayer.Entities;
using System.Net.Http.Json;

namespace OnlineSurvey.WebApp.Client.Pages
{
    public partial class Login : ComponentBase
    {
        private bool loading;
        public Respondents users { get; set; } = new Respondents();
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public HttpClient Client { get; set; }
        protected void NavigateToSurvey()
        {
            NavigationManager.NavigateTo("/survey");
        }
        protected void NavigateToResults()
        {
            NavigationManager.NavigateTo("/results");
        }
        private async void OnValidSubmit()
        {
            try
            {
                var results = await Client.GetFromJsonAsync<List<RespondentResult>>("/GetLoginState");
                if(results.Count>0)
                    NavigateToResults();
            }
            catch (Exception ex)
            {

                loading = false;
                StateHasChanged();
            }
        }
    }
}
