# Flight Assistant

Flights can be filtered with following values:
  - Departure airport (dropdown options from backend)
  - Arrival airport (dropdown options from backend)
  - Departure date (date picker)
  - Return date (date picker)
  - Currency (dropdown options from backend)
  - Number of passangers (number input)
  
 Flights table is made of following columns:
  - Departure airport (IATA code)
  - Arrival airport (IATA code)
  - Departure date
  - Arrival date
  - Return date
  - Number of passangers
  - Number of layovers
  - Grand total price
  - Currency (alphabetic code)
  
 Table suports server side pagination.
 
 If data for selected filter criteria is found in DB - that data is returned.
 If no data is found in DB for selected criteria - Flights data for that criteria is fetched from Amadeus API. If some data is found on Amadeus API it is saved in DB and returned.
 Next time the same filter criteria is requested data will be returned from DB and no request to Amadeus API is made.
 
 Currency codebook is populated before first usage from local json file with currencies.
 Airport codebook is populated before first usage from Wikipedia page provided in task using custom scrapper.
 
 Amadeus API auth_token is saved in cache for X (configurable in appsettings.json, I set it to 29 because token duration is 30) minutes. After it is removed from cache new access_token is retrieved and stored in cache again.  

![image](https://user-images.githubusercontent.com/36966269/224567795-bd4cbf74-6e19-4209-b800-24529e846b87.png)
