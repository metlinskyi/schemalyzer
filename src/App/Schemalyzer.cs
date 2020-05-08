using Client.Schema;
using Client.Schema.Information;
using Client.Data;
using System.Linq;
using System;
using System.Collections.Generic;

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

            var types = databases
                .SelectMany(db => db.Tables.SelectMany(t => t.Columns))
                .GroupBy(c=>c.DataType.Name)
                .Where(x=>x.Count() > 1)
                .ToDictionary(x=>x.Key, x=>x.ToArray());

            var pairs = new List<Tuple<ColumnInfo, ColumnInfo>>();    

            foreach(var group in types)
            {
                foreach(var fk in group.Value)
                {
                    foreach(var pk in group.Value)
                    {
                        if(_dataProvider.IsIntersect(fk, pk))
                        {
                            pairs.Add(new Tuple<ColumnInfo, ColumnInfo>(fk,pk));
                        }
                    }
                }
            }

            progress(Status.AnalysingSchema, 100);

            return this;
        }
    }
}
