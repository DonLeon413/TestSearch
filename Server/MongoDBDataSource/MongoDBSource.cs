using DataSource;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;

namespace MongoDBDataSource
{
    /// <summary>
    /// 
    /// </summary>
    public class MongoDBSource:
                 IDataSource<String>
    {
        private IMongoDatabase _Database = null;

        /// <summary>
        /// 
        /// </summary>
        private MongoDBSource( )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IDataSource<String> Create( String connectionString )
        {
            MongoDBSource result = new MongoDBSource();

            result.Initialize( connectionString );

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        private void Initialize( String connectionString )
        {
            var url = MongoUrl.Create( connectionString );
            var client = new MongoClient( connectionString );
            this._Database = client.GetDatabase( url.DatabaseName );            
        }

        #region interface IDataSource

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonObject"></param>
        public AddResultModel<String> AddObject( String jsonObject )
        {
            var collection = this._Database.GetCollection<BsonDocument>( "testcollect" );

            BsonDocument doc = BsonDocument.Parse( jsonObject );

            collection.InsertOne( doc );

            String id = doc["_id"].ToString(); 

            return new AddResultModel<String>( id );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonObject"></param>
        /// <returns></returns>
        public SearchResultModel<String> FindObjects( String jsonObject )
        {
            var collection = this._Database.GetCollection<BsonDocument>( "testcollect" );

            BsonDocument empty_document = new BsonDocument();

            var filters = CreateFilterByObject( jsonObject );
                                                       // Or - это спорно
            var filter = Builders<BsonDocument>.Filter.Or( filters);

            var ids = collection.Find( filter ).
                                 ToList().
                                 Select( o => o["_id"].ToString() ).
                                 ToList();            

            return new SearchResultModel<String>(ids);
        }        

        #endregion

        #region IDisposable
        
        /// <summary>
        /// Flag: Has Dispose already been called? 
        /// </summary>
        protected Boolean _Disposed = false;

        /// <summary>
        /// implementation of Dispose pattern callable by consumers.
        /// </summary>
        public void Dispose( )
        {
            Dispose( true );

            GC.SuppressFinalize( this );
        }

        /// <summary>
        /// Protected implementation of Dispose pattern. 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose( bool disposing )
        {
            if( this._Disposed )
                return;

            if( disposing )
            {
                // Free any other managed objects here.                                    
                this._Database = null;
            }
            // Free any unmanaged objects here.
            this._Disposed = true;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonObject"></param>
        /// <returns></returns>
        private IEnumerable<FilterDefinition<BsonDocument>> CreateFilterByObject( String jsonObject )
        {
            List<FilterDefinition<BsonDocument>> result = new List<FilterDefinition<BsonDocument>>();

            BsonDocument filter_doc = BsonDocument.Parse( jsonObject );

            foreach( var element in filter_doc.Elements)
            {
                var value = BsonTypeMapper.MapToDotNetValue( element.Value );
                
                if( value != null )
                {
                     if( value is String )
                     {   // String
                        String str_value = value as String;
                        if( false == String.IsNullOrWhiteSpace( str_value ) )
                        {   // Ищем подстроку
                            result.Add( Builders<BsonDocument>.Filter.Regex( element.Name, str_value ) );
                            Debug.WriteLine( String.Format( "NAme: {0}  Value:{1}", element.Name, str_value ) );
                        }
                     }
                     else
                     {   // другие типы - точное соответствие                            
                         result.Add( Builders<BsonDocument>.Filter.Eq( element.Name, value ) );
                        Debug.WriteLine( String.Format( "NAme: {0}  Value:{1}", element.Name, value ) );
                     }                        
                }
            }
              
            if( 0 == result.Count)
            {                
            }

            return result;
        }
    }
}
