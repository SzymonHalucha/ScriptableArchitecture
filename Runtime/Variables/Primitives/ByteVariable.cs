using UnityEngine;

namespace SH.ScriptableArchitecture.Variables.Primitives
{
    [CreateAssetMenu(menuName = "SH/Scriptable Architecture/Variables/Primitives/Byte")]
    public class ByteVariable : BaseVariable<byte>
    {
        public static ByteVariable operator +(ByteVariable variable, byte value)
        {
            variable.Value += value;
            return variable;
        }

        public static ByteVariable operator -(ByteVariable variable, byte value)
        {
            variable.Value -= value;
            return variable;
        }

        public static ByteVariable operator *(ByteVariable variable, byte value)
        {
            variable.Value *= value;
            return variable;
        }

        public static ByteVariable operator /(ByteVariable variable, byte value)
        {
            variable.Value /= value;
            return variable;
        }

        public static ByteVariable operator ++(ByteVariable variable)
        {
            variable.Value++;
            return variable;
        }

        public static ByteVariable operator --(ByteVariable variable)
        {
            variable.Value--;
            return variable;
        }
    }
}