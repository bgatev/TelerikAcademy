using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    public class AudioDocument:MultimediaDocument
    {
        private int sampleRate;

        public int SampleRate
        {
            get
            {
                return this.sampleRate;
            }
            set
            {
                this.sampleRate = value;
            }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "samplerate") this.SampleRate = int.Parse(value);
            else base.LoadProperty(key, value);
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            if (this.SampleRate > 0) output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
        }
    }
}
