using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey
{
    /// <summary>
    /// Support response of both single-select and multi-select multiple-choices questions
    /// </summary>
    public class ChoiceResponse : Response
    {
        public ChoiceResponse()
        {
        }

        public ChoiceResponse(ChoiceQuestion choiceQuestion)
        {
            this.Question = choiceQuestion;
        }

        public virtual new ChoiceQuestion Question
        {
            get { return (ChoiceQuestion)base.Question; }
            protected set { base.Question = value; }
        }

        private IList<ResponseChoice> selectedChoices;
        public virtual IList<ResponseChoice> SelectedChoices
        {
            get
            {
                if (null == this.selectedChoices)
                    this.selectedChoices = new List<ResponseChoice>();
                return this.selectedChoices;
            }

            set
            {
                if (null == this.Question
                    || this.Question.ContainInvalidChoices(value))
                    throw new Exception("Question is null or the number of selected choices is out of range.");

                this.selectedChoices = value;
            }
        }

        public override void Persist(Context context)
        {
            base.Persist(context);
            foreach (ResponseChoice c in this.SelectedChoices)
            {
                c.Persist(context);
            }
        }
    }
}
