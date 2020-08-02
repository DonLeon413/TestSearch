using System;
using System.Collections.Generic;

namespace DataSource
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDataSource<TypeID>:
            IDisposable
    {

        /// <summary>
        /// Add new object to Storage
        /// </summary>
        /// <param name="jsonObject"></param>
        AddResultModel<TypeID> AddObject( String jsonObject );

        /// <summary>
        /// Find objects
        /// </summary>
        /// <param name="jsonObject"></param>
        /// <returns></returns>
        SearchResultModel<TypeID> FindObjects( String jsonObject );
    }
}
