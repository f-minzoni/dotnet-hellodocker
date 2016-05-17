FROM microsoft/dotnet
MAINTAINER Federico Minzoni, fminzoni@enter.it

RUN mkdir -p /dotnetapp

COPY . /dotnetapp

WORKDIR /dotnetapp

RUN ["dotnet", "restore"]

ENTRYPOINT ["dotnet", "run"]