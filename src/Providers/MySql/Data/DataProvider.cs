using System.Collections.Generic;
using Client.Data;
using Client.Schema.Information;

namespace MySql.Data
{
    public class DataProvider : IDataProvider
    {
        public bool IsIntersect(ColumnInfo fk, ColumnInfo pk)
        {
            throw new System.NotImplementedException();
        }
    }
}