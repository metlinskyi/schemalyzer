using System;
using System.Collections.Generic;

namespace Data.Schema
{
    using Information;
    
    public interface ISchemaProvider
    {        
        // Gets information of databases.
        IEnumerable<IDataBaseInfo> Databases();
    }
}
