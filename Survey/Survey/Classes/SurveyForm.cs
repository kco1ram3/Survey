using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey
{
    public class SurveyForm : PersistentEntity
    {
        #region persistent

        public virtual string Title { get; set; }
        public virtual string Instructions { get; set; }
        public virtual TimeInterval EffectivePeriod { get; set; }
        public virtual string EndNote { get; set; }

        private IList<SurveyQuestion> questions;
        public virtual IList<SurveyQuestion> Questions
        {
            get
            {
                if (null == this.questions)
                    this.questions = new List<SurveyQuestion>();
                return this.questions;
            }

            set
            {
                if (null == value)
                    throw new Exception("The list is null.");

                this.questions = value;
            }
        }

        #endregion

        public override void Persist(Context context)
        {
            base.Persist(context);

            int seqNo = 0;
            foreach (SurveyQuestion q in this.Questions)
            {
                q.SurveyForm = this;
                q.SequenceNo = ++seqNo;
                q.Persist(context);
            }
        }

        public virtual ResponseForm CreateDefaultResponse()
        {
            ResponseForm rf = new ResponseForm();

            foreach (SurveyQuestion q in questions)
            {
                rf.Responses.Add(q.CreateDefaultResponse());
            }

            return rf;
        }
    }
}
