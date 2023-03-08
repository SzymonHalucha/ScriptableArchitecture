using UnityEngine;

namespace SH.ScriptableArchitecture.Variables.Primitives
{
    [CreateAssetMenu(menuName = "SH/Scriptable Architecture/Variables/Primitives/Sbyte")]
    public class SbyteVariable : BaseVariable<sbyte>
    {
        public static SbyteVariable operator +(SbyteVariable variable, sbyte value)
        {
            variable.Value += value;
            return variable;
        }

        public static SbyteVariable operator -(SbyteVariable variable, sbyte value)
        {
            variable.Value -= value;
            return variable;
        }

        public static SbyteVariable operator *(SbyteVariable variable, sbyte value)
        {
            variable.Value *= value;
            return variable;
        }

        public static SbyteVariable operator /(SbyteVariable variable, sbyte value)
        {
            variable.Value /= value;
            return variable;
        }

        public static SbyteVariable operator ++(SbyteVariable variable)
        {
            variable.Value++;
            return variable;
        }

        public static SbyteVariable operator --(SbyteVariable variable)
        {
            variable.Value--;
            return variable;
        }
    }
}