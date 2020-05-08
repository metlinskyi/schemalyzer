using Client.Schema;
using Client.Data;
using System.Linq;
using System;

namespace App
{
    public class Schemalyzer
    {
        public enum Status : byte 
        {
            Udefinded,
            GettingSchema,
            AnalysingSchema,
        } 
        private readonly ISchemaProvider _schemaProvider;
        private readonly IDataProvider _dataProvider;
        public Schemalyzer(ISchemaProvider schemaProvider, IDataProvider dataProvider)
        {
            _schemaProvider = schemaProvider;
            _dataProvider = dataProvider;
        }
        public Schemalyzer Run(Action<Schemalyzer.Status, byte> progress)
        {
            progress(Status.GettingSchema, 0);

            var databases = _schemaProvider.Databases().ToArray();

            progress(Status.GettingSchema, 100);

            progress(Status.AnalysingSchema, 0);

            progress(Status.AnalysingSchema, 100);

            return this;
        }
    }
}
