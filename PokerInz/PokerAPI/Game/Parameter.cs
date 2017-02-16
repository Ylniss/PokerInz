using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Game
{
    public class Parameter
    {
        public string Name { get; }

        public float Value { get; }
        public float ValueIncrease { get; }

        public float MinValue { get; }
        public float MaxValue { get; }

        public Parameter(string name, float value, float valueIncrease, float minValue, float maxValue)
        {
            Name = name;
            Value = value;
            ValueIncrease = valueIncrease;
            MinValue = minValue;
            MaxValue = maxValue;
        }

    }
}
