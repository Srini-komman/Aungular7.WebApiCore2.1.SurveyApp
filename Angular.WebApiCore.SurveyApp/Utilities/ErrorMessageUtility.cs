using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Angular.WebApiCore.SurveyApp.Constants;

namespace Angular.WebApiCore.SurveyApp.Utilities
{
    public class ErrorMessageUtility    
    {
        public static Object GetFailedMessage(Exception ex)
        {
            Object errorMessage = null;
            if (ex.InnerException is SqlException)
            {
                if(((SqlException)ex.InnerException).Number == SqlErrorCodes.SqlServerViolationOfUniqueIndex)
                {
                    errorMessage = new
                    {
                        Succeeded = false,
                        error = new {
                                Code = "DuplicateNickName",
                                Description = ex.InnerException.Message
                        }
                    };
                }
            }
            else
            {
                errorMessage = new
                {
                    Succeeded = false,
                    error = new
                    {
                        Code = "InternalServerError",
                        Description = ex.Message
                    }
                };
            }
            return errorMessage;
        }

    }
}
