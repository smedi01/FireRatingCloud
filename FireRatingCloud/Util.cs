﻿#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
#endregion // Namespaces

namespace FireRatingCloud
{
  class Util
  {
    #region HTTP Access
    /// <summary>
    /// Timeout for HTTP calls.
    /// </summary>
    public static int Timeout = 500;

    /// <summary>
    /// HTTP access constant to toggle between local and global server.
    /// </summary>
    public static bool UseLocalServer = true;

    // HTTP access constants.

    const string _base_url_local = "http://127.0.0.1:3001";
    const string _base_url_global = "https://fireratingdb.herokuapp.com";
    const string _api_version = "api/v1";

    /// <summary>
    /// Return REST API URI.
    /// </summary>
    public static string RestApiUri
    {
      get
      {
        string base_url = UseLocalServer
          ? _base_url_local
          : _base_url_global;

        return base_url + "/" + _api_version;
      }
    }

    /// <summary>
    /// GET, PUT or POST JSON document data from or to 
    /// the specified mongoDB collection.
    /// </summary>
    public static string QueryOrUpsert(
      string collection_name_id_query,
      string json,
      string method )
    {
      string uri = Util.RestApiUri + "/" + collection_name_id_query;

      HttpWebRequest request = HttpWebRequest.Create(
        uri ) as HttpWebRequest;

      request.ContentType = "application/json; charset=utf-8";
      request.Accept = "application/json, text/javascript, */*";
      request.Timeout = Util.Timeout;
      request.Method = method;

      if( 0 < json.Length )
      {
        Debug.Assert( !method.Equals( "GET" ),
          "content is not allowed with GET" );

        using( StreamWriter writer = new StreamWriter(
          request.GetRequestStream() ) )
        {
          writer.Write( json );
        }
      }
      WebResponse response = request.GetResponse();
      Stream stream = response.GetResponseStream();
      string jsonResponse = string.Empty;

      using( StreamReader reader = new StreamReader(
        stream ) )
      {
        while( !reader.EndOfStream )
        {
          jsonResponse += reader.ReadLine();
        }
      }
      return jsonResponse;
    }

    #region Test Code
#if LOTS_OF_TEST_CODE
    /// <summary>
    /// POST JSON data to the specified mongoDB collection.
    /// </summary>
    async void PostJsonDataAsyncAttempt(
      string collection_name,
      string json )
    {
      using( System.Net.Http.HttpClient httpClient
        = new System.Net.Http.HttpClient() )
      {
        try
        {
          string resourceAddress = Util.RestApiUri
            + "/" + collection_name;

          string postBody = json;

          httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue(
              "application/json" ) );

          HttpResponseMessage wcfResponse
            = await httpClient.PostAsync(
              resourceAddress, new StringContent(
                postBody, Encoding.UTF8,
                "application/json" ) );

          //await DisplayTextResult( wcfResponse, OutputField );
        }
        catch( HttpRequestException hre )
        {
          Debug.Print( "Error:" + hre.Message );
        }
        catch( TaskCanceledException )
        {
          Debug.Print( "Request canceled." );
        }
        catch( Exception ex )
        {
          Debug.Print( ex.Message );
        }
      }
    }

