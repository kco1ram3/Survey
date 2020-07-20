using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey
{
    public class ResponseForm : PersistentEntity
    {
        
        public ResponseForm()
        {
        }

        public ResponseForm(SurveyForm form)
        {
            this.SurveyForm = form;
        }

        public virtual SurveyForm SurveyForm { get; set; }
        
        private IList<Response> responses;
        public virtual IList<Response> Responses
        {
            get
            {
                if (null == this.responses)
                    this.responses = new List<Response>();
                return this.responses;
            }

            set
            {
                this.responses = value;
            }
        }

        public override void Persist(Context context)
        {
            base.Persist(context);

            int seqNo = 0;
            foreach (Response r in this.Responses)
            {
                r.ResponseForm = this;
                r.SequenceNo = ++seqNo;
                r.Persist(context);
            }
        }
    }
}
