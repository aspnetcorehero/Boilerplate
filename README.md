# Clean Architecture Boilerplate - ASP.NET Core 5.0 (WebApi & MVC)
Clean Architecture Solution Template for ASP.NET Core 5.0. Built with Onion/Hexagonal Architecture and incorporates the most essential Packages your projects will ever need. Includes both WebApi and Web(MVC) Projects.

# Coming Soon.
Will be soon available at the Nuget Store.

# The Vision

An idea to bring together the best and essential practices / pacakges of ASP.NET Core 5.0 along with Clean Hexagonal Architecture that can be a right fit for small/mid and enterprise level solutions.
How easy would it be if you are able to run a single line of CLI command on your Console and you get a complete implementation in no time? That's the exact vision I have while building this full fledged Boilerplate template.

## Technologies Used

- ASP.NET Core 5.0 WebAPI
- ASP.NET Core 5.0 MVC
- Entity Framework Core 5.0

## Give a Star ⭐️
If you found this Implementation helpful or used it in your Projects, do give it a star. Thanks!
Or, If you are feeling really generous, [Support the Project with a small contribution!](https://www.buymeacoffee.com/codewithmukesh)

## Quick Start Guide
Since the project is still under developement, the CLI features are not yet available. Although you can clone / fork / download the repository and execute it locally on your machine. Here are the steps involed.
1. Download / Fork this Repository
2. Open up the Solution File in Visual Studio 2019 (v16.8+) . Make sure you have the .NET 5 SDK installed.
3. Give it a few moment for the solution to restore all the required packages from NuGet store.
4. Open up appsettings.json on each of the WebAPI and MVC Project. Make sure to update the Connection strings with valid ones.
5. Open up Package Manager Console. 
    1. Set the API Project as the Startup Project.
    2. Set the Infrastructure Project as the Default project. (You can typically find this dropdown on the Package Manager Console tab somewhere on the top corner)
    3. Run the following commands to add migrations(if any).
      ```
      add-migration initialbuild -context ApplicationDbContext
      add-migration initialbuild -context IdentityContext
      ```
    4. Next, let's update our database with the newly created migrations.
      ```
      update-database -context ApplicationDbContext
      update-database -context IdentityContext
      ```
6. That's almost everything you will have to do to get started with this project. More details will be posted once the Project is at it's pre-production stage. Cheers!

### Default Roles & Credentials
As soon you build and run your Awesome Application, default users and roles get added to the database.

Default Roles are as follows.
- SuperAdmin
- Admin
- Moderator
- Basic

Here are the credentials for the default users.
- Email - superadmin@gmail.com  / Password - 123Pa$$word!
- Email - basic@gmail.com  / Password - 123Pa$$word!

You can use these default credentials to generate valid JWTokens at the ../api/account/authenticate endpoint.

## Features Included

### ASP.NET Core 5.0 MVC Project
- Slim Controllers using MediatR Library
- Permissions Management based on Role Claims
- Toast Notification (includes support for AJAX Calls too)
- Serilog
- ASP.NET Core Identity
- AdminLTE Bootstrap Template (Clean & SuperFast UI/UX)
- AJAX for CRUD (Blazing Fast load times)
- jQuery Datatables
- Select2
- Image Optimization
- Includes Sample CRUD Controllers / Views
- Active Route Tag Helper for UI
- RTL Support
- Complete Localization Support / Multilingual
- Clean Areas Implementation
- Dark Mode!
- Default Users / Roles Seeding at Startup
- Supports Audit Logging / Activity Logging for Entity Framework Core
- Automapper

### ASP.NET Core 5.0 WebAPI
- JWT & Refresh Tokens
- Swagger

(will be updated soon)

## Support

Has this Project helped you learn something New? or Helped you at work? Do Consider Supporting. Here are a few ways by which you can support.

- Leave a star!
- Recommend this awesome project to your colleages.
- Do consider endorsing me on LinkedIn for ASP.NET Core - [Connect via LinkedIn](https://www.linkedin.com/in/iammukeshm/)
- Or, If you want to support this project on the long run, consider buying me a coffee.

<a href="https://www.buymeacoffee.com/codewithmukesh" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/default-orange.png" alt="Buy Me A Coffee" width="200"  ></a>


## About the Authors

### Mukesh Murugan
- Blogs at [codewithmukesh.com](https://www.codewithmukesh.com)
- Facebook - [codewithmukesh](https://www.facebook.com/codewithmukesh)
- Twitter - [Mukesh Murugan](https://www.twitter.com/iammukeshm)
- Twitter - [codewithmukesh](https://www.twitter.com/codewithmukesh)
- Linkedin - [Mukesh Murugan](https://www.linkedin.com/in/iammukeshm/)
