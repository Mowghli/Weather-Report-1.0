# Weather-Report-1.0

The project is a simple weather report website made using ASP.NET and C#. The website provides 4 services. These services provide information such as the distance from one location to another location, determine the zipcode of the given location, provides a 5-day weather forecast at the given zipcode, and finds the closest store with the given name.

This project consists of 4 WCF Services:
- DistCalcService (Distance between 2 locations calculator)
- GeoCodeService (Geocoding Service)
- WeatherCondition (Weather Forecast Service)
- YelpStores (Yelp Location Service Implemented as a RESTful service)

The project also consists of the following ASP.NET Web Site:
- TryItWeather (consists of 4 pages to use each service)

## DistCalcService (Distance between 2 locations calculator)

This service uses the [Google Distance Matrix API](https://developers.google.com/maps/documentation/distance-matrix/start) to calculate the distance between two locations provided by the user. Please check the ["Service1.svc.cs"](https://github.com/Mowghli/Weather-Report-1.0/blob/master/DistCalcService/Service1.svc.cs) file for the class format used to store the JSON response from the API. The function that calls the API is "DistanceCalculator". You can also check the webpage code that is used to access the service at ["TryItWeather/DistanceCalcTryIt.aspx.cs"](https://github.com/Mowghli/Weather-Report-1.0/blob/master/TryItWeather/DistanceCalcTryIt.aspx.cs), or the deployed [webpage](http://webstrar3.fulton.asu.edu/page0/DistanceCalcTryIt), but the deployed service will not work now (please check notes).

## GeoCodeService (Geocoding Service)

This service uses the [Google Geocoding API](https://developers.google.com/maps/documentation/geocoding/start) to determine the details of the give location, such as city, country, zipcode, etc. Please check the ["Service1.svc.cs"](https://github.com/Mowghli/Weather-Report-1.0/blob/master/GeoCodeService/Service1.svc.cs) file for the class format used to store the JSON response from the API. The function that calls the API is "GeoCoder". You can also check the webpage code that is used to access the service at ["Weather-Report-1.0/TryItWeather/GeoCoderTryIt.aspx.designer.cs"](https://github.com/Mowghli/Weather-Report-1.0/blob/master/TryItWeather/GeoCoderTryIt.aspx.designer.cs) or the deployed [webpage](http://webstrar3.fulton.asu.edu/page0/GeoCoderTryIt), but the deployed service will not work now (please check notes).

## WeatherCondition (Weather Forecast Service)

This service uses the [OpenWeatherMap API](https://openweathermap.org/) to get a 5-day weather forecast at the given zipcode. Please check the ["Service1.svc.cs"](https://github.com/Mowghli/Weather-Report-1.0/blob/master/WeatherCondition/Service1.svc.cs) file for the class format used to store the JSON response from the API. The function that calls the API is "Weather5Day". You can also check the webpage code that is used to access the service at ["Weather-Report-1.0/TryItWeather/WeatherForecastTryIt.aspx.cs"](https://github.com/Mowghli/Weather-Report-1.0/blob/master/TryItWeather/WeatherForecastTryIt.aspx.cs) or the deployed [webpage](http://webstrar3.fulton.asu.edu/page0/WeatherForecastTryIt), but the deployed service will not work now (please check notes).

## YelpStores (Yelp Location Service Implemented as a RESTful service)

This service uses the [Yelp Fusion API](https://www.yelp.com/fusion) to get the closest store or restaurant with the given name, to the given location. Please check the ["Service1.svc.cs"](https://github.com/Mowghli/Weather-Report-1.0/blob/master/YelpStores/Service1.svc.cs) file for the class format used to store the JSON response from the API. The function that calls the API is "YelpStoreFinder". You can also check the webpage code that is used to access the service at ["Weather-Report-1.0/TryItWeather/YelpTryIt.aspx.cs"](https://github.com/Mowghli/Weather-Report-1.0/blob/master/TryItWeather/YelpTryIt.aspx.cs) or the deployed [webpage](http://webstrar3.fulton.asu.edu/page0/YelpTryIt.aspx), but the deployed service will not work now (please check notes).

## TryItWeather (consists of 4 pages to use the 4 services)

This project folder contains aspx web pages that use the services. To see these web pages, you can either run them in Visual Studio 2019, or check the [webpages here](http://webstrar3.fulton.asu.edu/index.html). The deployed webpages will not function properly as the API key used by the services have been removed.

**Notes:** The services used in this project were originally intended to be used to make one service: Getting the user's location, and the name of the store that they wanted to go to, determine the closest store with the given name, along with the zipcode and distance to that location, and the best time to go to the store, based on the 5-day weather forecast. 

Even though this project is depolyed, the services will not work, because the API keys that were used by the services have been refreshed/removed. This is done to prevent DDoS attacks (which is an issue with this project), though I will try to implement some form of protection (like signup and login process) in Weather-Report-2.0, a project that will be similar to this project.

This project was implemented for an assignment in CSE 445 (Distributed Software Development).
