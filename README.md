# TrainingPaymentGateway
A payment gateway built in .NET to practice clean architecture, patterns, and cloud deployment

## Learning Log
### Day 1
### Why doesn't Domain reference Infrastructure?
because domain is the core of the application and shouldnt depend on the infrastructure layer
### What would break if you removed the -v flag and restarted the container?
 we will lose the data of the database if the container is deleted
### What does dotnet sln add actually change on disk?
it write the name of the project to the solution file doesnt change or add actual files.

### Day 2
### Why decimal for money and never double?
decimal is morea ccurate for calculations. double produce rounding issues.
### Why a static Create method instead of a public constructor?
sattic Create allow for better control and validation before creating the object itself
### What's the difference between this "rich" model and an "anemic" one with public setters, and which bugs does yours prevent?
rich model is handling your own setting logic. what we prevent is that we can validate the data before setting it. anemic model is just a data structure with no logic.