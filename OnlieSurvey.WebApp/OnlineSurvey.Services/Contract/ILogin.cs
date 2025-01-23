using OnlineSurvey.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Services.Contract
{
    public interface ILogin
    {
        Task<IEnumerable<Respondents>> GetName(string UserName, string Password);
    }
}
