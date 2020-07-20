using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey
{
    public class SurveySection : SurveyQuestion
    {
        private IList<SurveyQuestion> children;
        public virtual IList<SurveyQuestion> Children
        {
            get
            {
                if (null == this.children)
                    this.children = new List<SurveyQuestion>();
                return this.children;
            }

            set
            {
                this.children = value;
            }
        }

        public override void Persist(Context context)
        {
            base.Persist(context);

            int seqNo = 0;
            foreach (SurveyQuestion q in this.Children)
            {
                q.Parent = this;
                q.SequenceNo = ++seqNo;
                q.Persist(context);
            }
        }

        public override string ToString()
        {
            return "[section " + base.ToString() + "]";
        }

        public override Response CreateResponse(params object[] responses)
        {
            var r = new ResponseSection(this);
            int i = -1;
            foreach (SurveyQuestion q in this.Children)
            {
                r.Children.Add(q.CreateResponse(responses[++i]));
            }
            return r;
        }

        public override Response CreateDefaultResponse()
        {
            ResponseSection r = new ResponseSection(this);
            //r.Children = CreateDefaultResponses(this.Children);
            foreach (SurveyQuestion q in this.Children)
            {
                r.Children.Add(q.CreateDefaultResponse());
            } 
            return r;
        }
    }
}
