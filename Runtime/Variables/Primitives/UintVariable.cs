using UnityEngine;

namespace SH.ScriptableArchitecture.Variables.Primitives
{
    [CreateAssetMenu(menuName = "SH/Scriptable Architecture/Variables/Uint")]
    public class UintVariable : BaseVariable<uint>
    {
        public static UintVariable operator +(UintVariable variable, uint value)
        {
            variable.Value += value;
            return variable;
        }

        public static UintVariable operator -(UintVariable variable, uint value)
        {
            variable.Value -= value;
            return variable;
        }

        public static UintVariable operator *(UintVariable variable, uint value)
        {
            variable.Value *= value;
            return variable;
        }

        public static UintVariable operator /(UintVariable variable, uint value)
        {
            variable.Value /= value;
            return variable;
        }

        public static UintVariable operator ++(UintVariable variable)
        {
            variable.Value++;
            return variable;
        }

        public static UintVariable operator --(UintVariable variable)
        {
            variable.Value--;
            return variable;
        }
    }
}