using System;
using WolfRaider.Common.Models.Contracts;
using WolfRaider.DataConverter.Exporters.Contracts;
using WolfRaider.DataWriter;

namespace WolfRaider.DataConverter.Exporters
{
    public abstract class Exporter :IExporter
    {
        private const string DataWriterCannotBeNull = "DataWriter cannot be null.";

        protected IDataWriter dataWriter;

        public IDataWriter DataWriter
        {
            get
            {
                return this.dataWriter;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(DataWriterCannotBeNull);
                }

                this.dataWriter = value;
            }
        }

        protected Exporter(IDataWriter dataWriter)
        {
            this.dataWriter = dataWriter;
        }


        public abstract void Export(IExportable exportable);
  
    }
}
