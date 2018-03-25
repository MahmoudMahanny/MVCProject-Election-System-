using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElectionProgram.Models;


namespace ElectionProgram.ViewModel
{
    public class SurveyAnswer
    {
        public List<Question> Questions = new List<Question>();

        public List<float> avgQuestionAnswer = new List<float>();
        public string Evaluation { get; set; }
    }
}