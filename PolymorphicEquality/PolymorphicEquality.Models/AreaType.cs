namespace PolymorphicEquality.Models
{
    public abstract record AreaType : Area
    {
        // Separate base type to prevent AreaGroup from containing another AreaGroup
        // in its Included and Excluded lists
    }
}
