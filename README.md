# CronService
This software is a service for working in the background. The mechanism of operation is the calling and parsing of the log file at regular intervals. If the specified time difference is formed between the timestamp records of the log file, the database is accessed and the specified query is executed.

CronService is a cross-platform software.

CronService is working:
- in the background
- in the console

For Linux:
- the deploying process is described in Linux control/Deploy
- the running/stopping is described in Linux control/Run and stop

For testing:
- Testing/testLogFile to see a format and to do test of the work
- Testing/configureTestDB.sql to configure your database before testing on creating table and function
- CronService.Presentation/appsettings.json to configure all mutable parameters
