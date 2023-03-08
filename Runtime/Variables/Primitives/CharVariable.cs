using UnityEngine;

namespace SH.ScriptableArchitecture.Variables.Primitives
{
    [CreateAssetMenu(menuName = "SH/Scriptable Architecture/Variables/Char")]
    public class CharVariable : BaseVariable<char>
    {
        public static CharVariable operator +(CharVariable variable, char value)
        {
            variable.Value += value;
            return variable;
        }

        public static CharVariable operator -(CharVariable variable, char value)
        {
            variable.Value -= value;
            return variable;
        }

        public static CharVariable operator *(CharVariable variable, char value)
        {
            variable.Value *= value;
            return variable;
        }

        public static CharVariable operator /(CharVariable variable, char value)
        {
            variable.Value /= value;
            return variable;
        }

        public static CharVariable operator ++(CharVariable variable)
        {
            variable.Value++;
            return variable;
        }

        public static CharVariable operator --(CharVariable variable)
        {
            variable.Value--;
            return variable;
        }
    }
}