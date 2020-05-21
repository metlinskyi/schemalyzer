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
            AnalysingData,
            AnalysingSchema,
        }
        private readonly ISchemaProvider _schemaProvider;
        private readonly IDataProvider _dataProvider;
        private readonly Querylyzer _querylyzer;
        public Schemalyzer(ISchemaProvider schemaProvider, IDataProvider dataProvider)
        {
            _schemaProvider = schemaProvider;
            _dataProvider = dataProvider;
            _querylyzer = new Querylyzer();
        }
        public Schemalyzer Run(Action<Schemalyzer.Status, byte> progress)
        {
            progress(Status.GettingSchema, 0);

            var databases = _schemaProvider.Databases().ToArray();

            var types = databases
                .SelectMany(db => db.Tables.SelectMany(t => t.Columns))
                .GroupBy(c => c.DataType.Name)
                .Where(x => x.Count() > 1)
                .ToDictionary(x => x.Key, x => x.ToArray());

            progress(Status.GettingSchema, 100);

            progress(Status.AnalysingData, 0);

            var pairs = new List<Tuple<ColumnInfo, ColumnInfo>>();    

            foreach(var group in types)
            {
                foreach(var fk in group.Value)
                {
                    foreach(var pk in group.Value.Where(x => !object.Equals(x, fk)))
                    {
                        if(_dataProvider.IsIntersect(fk, pk))
                        {
                            pairs.Add(new Tuple<ColumnInfo, ColumnInfo>(fk,pk));
                        }
                    }
                }
            }

            progress(Status.AnalysingData, 100);

            progress(Status.AnalysingSchema, 0);
            
            var views = databases
                .SelectMany(db => db.Views)
                .Where(x => !string.IsNullOrEmpty(x.Source))
                .Select(_querylyzer.Parse);

            var routines = databases
                .SelectMany(db => db.Routines)
                .Where(x => !string.IsNullOrEmpty(x.Source))
                .Select(_querylyzer.Parse);

            var relations = views.Union(routines).ToArray();

            progress(Status.AnalysingSchema, 100);

            return this;
        }
    }
}
