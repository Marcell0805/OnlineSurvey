using Microsoft.AspNetCore.Components;
using OnlineSurvey.DataAccessLayer.Entities;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace OnlineSurvey.WebApp.Client.Pages
{
    
    public partial class Results : ComponentBase
    {
        [Inject]
        public HttpClient Client { get; set; }
        public RespondentResult SurveyResults { get; set; }
        public List<RespondentResult> results = [];
        protected override async Task OnInitializedAsync()
        {
            try
            {
                var ResponseResults = await Client.GetFromJsonAsync<List<RespondentResult>>("/GetAllResults");
                results = ResponseResults;


            }
            catch (Exception ex)
            {
                StateHasChanged();
            }
        }
    }
}
