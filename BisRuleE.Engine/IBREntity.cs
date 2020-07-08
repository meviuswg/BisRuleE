using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisRuleE
{
    public interface IBREntity 
    {
        object PreviousState { get;  }
        object CurrentState { get; set; }
        object NewState { get; set; }

        IEnumerable<IBREntityProperty> Properties { get; set; }
    }
 
}
