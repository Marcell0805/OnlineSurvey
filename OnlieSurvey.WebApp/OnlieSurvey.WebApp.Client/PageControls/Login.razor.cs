using Microsoft.AspNetCore.Components;
using OnlineSurvey.DataAccessLayer.Entities;

namespace OnlineSurvey.WebApp.Client.Pages
{
    public partial class Login : ComponentBase
    {
        private bool loading;
        public Respondents users { get; set; } = new Respondents();
        [Inject]
        public NavigationManager NavigationManager { get; set; }
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
                NavigateToSurvey();
            }
            catch (Exception ex)
            {

                loading = false;
                StateHasChanged();
            }
        }
    }
}
