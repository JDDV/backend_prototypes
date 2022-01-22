##Spring boot backend

This backend is built using spring boot using an embedded Postgres database.

###Prerequisites:

* IDE (IntelliJ for example)
* Postgres database
* Postman (optional)

###how to run:
Make sure the dependencies are downloaded that are in the `pom.xml` file.
After running the project, first you need to add roles to the database by doing the following query:

```
INSERT INTO roles(name) VALUES('ROLE_USER');
INSERT INTO roles(name) VALUES('ROLE_MODERATOR');
INSERT INTO roles(name) VALUES('ROLE_ADMIN');
```

This will add the roles in the database.

Now the user can register using the `/api/auth/singup` endpoint.
Once the user is made the user can login using `/api/auth/signin`.
This will generate a JWT token that should be used for all the other calls, except for the 'sign up' and 'get all rooms' call.


Once the app is started the rooms will be in the database already hardcoded as mentioned by the assignment description.
Included in this repository is also a postman collection with all the available calls and already pre-filled bodies for the requests.
