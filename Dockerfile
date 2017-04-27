FROM ubuntu:16.04

ENV appDir /var/app

RUN apt-get update && apt-get install -y apt-transport-https
RUN sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ xenial main" > /etc/apt/sources.list.d/dotnetdev.list'
RUN apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 417A0893
RUN apt-get update && apt-get install -y dotnet-dev-1.0.0-preview2-1-003177

RUN mkdir -p ${appDir}
WORKDIR ${appDir}

EXPOSE 5000

ADD ./src/MVCWeather/bin/Release/netcoreapp1.1/publish ./
cmd ["dotnet", "MVCWeather.dll"]
