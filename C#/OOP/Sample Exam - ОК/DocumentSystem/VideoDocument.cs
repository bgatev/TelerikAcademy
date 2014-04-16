using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    public class VideoDocument:MultimediaDocument
    {
        private int frameRate;

        public int FrameRate
        {
            get
            {
                return this.frameRate;
            }
            set
            {
                this.frameRate = value;
            }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "framerate") this.FrameRate = int.Parse(value);
            else base.LoadProperty(key, value);
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            if (this.FrameRate > 0) output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));
        }
    }
}
