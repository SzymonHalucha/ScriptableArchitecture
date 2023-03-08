using UnityEngine;

namespace SH.ScriptableArchitecture.Variables.Primitives
{
    [CreateAssetMenu(menuName = "SH/Scriptable Architecture/Variables/Double")]
    public class DoubleVariable : BaseVariable<double>
    {
        public static DoubleVariable operator +(DoubleVariable variable, double value)
        {
            variable.Value += value;
            return variable;
        }

        public static DoubleVariable operator -(DoubleVariable variable, double value)
        {
            variable.Value -= value;
            return variable;
        }

        public static DoubleVariable operator *(DoubleVariable variable, double value)
        {
            variable.Value *= value;
            return variable;
        }

        public static DoubleVariable operator /(DoubleVariable variable, double value)
        {
            variable.Value /= value;
            return variable;
        }

        public static DoubleVariable operator ++(DoubleVariable variable)
        {
            variable.Value++;
            return variable;
        }

        public static DoubleVariable operator --(DoubleVariable variable)
        {
            variable.Value--;
            return variable;
        }
    }
}