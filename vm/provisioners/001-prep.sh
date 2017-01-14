#!/usr/bin/env bash

echo "-----------"
echo "Prepping OS"
echo "-----------"

echo "Performing apt-get update"
apt-get update

echo "Updating OS"
sudo apt-get dist-upgrade

echo "Installing curl"
sudo apt-get install -y curl
