using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular.WebApiCore.SurveyApp.DataAccess.Context;
using Angular.WebApiCore.SurveyApp.Models;
using Angular.WebApiCore.SurveyApp.DataAccess.Repositories;

namespace Angular.WebApiCore.SurveyApp.DataAccess
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly SurveyContext surveyContext;        
        private GenericRepository<User> userRepository;        
        private GenericRepository<Choice> choiceRepository;
        private GenericRepository<Answer> answerRepository;
        public UnitOfWork(SurveyContext surveyContext)
        {
            this.surveyContext = surveyContext;
            QuestionRepository = new QuestionRepository(surveyContext);
        }
        public IQuestionRepository QuestionRepository { get; private set; }
        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(surveyContext);
                }
                return userRepository;
            }
        }        
       
        public GenericRepository<Choice> ChoiceRepository
        {
            get
            {

                if (this.choiceRepository == null)
                {
                    this.choiceRepository = new GenericRepository<Choice>(surveyContext);
                }
                return choiceRepository;
            }
        }
        public GenericRepository<Answer> AnswerRepository
        {
            get
            {

                if (this.answerRepository == null)
                {
                    this.answerRepository = new GenericRepository<Answer>(surveyContext);
                }
                return answerRepository;
            }
        }

        public void Save()
        {
            surveyContext.SaveChanges();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await surveyContext.SaveChangesAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    surveyContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
