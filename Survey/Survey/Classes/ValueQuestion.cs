using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey
{
    public class ValueQuestion<T> : SurveyQuestion
    {
        public virtual string Suffix { get; set; }
        public virtual T DefaultValue { get; set; }
        public virtual T MinValue { get; set; }
        public virtual T MaxValue { get; set; }

        public override string ToString()
        {
            return "[" + typeof(T).Name + " question " + base.ToString() + "]";
        }

        public override Response CreateResponse(params object[] responses)
        {
            return new ValueResponse<T>(this, (T)responses[0]);
        }

        public override Response CreateDefaultResponse()
        {
            ValueResponse<T> r = new ValueResponse<T>(this, this.DefaultValue);
            return r;
        }
    }
}
