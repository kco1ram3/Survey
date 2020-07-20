using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey
{
    public class TimeInterval
    {
        public TimeInterval()
        {

        }

        public TimeInterval(DateTime from)
        {
            this.From = from;
            this.To = DateTime.MaxValue;
        }

        #region persistent
		
        public virtual DateTime From { get; set; }
        public virtual DateTime To { get; set; }
        
        #endregion

        public virtual DateTime EffectiveDate
        {
            get { return this.From; }
            set { this.From = value; }
        }
        public virtual DateTime ExpiryDate
        {
            get { return this.To.AddDays(+1); }
            set { this.To = value.AddDays(-1); }
        }
    }
}
