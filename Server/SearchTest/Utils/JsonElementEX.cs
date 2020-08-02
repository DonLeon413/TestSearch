using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SearchTest.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class JsonElementEX
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static Boolean IsJsonElemen( this Object _this )
        {
            Boolean result = false;

            try
            {
                var this_type = _this.GetType();

                if( this_type != null )
                {
                    if( this_type == typeof( JsonElement ) )
                    {
                        result = true;
                    }
                }

            }catch( Exception ex )
            {
                Debug.WriteLine( ex.Message );
            }

            return result;
        }
    
    }
}
