using Client.Schema;
using Client.Data;

namespace App
{
    public class Schemalyzer
    {
        private readonly ISchemaProvider _schemaProvider;
        private readonly IDataProvider _dataProvider;
        
        public Schemalyzer(ISchemaProvider schemaProvider, IDataProvider dataProvider)
        {
            _schemaProvider = schemaProvider;
            _dataProvider = dataProvider;
        }

        public void Run()
        {

        }
    }
}