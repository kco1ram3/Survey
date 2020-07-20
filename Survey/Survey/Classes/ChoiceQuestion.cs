using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey
{
    public class ChoiceQuestion : SurveyQuestion
    {
        public ChoiceQuestion()
        {
            this.MaxNumberOfSelection = this.MinNumberOfSelection = 1;
        }

        private IList<Choice> choices;
        public virtual IList<Choice> Choices
        {
            get
            {
                if (null == this.choices)
                    this.choices = new List<Choice>();
                return this.choices;
            }

            set
            {
                this.choices = value;
            }
        }

        /// <summary>
        /// Default = 1
        /// </summary>
        public virtual int MaxNumberOfSelection { get; set; }

        /// <summary>
        /// Default = 1
        /// </summary>
        public virtual int MinNumberOfSelection { get; set; }

        public virtual bool ContainInvalidChoices(IList<ResponseChoice> choiceList)
        {
            if (choiceList.Count > this.MaxNumberOfSelection || choiceList.Count < this.MinNumberOfSelection)
                return true;
            //TODO: Verify that 
            //1) every choice in choiceList is in this.Choices
            //2) there is no duplication in choiceList
            return false;
        }

        public override void Persist(Context context)
        {
            base.Persist(context);

            int seqNo = 0;
            foreach (Choice q in this.Choices)
            {
                q.Parent = this;
                q.SequenceNo = ++seqNo;
                q.Persist(context);
            }
        }

        public override string ToString()
        {
            return "[choice question " + base.ToString() + "]";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="responses">int[]</param>
        /// <returns></returns>
        public override Response CreateResponse(params object[] responses)
        {
            int numChoice = responses.Length;
            if (this.MinNumberOfSelection > numChoice || numChoice > this.MaxNumberOfSelection)
                throw new Exception(String.Format("The number of selected choices {0} is not within range of [{1}, {2}].", numChoice, this.MinNumberOfSelection, this.MaxNumberOfSelection));

            ChoiceResponse r = new ChoiceResponse(this);
            int numAvailableChoices = this.Choices.Count;
            foreach (object c in (int[])responses[0])
            {
                r.SelectedChoices.Add(new ResponseChoice(r, this.Choices[(int)c]));
            }
            return r;
        }

        public override Response CreateDefaultResponse()
        {
            ChoiceResponse r = new ChoiceResponse(this);
            for (int i = 0; i < this.MinNumberOfSelection; ++i)
            {
                r.SelectedChoices.Add(new ResponseChoice(r, this.Choices[i]));
            }
            return r;
        }
    }
}
