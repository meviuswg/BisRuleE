using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisRuleE
{
    public class IBRERule 
    {
        public IBRERule()
        {

        }

        public IBRERule(string propertyNameToTest, IBREComparisonOperator comparisonOperator, object valueToExpect) : this(null, propertyNameToTest, comparisonOperator,valueToExpect)
        {
 
        }

        public IBRERule(object entity, string propertyNameToTest, IBREComparisonOperator comparisonOperator, object valueToExpect)
        {
            this.Entity = entity;
            this.Property = new IBREntityProperty() { Name = propertyNameToTest };
            this.Value = new IBREntityPropertyValue() { Value = valueToExpect };
            this.Operator = comparisonOperator;
        }
        public object Entity { get; set; }
        public IBREntityProperty Property { get; set; }
        public IBREntityPropertyValue Value { get; set; } 
        public IBREComparisonOperator Operator { get; set; }  

        /// <summary>
        /// Test if the rule evaluates to True
        /// </summary>
        /// <returns></returns>
        public bool Assert()
        {
            var entityValue = GetValues();
            var testValue = Value.Value;
            switch (Operator)
            {
                case IBREComparisonOperator.Equals:
                    return Equals(entityValue, testValue);
                case IBREComparisonOperator.IsNull:
                    return entityValue == null;
                case IBREComparisonOperator.SmalerThen:
                    return AssertSmalerThen(entityValue, testValue);
                case IBREComparisonOperator.LargerThen:
                    return AssertLargerThen(entityValue, testValue);
                case IBREComparisonOperator.Contains:
                    return AssertContains(entityValue, testValue);
                case IBREComparisonOperator.StartsWith:
                    break;
                case IBREComparisonOperator.EndsWith:
                    break;
                default:
                    break;
            }

            return false;
        }

        public bool Equals<T>(T a, T b)
        {
            return EqualityComparer<T>.Default.Equals(a, b);
        }

        public bool AsserEquals(object a, object b)
        {

            if (a is int && int.TryParse(b.ToString(), out int testInt))
            {
                return (int)a == testInt;
            }

            return Equals(a, b);
        }

        public bool AssertContains(object a, object b)
        {
            if (a is string && b is string)
            {
                return AssertStringSmalerThen(a?.ToString(), b?.ToString());
            }

            if(a is IEnumerable)
            {
                foreach (var item in (IEnumerable)a)
                {
                    if(item == b)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool AssertStringContains(object testVaue, object compareValue)
        {
          
            return testVaue?.ToString().Contains(compareValue?.ToString()) ?? false;
        }

        public bool AssertSmalerThen(object a, object b)
        {
            if(a is string && b is string) {
                return AssertStringSmalerThen(a?.ToString(), b?.ToString());
            }

            if(a is int && int.TryParse(b.ToString(), out int testInt))
            {
                return (int)a < testInt;
            }

            if (a is DateTime && DateTime.TryParse(b?.ToString(), out DateTime testDate))
            {
                return (DateTime)a < testDate;
            }

            return false;
        }

        public bool AssertStringSmalerThen(string a, string b)
        {
            return string.Compare(a, b) > 1;
        }

        public bool AssertLargerThen(object a, object b)
        {
            if (a is string)
            {
                return AssertLargerThen(a?.ToString(), b?.ToString());
            }

            if (a is int && int.TryParse(b.ToString(), out int testInt))
            {
                return (int)a > testInt;
            }

            if (a is DateTime && DateTime.TryParse(b?.ToString(), out DateTime testDate))
            {
                return (DateTime)a > testDate;
            }

            return false;
        }

        public bool AssertLargerThen(string a, string b)
        {
            return string.Compare(a, b) < 1;
        }

        public object GetValues()
        {
           var props = Entity.GetType().GetProperties().Where(
                prop => Attribute.IsDefined(prop, typeof(BREntityPropertyAttribute)));

            var testProp = props.FirstOrDefault(p => p.Name == Property.Name);

            var value = testProp?.GetValue(Entity);

            return value;

        }

      
    }
}
