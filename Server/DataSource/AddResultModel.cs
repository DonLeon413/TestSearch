using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;

namespace DataSource
{
    /// <summary>
    /// 
    /// </summary>
    public class AddResultModel<TypeID>
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("id")]
        public TypeID ID
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public AddResultModel (TypeID id )
        {
            this.ID = id;
        }
    }
}
