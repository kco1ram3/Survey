using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey
{
    public class ValueResponse<T> : Response
    {
        public ValueResponse()
        {
        }

        public ValueResponse(ValueQuestion<T> question, T value)
        {
            this.Question = question;
            this.ResponseValue = value;
        }

        private ValueQuestion<T> valueQuestion;
        
        private T t;

        public virtual new ValueQuestion<T> Question
        {
            get { return (ValueQuestion<T>)base.Question; }
            protected set { base.Question = value; }
        }
        
        public virtual T ResponseValue { get; set; }
    }
}
