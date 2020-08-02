using DataSource;
using Microsoft.Extensions.Configuration;
using MongoDBDataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchTest.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class DataSourceCreator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IDataSource<String> Create( IConfiguration iConfig )
        {
            var connection_String = iConfig.GetValue<string>( "MongoDBConnection" );

            return MongoDBSource.Create( connection_String );
        }
    }
}
