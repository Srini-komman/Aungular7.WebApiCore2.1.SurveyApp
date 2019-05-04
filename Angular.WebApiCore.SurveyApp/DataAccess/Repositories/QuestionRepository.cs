using Angular.WebApiCore.SurveyApp.DataAccess.Context;
using Angular.WebApiCore.SurveyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Angular.WebApiCore.SurveyApp.DataAccess.Repositories
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(SurveyContext context)
            : base(context)
        {

        }
        public async Task<IEnumerable<Question>> GetQuestionsWithChoicesAsync()
        {
            var questions = await SurveyContext.Questions.Include(q => q.Choices).ToListAsync();
            return questions;
        }

        public SurveyContext SurveyContext
        {
            get { return Context as SurveyContext; }
        }
    }
}
