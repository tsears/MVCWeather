#!/usr/bin/env bash

echo "--------------------"
echo "Installing .NET Core"
echo "--------------------"

echo "Adding apt feed"

sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ trusty main" > /etc/apt/sources.list.d/dotnetdev.list'
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 417A0893
sudo apt-get update

echo "Installing dotnet"
apt-get install -y dotnet-dev-1.0.0-preview2.1-003177

echo "Set dotnet environment"
export ASPNETCORE_ENVIRONMENT=Development
