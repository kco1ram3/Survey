using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey
{
    public class ResponseSection : Response
    {
        public ResponseSection()
        {
        }

        public ResponseSection(SurveySection question)
        {
            this.Question = question;
        }

        public virtual new SurveySection Question
        {
            get { return (SurveySection)base.Question; }
            protected set { base.Question = value; }
        }
        
        private IList<Response> children;
        public virtual IList<Response> Children
        {
            get
            {
                if (null == this.children)
                    this.children = new List<Response>();
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
            foreach (Response r in this.Children)
            {
                r.Parent = this;
                r.SequenceNo = ++seqNo;
                r.Persist(context);
            }
        }
    }
}
