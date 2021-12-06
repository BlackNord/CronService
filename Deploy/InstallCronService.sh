#!/bin/sh

#############################################################################
# Section of dotnet-sdk instalation
# Do not change this section manualy

echo Installation process of dotnet-sdk-6.0 is started...
echo Do not entry any symbols, only password is allowed

sleep 3

sudo snap install dotnet-sdk --classic

echo Installation process of dotnet-sdk-6.0 is finished

echo The current version of dotnet is:
sudo dotnet --version

#############################################################################
# Section of cloning the selected repositoruim 
# You can change this section manualy
# You can change the link to the repositorium to your own 
# Mutable parameter is "https://github.com/BlackNord/CronService.git"
# If you already have CronService in your system, you need to comment these 3 strings below

echo Clone process of CronService.git is started...

git clone https://github.com/BlackNord/CronService.git

echo Clone process of CronService.git is finished

#############################################################################
# Section of publishing CronService
# Do not change this section manualy

echo Publishing process of CronService is started...

dotnet publish CronService

echo Publishing process of CronService is finished

#############################################################################

echo Installation process of CronService is finished

echo Press Ctrl+C to quit

sleep 30
