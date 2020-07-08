using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisRuleE
{
    public interface IBREPropertyValuesAccessor<T>
    {
        T Get();
    }

    public interface IBREPropertyValuesAccessor
    {
        object Get();
    }

    public interface IBREPropertyEnumsValuesAccessor<T> 
    {
        T Get();
    }

    public class BREPropertyEnumsValuesAccessor<T> : IBREPropertyEnumsValuesAccessor<T>
    {
        private readonly T enumType;

        public BREPropertyEnumsValuesAccessor(T enumType)
        {
            this.enumType = enumType;
        }
        public T Get()
        {
            return enumType;
        }
    }
}
