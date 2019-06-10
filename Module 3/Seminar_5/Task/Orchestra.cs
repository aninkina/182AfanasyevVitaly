using System;
using System.Collections.Generic;

namespace Task
{
    public class Orchestra
    {
        public List<MusicalInstrument> SetOfMusicalInstruments { get; set; }

        public IEnumerator<MusicalInstrument> GetEnumerator()
        {
            var instruments = SetOfMusicalInstruments;
            instruments.Sort((x, y) => x.Name.Length < y.Name.Length ? 1 : -1);
            for (int i = 0; i < instruments.Count; ++i)
                yield return instruments[i];
        }
        
        public Orchestra()
        {
            SetOfMusicalInstruments = new List<MusicalInstrument>();
        }
    }
}
