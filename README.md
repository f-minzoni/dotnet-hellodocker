## Getting Started with .NET Core and Docker

This short tutorial, assumes that you have Docker and Docker Compose installed and configured. The easiest way to get them is through [Docker Toolbox](https://www.docker.com/products/docker-toolbox) or the new [Docker Beta for Mac and Windows](http://beta.docker.com/docs)

If you are wondering what is [.NET Core](https://www.microsoft.com/net/core/platform) , it's a new set of runtime, library and compiler components for creating web applications and services that run on Windows, Linux and Mac. Moreover, it is fully open source!

If you want to jump in and look at the [C# code](https://github.com/f-minzoni/dotnet-hellodocker/blob/master/dotnetapp/Program.cs) in the dotnetapp folder. It's a console app, that tries to connect to a PostgreSQL database, init a table, just to persist a greeting, basically, the simple text "Hello Docker" : )

The complete definition of the applcation components, can be found in "Docker style" in the [docker-compose.yml](https://github.com/f-minzoni/dotnet-hellodocker/blob/master/docker-compose.yml) file:
```
version: '2'

services:
  app:
    build: dotnetapp/
    links:
      - db
  db:
    image: postgres
```


