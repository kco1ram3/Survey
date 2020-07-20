using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey
{
    public class ResponseChoice : PersistentEntity
    {
        public ResponseChoice()
        {
        }

        public ResponseChoice(ChoiceResponse r, Survey.Choice choice)
        {
            this.r = r;
            this.Choice = choice;
        }

        private ChoiceResponse r;
        public virtual Response FurtherResponse { get; set; }
        public virtual Choice Choice { get; set; }
        public virtual ChoiceResponse ResponseChoiceQuestion { get; set; }


    }
}
