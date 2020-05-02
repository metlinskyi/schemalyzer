using System;
using System.Collections.Generic;

namespace Client.Schema
{
    using Information;
    
    public interface ISchemaProvider
    {        
        // Gets information of databases.
        IEnumerable<IDataBaseInfo> Databases();
    }
}
