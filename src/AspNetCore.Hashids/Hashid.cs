namespace AspNetCore.Hashids
{
    public struct HashidInt
    {
        private int _value;

        public static implicit operator HashidInt(int value)
        {
            return new HashidInt { _value = value };
        }

        public static implicit operator int(HashidInt value)
        {
            return value._value;
        }
    }
}
