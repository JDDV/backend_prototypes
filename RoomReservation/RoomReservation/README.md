##.NET backend

This backend is built using .NET using a SQL database that both runs in Docker containers.

###Prerequisites:

* IDE (IntelliJ for example)
* Docker
* Postman (optional)

###how to run:

It's very easy to run the application using docker. all you need to do is type in the terminal: `docker-compose up --build`.
Now the user can register using the `/api/authentication/register` endpoint.
Once the user is made the user can login using `/api/authentication/login`.
This will generate a JWT token that should be used for all the other calls, except for the 'sign up' and 'get all rooms' call.


Once the app is started the rooms will be in the database already hardcoded as mentioned by the assignment description.
Included in this repository is also a postman collection with all the available calls and already pre-filled bodies for the requests.
