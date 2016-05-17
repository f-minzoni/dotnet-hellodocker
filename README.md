## Getting Started with .NET Core and Docker

This short tutorial, assumes that you have Docker and Docker Compose installed and configured. The easiest way to get them is through [Docker Toolbox](https://www.docker.com/products/docker-toolbox) or the new [Docker Beta for Mac and Windows](http://beta.docker.com/docs)

If you are wondering what is [.NET Core](https://www.microsoft.com/net/core/platform) , it's a new set of runtime, library and compiler components for creating web applications and services that run on Windows, Linux and Mac. Moreover, it is fully open source!

If you want to jump in and look at the [C# code](https://github.com/f-minzoni/dotnet-hellodocker/blob/master/dotnetapp/Program.cs) in the dotnetapp folder. It's a console app, that tries to connect to a PostgreSQL database, init a table, just to persist a greeting, basically, the simple text "Hello Docker" : )

The complete definition of the application components, can be found in "Docker style" in the [docker-compose.yml](https://github.com/f-minzoni/dotnet-hellodocker/blob/master/docker-compose.yml) file:
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
* our .NET sample app
* ... a PostgreSQL database, based on the latest official [Docker Image](https://hub.docker.com/_/postgres/)

To run the application, you need to:

1. open a terminal, configured with the right DOCKER_HOST env

2. change the working dir to the root of this repo

3. ...execute the following command:

```
docker-compose up -d
```
If you don't have the Postgres and [microsoft/dotnet](https://hub.docker.com/r/microsoft/dotnet/) Docker images, the client will first pull those base images and then builds the dotnetapp, as described in the [Dockerfile](https://github.com/f-minzoni/dotnet-hellodocker/blob/master/dotnetapp/Dockerfile).
If everything went well, Docker Compose, first try to run the database and then the dependent console app:
```
...
Successfully built 345ed606caa8
WARNING: Image for service app was built because it did not already exist. To rebuild this image you must use `docker-compose build` or `docker-compose up --build`.
Creating dotnethellodocker_db_1
Creating dotnethellodocker_app_1
```

Finally, you can check if the console app has been executed correctly, with the following command:

```
docker-compose logs app
Attaching to dotnethellodocker_app_1
app_1  | Project dotnetapp (.NETCoreApp,Version=v1.0) will be compiled because expected outputs are missing
app_1  | Compiling dotnetapp for .NETCoreApp,Version=v1.0
app_1  | 
app_1  | Compilation succeeded.
app_1  |     0 Warning(s)
app_1  |     0 Error(s)
app_1  | 
app_1  | Time elapsed 00:00:05.9834689
app_1  |  
app_1  | 
app_1  | Hello Docker

```

Hello Docker : )

