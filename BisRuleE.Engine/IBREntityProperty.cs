using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisRuleE
{
    public class IBREntityProperty : Attribute
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public IBREPropertyValuesAccessor ValuesAccessor { get; set; }
    }
 
}
