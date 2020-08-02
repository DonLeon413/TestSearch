using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DataSource
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TypeID"></typeparam>
    public class SearchResultModel<TypeID>
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("ids")]
        public IEnumerable<TypeID> IDs
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        public SearchResultModel( IEnumerable<TypeID> ids )
        {
            this.IDs = ids;
        }
    }
}
