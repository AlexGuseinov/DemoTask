# Demo Task


## Application's endpoints below:  

- /api/Movie/GetByName  
    takes string movie name from query and gets results related to movie.  
- /api/Watchlist/Add  
    movie Id (imdb id from getByName endpoint) and random user id (since we assume user management is already implemented in an existing system) posted within body  
- /api/Watchlist/GetAllMoivesByUserId  
    user id used for retrieving all movies in user's watchlist   
- /api/Watchlist/SetMovieAsWatched  
    user id and and movieId (imdb id from getByName endpoint) for setting movie as watched


##  

IMDB API that you porvided   https://imdb-api.com/api was not accessible that's why I used 2 api from Rapidapi.com as my external movie data source.   
https://rapidapi.com/apidojo/api/online-movie-database      
https://rapidapi.com/Glavier/api/imdb146

As a database I used https://neon.tech/ 's database which is Postgre based online database and provides somewhat of 2 GB of memory for storage and usage within their free plan. Connection string is in the appsettings.json file . You can use the connection string to connect to the database with using Navicat or Datagrip. Or just change it to your database and apply a migration then you are ready to use the application.

As a SMTP service I used google's smtp service. Configurations are also in the appsettings.json  and you can change "DummyUserEmail": "ali.guseynof2503@gmail.com" to your email address as I was sending mails to my self for testing purposes.

Recurring background job is set to fire everysunday at 19:30 and for testing purposes from appsettings.json file you can change it's schedule to this one "CronSchedule": "10 * * * * ?" which fires in every 10th seconds of every minute.
