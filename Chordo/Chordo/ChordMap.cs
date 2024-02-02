// Start of adapted code from https://joshclose.github.io/CsvHelper/examples/configuration/class-maps/mapping-properties/
using CsvHelper.Configuration;

namespace Chordo
{
    sealed class ChordMap : ClassMap<Chord>
    {
        public ChordMap()
        {
            Map(m => m.name);
            Map(m => m.score);
            Map(m => m.favourite);
            Map(m => m.time);
            Map(m => m.timesPlayed);
        }
    }
}
// End of adapted code