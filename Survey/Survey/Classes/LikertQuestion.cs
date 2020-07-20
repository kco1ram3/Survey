using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey
{
    public class LikertQuestion : ChoiceQuestion
    {
        private IList<LikertItem> children;
        public virtual IList<LikertItem> Children
        {
            get
            {
                if (null == this.children)
                    this.children = new List<LikertItem>();
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
            foreach (LikertItem i in this.Children)
            {
                i.SequenceNo = ++seqNo;
                i.Parent = this;
                i.Persist(context);
            }
        }

        public override Response CreateResponse(params object[] responses)
        {
            LikertResponse r = new LikertResponse(this);
            int choiceCount = this.Choices.Count;
            int i = -1;
            foreach (LikertItem li in this.Children)
            {
                int choiceNo = (int)responses[++i];
                if (choiceNo < 0 || choiceNo > choiceCount)
                    throw new Exception(String.Format("", choiceNo, choiceCount));
                r.ItemResponses.Add(new LikertItemResponse(li, this.Choices[choiceNo]));
            }
            return base.CreateResponse(responses);
        }

        public override Response CreateDefaultResponse()
        {
            LikertResponse r = new LikertResponse(this);
            foreach (LikertItem i in this.Children)
            {
                r.ItemResponses.Add(new LikertItemResponse { LikertItem = i, Choice = this.Choices[0] });
            }
            return r;
        }
    }
}
