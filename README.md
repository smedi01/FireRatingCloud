# FireRatingCloud

FireRatingCloud is a C# .NET Revit add-in.

It is a multi-project re-implementation of the FireRating SDK sample using a cloud-based database managed by the
[fireratingdb](https://github.com/jeremytammik/firerating) node.js MongoDB web server.

For more information, please refer to
[The 3D Web Coder](http://the3dwebcoder.typepad.com),
[The Building Coder](http://thebuildingcoder.typepad.com) and
the detailed articles describing the entire project implementation and evolution, including first learning steps using mongo, implementing a REST API for it, and using that from a C# .NET desktop app:

- [FireRating in the Cloud](http://thebuildingcoder.typepad.com/blog/2015/07/firerating-and-the-revit-python-shell-in-the-cloud-as-web-servers.html)
  - [The FireRating Revit SDK sample](http://thebuildingcoder.typepad.com/blog/2015/07/firerating-and-the-revit-python-shell-in-the-cloud-as-web-servers.html#2)
  - [FireRating data structure](http://thebuildingcoder.typepad.com/blog/2015/07/firerating-and-the-revit-python-shell-in-the-cloud-as-web-servers.html#3)
  - [FireRating in the cloud](http://thebuildingcoder.typepad.com/blog/2015/07/firerating-and-the-revit-python-shell-in-the-cloud-as-web-servers.html#4)
- [My first mongo database](http://the3dwebcoder.typepad.com/blog/2015/06/my-first-mongo-database.html)
  - Define the over-all goal and what to store, namely building projects, door instances hosted in them, and each door's fire rating value, based on the venerable old Revit SDK FireRating sample.
- [Implementing relationships](http://the3dwebcoder.typepad.com/blog/2015/07/implementing-mongo-database-relationships.html)
  - Define a more complete schema that includes information about the container projects, i.e., the Revit RVT BIM or building information model project files.
  - Define and maintain the relationships between the door family instances and their container projects.
- [Starting to Implement the FireRating REST API](http://the3dwebcoder.typepad.com/blog/2015/07/starting-to-implement-the-firerating-rest-api.html)
  - Adding a REST API to populate and query the database programmatically.
- [Put, Post, Delete and Curl Testing a REST API](http://the3dwebcoder.typepad.com/blog/2015/07/put-post-delete-and-curl-testing-the-firerating-rest-api.html)
  - [Add version prefix to routing URLs](http://the3dwebcoder.typepad.com/blog/2015/07/put-post-delete-and-curl-testing-the-firerating-rest-api.html#2)
  - [Test REST API using browser and cURL](http://the3dwebcoder.typepad.com/blog/2015/07/put-post-delete-and-curl-testing-the-firerating-rest-api.html#3)
  - [Put – update a record](http://the3dwebcoder.typepad.com/blog/2015/07/put-post-delete-and-curl-testing-the-firerating-rest-api.html#4)
  - [Post – add a record](http://the3dwebcoder.typepad.com/blog/2015/07/put-post-delete-and-curl-testing-the-firerating-rest-api.html#5)
  - [Delete – delete a record](http://the3dwebcoder.typepad.com/blog/2015/07/put-post-delete-and-curl-testing-the-firerating-rest-api.html#6)
- [Populating MongoDB via C# .NET REST API](http://the3dwebcoder.typepad.com/blog/2015/07/adding-a-mongodb-document-from-c-net-via-rest-api.html)
  - [Installing MongoDB on Windows](http://the3dwebcoder.typepad.com/blog/2015/07/adding-a-mongodb-document-from-c-net-via-rest-api.html#2)
  - [Running MongoDB and the node.js web server on Windows](http://the3dwebcoder.typepad.com/blog/2015/07/adding-a-mongodb-document-from-c-net-via-rest-api.html#3)
  - [Storing a document in mongo via REST API from C# .NET](http://the3dwebcoder.typepad.com/blog/2015/07/adding-a-mongodb-document-from-c-net-via-rest-api.html#4)
  - [Generating the JSON data representing a project document](http://the3dwebcoder.typepad.com/blog/2015/07/adding-a-mongodb-document-from-c-net-via-rest-api.html#5)
  - [Using JavaScriptSerializer to format JSON data](http://the3dwebcoder.typepad.com/blog/2015/07/adding-a-mongodb-document-from-c-net-via-rest-api.html#6)
  - [Hand-formatted JSON project data](http://the3dwebcoder.typepad.com/blog/2015/07/adding-a-mongodb-document-from-c-net-via-rest-api.html#7)
  - [The new project document in the mongo database](http://the3dwebcoder.typepad.com/blog/2015/07/adding-a-mongodb-document-from-c-net-via-rest-api.html#8)
- [Complete C# .NET REST API GET and PUT MongoDB Storage](http://the3dwebcoder.typepad.com/blog/2015/07/get-and-put-c-net-rest-api-mongodb-storage.html)
  - [Adding a JSON parser module](http://the3dwebcoder.typepad.com/blog/2015/07/get-and-put-c-net-rest-api-mongodb-storage.html#2)
  - [Storing door instance documents in mongo](http://the3dwebcoder.typepad.com/blog/2015/07/get-and-put-c-net-rest-api-mongodb-storage.html#3)
  - [Using PUT instead of POST when the database id is known](http://the3dwebcoder.typepad.com/blog/2015/07/get-and-put-c-net-rest-api-mongodb-storage.html#4)
  - [Checking for project existence before adding new](http://the3dwebcoder.typepad.com/blog/2015/07/get-and-put-c-net-rest-api-mongodb-storage.html#5)
-  [Complete FireRatingCloud Round Trip](http://the3dwebcoder.typepad.com/blog/2015/07/fireratingcloud-round-trip-and-on-mongolab.html)
  - [Revit project identification](http://the3dwebcoder.typepad.com/blog/2015/07/fireratingcloud-round-trip-and-on-mongolab.html#2)
  - [Complete Revit Add-in Implementation](http://the3dwebcoder.typepad.com/blog/2015/07/fireratingcloud-round-trip-and-on-mongolab.html#3)
  - [Demo Run Log](http://the3dwebcoder.typepad.com/blog/2015/07/fireratingcloud-round-trip-and-on-mongolab.html#4)
  - [Demo Video](http://the3dwebcoder.typepad.com/blog/2015/07/fireratingcloud-round-trip-and-on-mongolab.html#5)
  - [FireRating Database on Mongolab &ndash; really in the cloud](http://the3dwebcoder.typepad.com/blog/2015/07/fireratingcloud-round-trip-and-on-mongolab.html#6)
  - [Postman does more than cURL](http://the3dwebcoder.typepad.com/blog/2015/07/fireratingcloud-round-trip-and-on-mongolab.html#7)
  - [Wrap-up and Download](http://the3dwebcoder.typepad.com/blog/2015/07/fireratingcloud-round-trip-and-on-mongolab.html#8)
- [FireRatingCloud fully cloud-deployed to Heroku + Mongolab](http://the3dwebcoder.typepad.com/blog/2015/07/fireratingcloud-fully-deployed-on-heroku-and-mongolab.html)
  - Database hosted on [mongolab.com](https://mongolab.com)
  - Node.js web server hosted on [Heroku](http://heroku.com)
  - [Using the Mongo Console on a Remote Database](http://the3dwebcoder.typepad.com/blog/2015/07/fireratingcloud-fully-deployed-on-heroku-and-mongolab.html#3)
- Replace `HttpWebRequest` by `RestSharp` and improve the REST API PUT implementation:
  - [GET, PUT and POST stupidity creating versus updating a record](http://the3dwebcoder.typepad.com/blog/2015/09/comphound-restsharp-mongoose-put-and-post.html#3)
  - [Enabling PUT to create as well as update](http://the3dwebcoder.typepad.com/blog/2015/09/comphound-restsharp-mongoose-put-and-post.html#4)
  - [Using RestSharp instead of HttpWebRequest](http://the3dwebcoder.typepad.com/blog/2015/09/comphound-restsharp-mongoose-put-and-post.html#5)
  - [No need to format data as JSON](http://the3dwebcoder.typepad.com/blog/2015/09/comphound-restsharp-mongoose-put-and-post.html#6)
- [Using RestSharp for Rest API GET](http://the3dwebcoder.typepad.com/blog/2015/09/using-restsharp-for-rest-api-get.html)
- [Mongodb Upsert](http://the3dwebcoder.typepad.com/blog/2015/09/mongodb-upsert.html)
- C# DoorData and Node.js DoorService Classes
  - [DoorData Container Class](http://the3dwebcoder.typepad.com/blog/2015/09/c-doordata-and-nodejs-doorservice-classes.html#3)
  - [REST GET returns a list of deserialised DoorData instances](http://the3dwebcoder.typepad.com/blog/2015/09/c-doordata-and-nodejs-doorservice-classes.html#4)
  - [Passing a DoorData instance to the Put method](http://the3dwebcoder.typepad.com/blog/2015/09/c-doordata-and-nodejs-doorservice-classes.html#5)
  - [Implementing a REST API router DoorService class](http://the3dwebcoder.typepad.com/blog/2015/09/c-doordata-and-nodejs-doorservice-classes.html#6)
- [FireRating in the Cloud presentation and project overview at RTC](http://thebuildingcoder.typepad.com/blog/2015/11/connecting-desktop-and-cloud-room-editor-update.html#4)
- [Connecting Desktop and Cloud recording for the AEC booth at AU](http://thebuildingcoder.typepad.com/blog/2015/11/connecting-desktop-and-cloud-at-au-and-devdays.html#2)


## Installation

To install:

- Fork the repository.
- Clone to your local system.
- Load the solution file in Visual Studio.
- Compile the add-in, producing the .NET assembly DLL FireRatingCloud.dll.
- Install in the standard Revit add-in location, for example by copying the add-in manifest file and the .NET DLL assembly to `C:\Users\tammikj\AppData\Roaming\Autodesk\Revit\Addins\2016`.

If you do not know what this means, please refer to the GitHub
and [Revit programming getting started](http://thebuildingcoder.typepad.com/blog/about-the-author.html#2) guides.

As explaine above, FireRatingCloud interacts with
the [fireratingdb](https://github.com/jeremytammik/firerating) node.js web server and MongoDB database.

You can run both the web server and the database either locally, on your own system, or on the web, for instance
using [Heroku](http://heroku.com) to host the web server
and [mongolab](https://mongolab.com) for the database.

For the web server, this choice is made by the C# Revit add-in and its the Boolean variable `Util.UseLocalServer`, which toggles the base URL being used between these two constants:

    const string _base_url_local = "http://127.0.0.1:3001";
    const string _base_url_global = "http://fireratingdb.herokuapp.com";

The web server in turn decides where to look for the database, again by setting the appropriate URL like this in `server.js`:

    var localMongo = false;

    if(localMongo) {
      // local database
      var mongo_uri = 'mongodb://localhost/firerating';
    } else {
      // mongolab hosted
      var mongo_uri = 'mongodb://revit:revit@ds047742.mongolab.com:47742/firerating';
    }

If you host both the web server and the database on the web, i.e., both `UseLocalServer` and `localMongo` are set to `false`, you have no more to set up.

If you are running some components locally, you need to install and
run [MongoDB](https://www.mongodb.org)
and/or [Node](https://nodejs.org) and
the [fireratingdb](https://github.com/jeremytammik/firerating) app itself on your system.

Good luck and have fun!


## Author

Jeremy Tammik,
[The Building Coder](http://thebuildingcoder.typepad.com) and
[The 3D Web Coder](http://the3dwebcoder.typepad.com),
[ADN](http://www.autodesk.com/adn)
[Open](http://www.autodesk.com/adnopen),
[Autodesk Inc.](http://www.autodesk.com)


## License

This sample is licensed under the terms of the [MIT License](http://opensource.org/licenses/MIT).
Please see the [LICENSE](LICENSE) file for full details.
