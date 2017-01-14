#!/usr/bin/env bash
echo "-----------------"
echo "Installing Nodejs"
echo "-----------------"

echo "Adding apt feed"

curl -sL https://deb.nodesource.com/setup_6.x | sudo -E bash -

echo "Installing"

sudo apt-get install -y nodejs
sudo apt-get install -y build-essential
