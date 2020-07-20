using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey
{
    public class Choice : SurveyItem
    {
        public virtual ChoiceQuestion Parent {get;set;}
        public virtual double Weight { get; set; }
        public virtual SurveyQuestion FurtherQuestion { get; set; }

        public override void Persist(Context context)
        {
            if (null != this.FurtherQuestion)
                this.FurtherQuestion.Persist(context);
            base.Persist(context);
        }

        public override string ToString()
        {
            return "[choice " + base.ToString() + "]";
        }
    }
}
