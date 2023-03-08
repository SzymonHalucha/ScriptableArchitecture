using UnityEngine;

namespace SH.ScriptableArchitecture.Variables.Primitives
{
    [CreateAssetMenu(menuName = "SH/Scriptable Architecture/Variables/Short")]
    public class ShortVariable : BaseVariable<short>
    {
        public static ShortVariable operator +(ShortVariable variable, short value)
        {
            variable.Value += value;
            return variable;
        }

        public static ShortVariable operator -(ShortVariable variable, short value)
        {
            variable.Value -= value;
            return variable;
        }

        public static ShortVariable operator *(ShortVariable variable, short value)
        {
            variable.Value *= value;
            return variable;
        }

        public static ShortVariable operator /(ShortVariable variable, short value)
        {
            variable.Value /= value;
            return variable;
        }

        public static ShortVariable operator ++(ShortVariable variable)
        {
            variable.Value++;
            return variable;
        }

        public static ShortVariable operator --(ShortVariable variable)
        {
            variable.Value--;
            return variable;
        }
    }
}