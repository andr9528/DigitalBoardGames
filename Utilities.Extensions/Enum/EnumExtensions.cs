using System;

namespace Utilities.Extensions.Enum
{
    public static class EnumExtensions
    {
        public static T RandomEnumValue<T>() where T : struct, System.Enum
        {
            if(!typeof(T).IsEnum) throw new ArgumentException("Type to use this on has to be an Enum");

            var values = System.Enum.GetValues(typeof(T));
            var random = new Random();
            var pick = 0;

            while (pick == 0)
            {
                pick = random.Next(values.Length);
            }

            return (T) values.GetValue(pick);
        }
    }
}