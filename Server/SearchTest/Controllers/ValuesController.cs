using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDBDataSource;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SearchTest.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SearchTest.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route( "[controller]" )]
    [ApiController]
    public class ValuesController:
            ControllerBase
    {
        private readonly IConfiguration _IConfig;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iConfiguration"></param>
        public ValuesController( IConfiguration iConfiguration )
        {
            this._IConfig = iConfiguration;

            var cs = this._IConfig.GetValue<string>( "MongoDBConnection" );

        }

        /// <summary>
        /// GET: api/ValuesController
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route( "Search" )]
        public IActionResult Search( Object dynObj )
        {
            try
            {
                if( dynObj.IsJsonElemen() )
                {

                    String json = dynObj.ToString();
                    if( false == String.IsNullOrWhiteSpace( json ) )
                    {
                        using( var db_source = DataSourceCreator.Create( this._IConfig ) )
                        {
                            var model = db_source.FindObjects( json );

                            return Ok( model );
                        }
                    }
                }

                return BadRequest( "Unknown data" );

            }
            catch( Exception ex )
            {
                Debug.WriteLine( ex.Message );
                return BadRequest( ex.Message );
            }

        }

        /// <summary>
        /// POST api/ValuesController
        /// </summary>
        /// <param name="dynObj"></param>
        /// <returns></returns>
        [HttpPost]
        [Route( "Add" )]
        public IActionResult Add( Object dynObj )
        {
            try
            {
                if( dynObj.IsJsonElemen() )
                {

                    String json = dynObj.ToString();
                    if( false ==  String.IsNullOrWhiteSpace( json ) )
                    {
                        using( var db_source = DataSourceCreator.Create( this._IConfig ) )
                        {
                            var model = db_source.AddObject( json );

                            return Ok( model );
                        }
                    }
                }
                
                return BadRequest( "Unknown data" );
                
            }
            catch( Exception ex )
            {
                Debug.WriteLine( ex.Message );
                return BadRequest( ex.Message );
            }
        }

    }
}