    static async void DownloadPageAsync()
    {
      // ... Target page.
      string page = "http://en.wikipedia.org/";

      // ... Use HttpClient.
      using( HttpClient client = new HttpClient() )
      using( HttpResponseMessage response = await client.GetAsync( page ) )
      using( HttpContent content = response.Content )
      {
        // ... Read the string.
        string result = await content.ReadAsStringAsync();

        // ... Display the result.
        if( result != null &&
        result.Length >= 50 )
        {
          Console.WriteLine( result.Substring( 0, 50 ) + "..." );
        }
      }
    }

#if FUTURE_SAMPLE_CODE
    static void DownloadPageAsync2( string[] args )
    {
      string uri = Util.RestApiUri;

      // Create an HttpClient instance 
      HttpClient client = new HttpClient();

      // Send a request asynchronously continue when complete 
      client.GetAsync( uri ).ContinueWith(
          ( requestTask ) =>
          {
            // Get HTTP response from completed task. 
            HttpResponseMessage response = requestTask.Result;

            // Check that response was successful or throw exception 
            response.EnsureSuccessStatusCode();

            // Read response asynchronously as JsonValue and write out top facts for each country 
            response.Content.ReadAsAsync<JsonArray>().ContinueWith(
                ( readTask ) =>
                {
                  Console.WriteLine( "First 50 countries listed by The World Bank..." );
                  foreach( var country in readTask.Result[1] )
                  {
                    Console.WriteLine( "   {0}, Country Code: {1}, Capital: {2}, Latitude: {3}, Longitude: {4}",
                        country.Value["name"],
                        country.Value["iso2Code"],
                        country.Value["capitalCity"],
                        country.Value["latitude"],
                        country.Value["longitude"] );
                  }
                } );
          } );

      Console.WriteLine( "Hit ENTER to exit..." );
      Console.ReadLine();
    }
#endif // FUTURE_SAMPLE_CODE

#if USE_CODE_FROM_TWGL_EXPORT
    /// <summary>
    /// HTTP POST with the given JSON data in the 
    /// request body. Use a local or global base URL.
    /// </summary>
    static public bool PostJsonData( string json )
    {
      bool rc = false;

      string uri = Util.RestApiUri + "/" + projects;

      HttpWebRequest req = WebRequest.Create( uri ) as HttpWebRequest;

      req.KeepAlive = false;
      req.Method = WebRequestMethods.Http.Post;

      // Turn our request string into a byte stream.

      byte[] postBytes = Encoding.UTF8.GetBytes( json );

      req.ContentLength = postBytes.Length;

      // Specify content type.

      req.ContentType = "application/json; charset=UTF-8"; // or just "text/json"?
      req.Accept = "application/json";
      req.ContentLength = postBytes.Length;

      Stream requestStream = req.GetRequestStream();
      requestStream.Write( postBytes, 0, postBytes.Length );
      requestStream.Close();

      HttpWebResponse res = req.GetResponse() as HttpWebResponse;

      string result;

      using( StreamReader reader = new StreamReader(
        res.GetResponseStream() ) )
      {
        result = reader.ReadToEnd();
      }

      // Get JavaScript modules from server public folder.

      result = result.Replace( "<script src=\"/",
        "<script src=\"" + base_url + "/" );

      string filename = Path.GetTempFileName();
      filename = Path.ChangeExtension( filename, "html" );

      //string dir = Path.GetDirectoryName( filename );

      //// Get JavaScript modules from current directory.

      //string path = dir
      //  .Replace( Path.GetPathRoot( dir ), "" )
      //  .Replace( '\\', '/' );

      ////result = result.Replace( "<script src=\"/",
      ////  "<script src=\"file:///" + dir + "/" ); // XMLHttpRequest cannot load file:///C:/Users/tammikj/AppData/Local/Temp/vs.js. Cross origin requests are only supported for protocol schemes: http, data, chrome, chrome-extension, https, chrome-extension-resource.

      //result = result.Replace( "<script src=\"/", 
      //  "<script src=\"" );

      //if( EnsureJsModulesPresent( dir ) )

      {
        using( StreamWriter writer = File.CreateText( filename ) )
        {
          writer.Write( result );
          writer.Close();
        }

        System.Diagnostics.Process.Start( filename );

        rc = true;
      }
      return rc;
    }
#endif // USE_CODE_FROM_TWGL_EXPORT
#endif // LOTS_OF_TEST_CODE
    #endregion // Test Code

    #endregion // HTTP Access

    #region Shared Parameter Definition
    // Shared parameter definition constants.

    public const string SharedParameterGroupName = "API Parameters";
    public const string SharedParameterName = "API FireRating";
    public const string SharedParameterFilePath = "C:/tmp/SharedParams.txt";

    /// <summary>
    /// Get shared parameters file.
    /// </summary>
    public static DefinitionFile GetSharedParamsFile(
      Application app )
    {
      string sharedParamsFileName = app
        .SharedParametersFilename;

      if( 0 == sharedParamsFileName.Length )
      {

        StreamWriter stream;
        stream = new StreamWriter( SharedParameterFilePath );
        stream.Close();

        app.SharedParametersFilename = SharedParameterFilePath;
        sharedParamsFileName = app.SharedParametersFilename;
      }

      // Get the current file object and return it
      
      DefinitionFile sharedParametersFile = app
        .OpenSharedParameterFile();

      return sharedParametersFile;
    }

    /// <summary>
    /// Return all element instances for a given 
    /// category, identified either by a built-in 
    /// category or by a category name.
    /// </summary>
    public static FilteredElementCollector GetTargetInstances(
      Document doc,
      object targetCategory )
    {
      FilteredElementCollector collector 
        = new FilteredElementCollector( doc );

      bool isName = targetCategory.GetType().Equals( 
        typeof( string ) );

      if( isName )
      {
        Category cat = doc.Settings.Categories
          .get_Item( targetCategory as string );

        collector.OfCategoryId( cat.Id );
      }
      else
      {
        collector.WhereElementIsNotElementType();

        collector.OfCategory( (BuiltInCategory) targetCategory );

        //var model_elements
        //  = from e in collector
        //    where ( null != e.Category && e.Category.HasMaterialQuantities )
        //    select e;

        //elements = model_elements.ToList<Element>();
      }
      return collector;
    }

    /// <summary>
    /// Return GUID for a given shared parameter group and name.
    /// </summary>
    /// <param name="app">Revit application</param>
    /// <param name="defGroup">Definition group name</param>
    /// <param name="defName">Definition name</param>
    /// <returns>GUID</returns>
    public static Guid SharedParamGuid( 
      Application app, 
      string defGroup, 
      string defName )
    {
      DefinitionFile file = app.OpenSharedParameterFile();
      DefinitionGroup group = file.Groups.get_Item( defGroup );
      Definition definition = group.Definitions.get_Item( defName );
      ExternalDefinition externalDefinition = definition as ExternalDefinition;
      return externalDefinition.GUID;
    }
    #endregion // Shared Parameter Definition
  }
}
