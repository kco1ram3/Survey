using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey
{
    public class LikertResponse : Response
    {
        public LikertResponse()
        {
        }

        public LikertResponse(LikertQuestion question)
        {
            // TODO: Complete member initialization
            this.Question = question;
        }

        public virtual new LikertQuestion Question
        {
            get { return (LikertQuestion)base.Question; }
            set { base.Question = value; }
        }

        private IList<LikertItemResponse> itemResponses;
        public virtual IList<LikertItemResponse> ItemResponses
        {
            get
            {
                if (null == this.itemResponses)
                    this.itemResponses = new List<LikertItemResponse>();
                return this.itemResponses;
            }

            set
            {
                this.itemResponses = value;
            }
        }

        public override void Persist(Context context)
        {
            base.Persist(context);
            int seqNo = 0;
            foreach (LikertItemResponse r in this.ItemResponses)
            {
                r.Parent = this;
                r.SequenceNo = ++seqNo;
            }
        }
    }
}
