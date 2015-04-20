# payments

This is a sandbox project with the following goals:

- Create an effective unit testing environment
- Separate the Web API Implementation from its Hosting Implementation (don't marry the API to System.Web or OWIN)
- Work out continuous deployment scenarios with different cloud platforms

**Solution Projects**

***Payments.Core***
Class Library
I'm trying to separate core models from anything to do with ASP.NET or any persistence solution.

***Payments***
ASP.NET Web Application.
Since the application is purely static files, this could be changed to a Web Site or be a great candidate for ASP.NET 5's wwwroot folder.

***Payments.API***
ASP.NET Web API Controllers. I'm pretty happy with separating this, but still struggling with where the Routing should go.

**Payments.Data.InMemory**
An in-memory implementation that mimics persistence.  Easy to test with or just to vet out interface.

**Payments.Api.WebHost**
A System.Web Web API Host that composes the other modules and runs in IIS.  The idea here is another host (a console application or Windows Service) could also be built up.

**Tests**
Solution Folder with Unit Tests. This effort is still small but the idea is to prove out that the tests take on the least and best dependencies (for example, why should API tests be dependent on the WebHost). There are two types of tests here:

***Controller Tests***
These use the controller unit test support enabled by the framework, meaning (among other things) that IHttpActionResult is returned from action methods. This assists in making it so you aren't testing anything but the controller.

***Acceptance Tests***
Another option is to create an in-memory server and then call the apis with standard HttpClient calls.  This is useful if you want to test in a more black box manner by testing inputs and outputs the way a consumer would see them (request and response headers and bodies, etc). This might be considered more like an integrated test or that it's testing too much of the WebAPI framework, but it can also be easier to relate to for non experts in the framework.

**Live Demo of Payments**

http://cg-payments-web.azurewebsites.net/

API at:

http://cg-payments-api.azurewebsites.net/
(Note: API uses CORS to allow clients and currently only configured to allow calls from web site above, so you can't actually use it. This could change if the project becomes a sample.)