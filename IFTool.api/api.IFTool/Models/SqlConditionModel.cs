using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.IFTool.Models
{
    public class SqlWhereCondition
    {
        public virtual string Field { get; set; }
        public virtual string Condition { get; set; }
        public virtual object Value { get; set; }
        public virtual bool IsCustomQuery { get; set; }
    }
}
