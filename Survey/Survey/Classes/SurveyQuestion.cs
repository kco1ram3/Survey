using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey
{
    public abstract class SurveyQuestion : SurveyItem
    {
        #region persistent
        
        public virtual SurveySection Parent { get; set; }
        public virtual SurveyForm SurveyForm { get; set; }
        public virtual string Instructions { get; set; }
        public virtual float Weight { get; set; }

        #endregion
        
        public virtual string SequenceNumber
        {
            get
            {
                if (null == this.Parent)
                    return base.SequenceNo.ToString();
                else
                    return this.Parent.SequenceNumber + "." + base.SequenceNo.ToString();
            }
        }
         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="responses">single choice question : int choiceNo<br>multichoice question : int[]</br> </param>
        /// <returns></returns>
        public abstract Response CreateResponse(params object[] responses);
    
        public override string ToString()
        {
            return this.SequenceNumber + " " + this.Title;
        }

        public abstract Response CreateDefaultResponse();
    }
}
