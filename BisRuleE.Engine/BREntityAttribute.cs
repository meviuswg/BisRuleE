using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisRuleE
{
    public class BREntityAttribute : Attribute
    {
        public BREntityAttribute()
        {

        }
    }

    public class BREntityPropertyAttribute : Attribute
    {
        public BREntityPropertyAttribute()
        {

        }

        public string Display { get; set; }

        /// <summary>
        /// Used to load availble values
        /// </summary>
        public Type ValuesAccessor  { get; set; }
    }
}
