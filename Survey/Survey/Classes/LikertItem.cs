using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey
{
    public class LikertItem : SurveyItem
    {
        public virtual LikertQuestion Parent { get; set; }

        public override string ToString()
        {
            return "[likert " + base.ToString() + "]";
        }
    }
}
