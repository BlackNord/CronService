#!/bin/sh

#############################################################################
# Section of running CronService in the console
# Log of the work is in the console
# You can change this section manualy
# If you want to run CronService in the background, comment the line below

# dotnet run --project ../../CronService.Presentation

#############################################################################
# Section of running CronService in the background
# Log of the work is in the nohup.out file
# You can change this section manualy
# If you want to run CronService in the console, comment the line below

nohup dotnet run --project ../../CronService.Presentation command &

#############################################################################

echo CronService is started

echo Press Ctrl+C to quit

sleep 30
