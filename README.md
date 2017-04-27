<img src="https://travis-ci.org/tsears/MVCWeather.svg?branch=master" align="right"/>

# Weather #

A clean, modern site for current weather and forecasts.  I built this over the course
of about a week to experiment with asp.net on linux through .net core.  I also wanted
to focus on design elements to get a clean look and feel.

* html
* css (sass/scss)
* javascript (es6)
* angular
* asp.net mvc / WebAPI
* gulp
* linux (ubuntu)
* nginx
* Vagrant
* git (github)
* Visual Studio Code
* Docker

## Running for dev ##

Soon..
~~~sh
vagrant up
vagrant ssh
cd /MVCWeather
dotnet restore src/MVCWeather
dotnet restore test/MVCWeather.Tests
dotnet build src/MVCWeather --no-incremental
dotnet build test/MVCWeather.Tests --no-incremental
dotnet test test/MVCWeather.Tests
~~~

## Docker ##

Prereq: memcache

~~~sh
docker pull memcached
docker run --name something-memcached -d memcached
~~~

Run the container

~~~sh
docker build -t tsears/weather ./
docker run -i -t --env-file .env.list -p 127.0.0.1:5000:5000 --link something-memcached:memcache tsears/weather
~~~
