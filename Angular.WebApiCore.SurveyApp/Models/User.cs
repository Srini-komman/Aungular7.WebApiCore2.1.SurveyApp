using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular.WebApiCore.SurveyApp.Models
{
    public class User
    {
        [Key]
        public long UserId { get; set; }
        [Required]
        [Column(TypeName="nvarchar(150)")]
        public string NickName { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
