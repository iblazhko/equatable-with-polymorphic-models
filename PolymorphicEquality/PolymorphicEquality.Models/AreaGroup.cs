using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PolymorphicEquality.Models
{
    public sealed record AreaGroup(
        string Name,
        HashSet<AreaType> IncludedAreas,
        HashSet<AreaType> ExcludedAreas) : Area
    {
        public override bool ContainsAddress(Address testAddress) =>
            (IncludedAreas != null && ContainsAddress(testAddress, IncludedAreas)) &&
            (ExcludedAreas == null || !ContainsAddress(testAddress, ExcludedAreas));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool ContainsAddress(in Address address, in HashSet<AreaType> areas)
        {
            // Performance optimisation: using foreach loop instead of
            // areas.Any(x => x.ContainsAddress(x) to reduce allocation of Func<AreaType, bool> objects

            // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
            foreach (var area in areas)
            {
                if (area.ContainsAddress(address)) return true;
            }

            return false;
        }

        public override string ToString() => $"[{nameof(AreaGroup)}: {Name}]";
    }

    public sealed record Anywhere : Area
    {
        public override bool ContainsAddress(Address testAddress) => true;
    }

    public sealed record Nowhere : Area
    {
        public override bool ContainsAddress(Address testAddress) => false;
    }
}
