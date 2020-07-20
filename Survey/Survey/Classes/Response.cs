using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey
{
    public abstract class Response : PersistentEntity
    {
        public virtual SurveyQuestion Question { get; protected set; }
        public virtual double Score { get; set; }
        public virtual ResponseForm ResponseForm { get; set; }
        public virtual ResponseSection Parent { get; set; }
        public virtual int SequenceNo { get; set; }
        
    }
}
