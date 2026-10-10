# TrainingPaymentGateway
A payment gateway built in .NET to practice clean architecture, patterns, and cloud deployment

## Learning Log
### Why doesn't Domain reference Infrastructure?
because domain is the core of the application and shouldnt depend on the infrastructure layer
### What would break if you removed the -v flag and restarted the container?
 we will lose the data of the database if the container is deleted
### What does dotnet sln add actually change on disk?
it write the name of the project to the solution file doesnt change or add actual files.