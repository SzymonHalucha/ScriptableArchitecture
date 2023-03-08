using UnityEngine;

namespace SH.ScriptableArchitecture.Variables.Primitives
{
    [CreateAssetMenu(menuName = "SH/Scriptable Architecture/Variables/Long")]
    public class LongVariable : BaseVariable<long>
    {
        public static LongVariable operator +(LongVariable variable, long value)
        {
            variable.Value += value;
            return variable;
        }

        public static LongVariable operator -(LongVariable variable, long value)
        {
            variable.Value -= value;
            return variable;
        }

        public static LongVariable operator *(LongVariable variable, long value)
        {
            variable.Value *= value;
            return variable;
        }

        public static LongVariable operator /(LongVariable variable, long value)
        {
            variable.Value /= value;
            return variable;
        }

        public static LongVariable operator ++(LongVariable variable)
        {
            variable.Value++;
            return variable;
        }

        public static LongVariable operator --(LongVariable variable)
        {
            variable.Value--;
            return variable;
        }
    }
}