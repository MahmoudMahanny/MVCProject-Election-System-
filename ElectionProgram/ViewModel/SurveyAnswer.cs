using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElectionProgram.Models;


namespace ElectionProgram.ViewModel
{
    public class SurveyAnswer
    {
        public List<Question> Questions { get; set; }
        public List<float> avgQuestionAnswer { get; set; }
        public string Evaluation { get; set; }
    }
}