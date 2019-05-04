using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Angular.WebApiCore.SurveyApp.DataAccess;
using Angular.WebApiCore.SurveyApp.Models;
using Angular.WebApiCore.SurveyApp.Constants;
using Angular.WebApiCore.SurveyApp.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Angular.WebApiCore.SurveyApp.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;
               
        public SurveyController(IUnitOfWork unitOfWork)
        {            
            this.unitOfWork = unitOfWork as UnitOfWork;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<Object> PostUser(User userModel)
        {
            Object result = null;
            Object response = null;
            var user = new User()
            {
                NickName = userModel.NickName
            };
            try
            {
                this.unitOfWork.UserRepository.Add(userModel);
                result = await this.unitOfWork.SaveChangesAsync();
                if (result != null)
                {
                    response = new {
                        Succeeded = true,
                        data = userModel
                    };
                }                
            }                   
            catch (Exception ex)
            {
                response = ErrorMessageUtility.GetFailedMessage(ex);
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("SubmitAnswers1")]
        public Object SubmitAnswers(Answer answerModel)
        {
            Object result = null;
            Object response = null;
            
            try
            {
                this.unitOfWork.AnswerRepository.Add(answerModel);
                result = this.unitOfWork.SaveChangesAsync();
                if (result != null)
                {
                    response = new
                    {
                        Succeeded = true,                        
                    };
                }
            }
            catch (Exception ex)
            {
                response = ErrorMessageUtility.GetFailedMessage(ex);
            }

            return Ok(response);
        }
        [HttpPost]
        [Route("SubmitAnswers")]
        public async Task<Object> SubmitAnswers(AnswerModel answerModel)
        {
            Object result = null;
            Object response = null;

            try
            {
                this.unitOfWork.AnswerRepository.AddRangeAsync(answerModel.Answers);
                result = await this.unitOfWork.SaveChangesAsync();
                if (result != null)
                {
                    response = new
                    {
                        Succeeded = true,
                    };
                }
            }
            catch (Exception ex)
            {
                response = ErrorMessageUtility.GetFailedMessage(ex);
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("Questions")] 
        public async Task<string> GetQuestions()
        {
            try
            {
                var result = await this.unitOfWork.QuestionRepository.GetQuestionsWithChoicesAsync();                
                var response = JsonConvert.SerializeObject(result, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    });
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
                                    
        }
    }
}