# Weather-Report-1.0

The project is a simple weather report website made using ASP.NET and C#. The website provides 4 services. These services provide information such as the distance from one location to another location, determine the zipcode of the given location, provides a 5-day weather forecast at the given zipcode, and finds the closest store with the given name.

This project consists of 4 WCF Services:
- DistCalcService (Distance between 2 locations calculator)
- GeoCodeService (Geocoding Service)
- WeatherCondition (Weather Forecast Service)
- YelpStores (Yelp Location Service Implemented as a RESTful service)

The project also consists of the following ASP.NET Web Site:
- TryItWeather (consists of 4 pages to use the 4 services)

## DistCalcService (Distance between 2 locations calculator)

This service uses the Google Distance Matrix API to calculate the distance between two locations provided by the user. Please check the "Service1.svc.cs" file for the class format used to store the JSON response from the API. The function that calls the API is "DistanceCalculator". You can also check the webpage that is used to access the service at "TryItWeather/DistanceCalcTryIt.aspx", or the [webpage](http://webstrar3.fulton.asu.edu/page0/DistanceCalcTryIt), but ther deployed service will not work now (please check notes).

## GeoCodeService (Geocoding Service)



## WeatherCondition (Weather Forecast Service)

## YelpStores (Yelp Location Service Implemented as a RESTful service)





**Note:** The services used in this project were originally intended to be used to make one service: Getting the user's location, and the name of the store that they wanted to go to, determine the closest store with the given name, along with the zipcode and distance to that location, and the best time to go to the store, based on the 5-day weather forecast. Also, even though I deployed this project, some of the services will not work, because I refreshed the keys that the services use. This is done to prevent DDoS attacks, though I will try to implement some form of protection (like signup and login process) in Weather-Report-2.0. 
