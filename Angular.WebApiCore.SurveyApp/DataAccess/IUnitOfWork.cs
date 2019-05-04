using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular.WebApiCore.SurveyApp.Models;
using Angular.WebApiCore.SurveyApp.DataAccess.Repositories;

namespace Angular.WebApiCore.SurveyApp.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IQuestionRepository QuestionRepository { get; }        
        void Save();

        Task<int> SaveChangesAsync();
    }
}
