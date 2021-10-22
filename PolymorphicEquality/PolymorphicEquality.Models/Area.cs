namespace PolymorphicEquality.Models
{
    public abstract record Area : ICaptureAddresses
    {
        public abstract bool ContainsAddress(Address testAddress);
    }
}
