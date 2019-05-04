using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Angular.WebApiCore.SurveyApp.DataAccess.Context;
using Angular.WebApiCore.SurveyApp.Models;
using Angular.WebApiCore.SurveyApp.Services;
using Microsoft.Extensions.Options;
using Angular.WebApiCore.SurveyApp.Configurations;

namespace Angular.WebApiCore.SurveyApp.DataAccess
{
    public class DbInitialiser : IDbInitialiser
    {
        private ICsvDataReader csvDataReader;
        private IOptions<CsvFileConfig> csvFileConfig;
        internal SurveyContext surveyContext;
        public DbInitialiser(ICsvDataReader csvDataReader, IOptions<CsvFileConfig> csvFileConfig, SurveyContext surveyContext)
        {
            this.csvDataReader = csvDataReader;
            this.csvFileConfig = csvFileConfig;
            this.surveyContext = surveyContext;
        }
        public void Seed()
        {
            try
            {                
                this.SeedQuestions();
                this.SeedChoices();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private void SeedQuestions()
        {
            if (!this.surveyContext.Questions.Any())
            {
                List<Choice> choices = this.GetChoices();
                this.surveyContext.Questions.AddRange(this.GetQuestions().Select(question => question));
            }
            this.surveyContext.SaveChanges();
        }
        private void SeedChoices()
        {
            if (!this.surveyContext.Choices.Any())
            {
                List<Choice> choices = this.GetChoices();
                this.surveyContext.Choices.AddRange(this.GetChoices().Select(choice => choice));
            }
            this.surveyContext.SaveChanges();
        }
        public List<Question> GetQuestions()
        {
            string strCsvFilePath = csvFileConfig.Value.QuestionsCsvPath;
            var questionsList = this.csvDataReader.Read<Question>(strCsvFilePath, true).ToList();
            return questionsList;
        }

        public List<Choice> GetChoices()
        {
            string strCsvFilePath = csvFileConfig.Value.ChoicesCsvPath;
            var choicesList = this.csvDataReader.Read<Choice>(strCsvFilePath, true).ToList();
            return choicesList;
        }

    }
}
