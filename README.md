Usage: Install any IDE (c#) Preferably JetBrainsRider v(2024.1.1)  
(To grab the data from the SMHI API i did some magical stuff with the IDE i don't remember. :/)  
Clone project. (.NET 8.0)  
Run with Program.cs  
  
Code:  
Program.cs, starts the application  
WeatherApp.cs, user interface, updates weather  
SmhiWeatherService.cs, communicates with SMHI's API, returns current weather  
WeatherData.cs, stores weatherdata, temperature, humidity (NOT condition - explained below)  
City.cs, stores city data (coordinates, name, weather) 
  
Condition:  
Returning the condition does not work. There are simply too many conditions that i didn't want to include. The code i already have wouldn't look nice with 300 lines of conditions.  
See: https://opendata.smhi.se/metobs/codes  
