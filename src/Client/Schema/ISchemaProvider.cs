namespace Client.Schema
{
    using System.Collections.Generic;
    using Information;
    
    public interface ISchemaProvider
    {        
        // Gets information of databases.
        IEnumerable<DatabaseInfo> Databases();
    }
}
