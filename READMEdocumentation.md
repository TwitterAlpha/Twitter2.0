#BackUp TWITTER App Documentation

## Project Description

This is a **ASP.NET Core MVC application**  where the users can store the posts of their favorite Twitter users and then to re-tweet some of the tweets.

The application have:
* must have **public part** (accessible without authentication)
* must have **private part** (available for registered users)
* should have **administrative part** (available for administrators only)

### Public Part

![Landing page](~/images/pic1.png)

The **public part** of the application is **visible without authentication**. This includes:

- Landing page - here is displayed basic feature informationn that users can do in the application
- Login page
- Register page
- About Us page - basic information about the authors

### Private Part (Users only)

**Registered users** have private part in the web application accessible after **successful login**. They are able to:

- Search favorite twitter accounts, store them in the app DB.
- Download tweets from their favorite twitter accounts and store them in the app DB.
- Retweet downloaded twitter tweets/ after twitter authentification login/.

### Administration Part

**Administrators** have administrative options for:
- View **user statistics** : user, favorite twitter accounts count, downloaded tweets count, retweets count
- Management part:
    - Admin can **view** user account
    - Admin can **delete** user account, user favorite twitter account or downloaded tweets.
    - Also Admin can **edit** user account properties: 
        - User birthdate
        - User picture
        - User name
        - Make given user Admin

## Additional application info:
- The application is based on **ASP.NET Core MVC**, **MS SQL Server** as database back-end.
- Used IDE - **Visual Studio 2017**.
- Used **Entity Framework Core** to access database.
- User **Repository pattern** and **Service Layer**.
- Used **one Area** for administration.
- Used  **ASP.NET Identity System** for managing users and roles.
- Used the default dependency container (or Autofac/Ninject/Unity) and **Automapper**.
- Written more than **200 Unit Tests** for the logic, controllers, actions, helpers, routes, etc.
- Applied **error handling** and **data validation** to avoid crashes when invalid data is entered (both client-side and server-side).

