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

### Day 3

### What is __EFMigrationsHistory for, and what happens if you run Update-Database twice?
migrationhistory is the table that keep track of all the migrations that occured. when u run same migration twice, it will not apply as it will check the history first
### Why use Fluent API configuration instead of [MaxLength] attributes on Payment? (Think about Day 1.)
in adding attributes in payment would go against the clean architecture principle . domain should not be aware of the database
### Why store Status as a string instead of the default int?
to keep the column readable and avoid confusion with the enum values. if we store as int, it will be hard to know what the value means without looking at the enum definition.


### Day 4

### DbContext is already a Unit of Work and DbSet is already a repository. So why wrap them? Give one argument for and one against, then your own opinion. (There's no single right answer; interviewers want to see you reason about trade-offs.)
wraping them allows for more flexibility in the future if we want to change the underlying data access technology like switching from EF to Dapper.
an argument against is that it adds complexity. But in my opinion , the flexibility it gives is worth that tiny extra complexity.
### Why doesn't the repository need an Update method?
update is handled by the dbcontext , calling the savechanges should update the entity
### Why AddScoped and not AddSingleton for these? What would go wrong with singleton?
singelon will make the repository saved in memory for all requests and will cause concurency issues, addscoped here will create a new instance for each request avoiding those issues. transcient would work but it would make performance worse as it will create a new instance for each injection.


### Day 5

### Why return PaymentResponse instead of the Payment entity directly? Name two concrete problems.
We can set exactly what we want to return.
Also we dont need to leak all the payment data as a response

### What does CreatedAtAction add to the response besides the 201 status? (Look at the response headers in Swagger.)
it adds the endpoint to get the details of that newly created payment

### Why 409 for capturing twice, and not 400?
409 is conflict cause the payment is there, but this capture processing can only be done once thus resulting in a conflict