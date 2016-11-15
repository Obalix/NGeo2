# NGeo2
NGeo2 makes it easier for users of geographic data to invoke GeoNames service endpoints. You'll no longer have to 
write your own GeoNames clients. 

NGeo2 is a complete rewrite based on the HttpClient class that is supported in PCL, Standard 1.1 and .NET 4.0 (via the Microsoft.Net.Http package) libraries.

Furthermore it is provides an async interface that makes dealing with the inherent aynchronity of webservices easier. The .NET 4.0 async/await support is provided by the Microsoft.Bcl.Async package. In addition when parsing data parallel processing is used.

## How can I use it?
    // needs only to be performed once, alternatively you can specify the user name with each request.
    NGeoSettings.UserName = "username";

	var request = new FindNearbyToponymRequest() {
		Latitude = 47.3m,
		Longitude = 9m,
		Style = Style.FULL
	};
	var response = await GeoNameService.FindNearbyToponym(request);

Altrnatively you can use the shorthand notation:

    var response = request.Execute();

## How can I test it?
There are several test methods provided by the system. In order to execute the tests you will have to provide your GeoNames user name in the app.config files within the test projects.

## New in version 2.0 - Breaking Changes
Yahoo services were removed completely as they are no longer supported.

**The old NGeo interfaces, data types and services are no longer supported!**

## What if I don't like it or want to contribute?
If you find any bugs or hit a problem with the code, please feel free to contact me. 

If you would like to contribute [:-)] to this project instead of building your own, feel free to fork and send me a pull request.

## License
This software is subject to the terms of the [Microsoft Public License (Ms-PL)](http://www.opensource.org/licenses/MS-PL).
