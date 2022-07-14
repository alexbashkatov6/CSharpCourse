using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Algorithms
{
    public class PhoneNumber
    {
        public string AreaCode { get; }  // make immutable - delete  set; 
        public string Exchange { get; }  // make immutable - delete  set;
        public string Number { get; }    // make immutable - delete  set;

        public PhoneNumber(string areaCode, string exchange, string number)
        {
            AreaCode = areaCode;
            Exchange = exchange;
            Number = number;
        }

        public override bool Equals(object obj)
        {
            var number = obj as PhoneNumber;
            if (number == null)
                return false;
            return number.AreaCode == this.AreaCode && number.Exchange == this.Exchange && number.Number == this.Number;
        }

        public static bool operator ==(PhoneNumber left, PhoneNumber right)
        {
            if (ReferenceEquals(left, right))
                return true;
            if (ReferenceEquals(null, left))
                return false;
            return left.Equals(right);
        }

        public static bool operator !=(PhoneNumber left, PhoneNumber right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = (int)16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!object.ReferenceEquals(null, AreaCode) ? AreaCode.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!object.ReferenceEquals(null, Exchange) ? AreaCode.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!object.ReferenceEquals(null, Number) ? AreaCode.GetHashCode() : 0);
                return hash;
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Ssn { get; set; }
    }
}
