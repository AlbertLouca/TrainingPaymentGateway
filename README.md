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
it adds the endpoint in the location header to get the details of that newly created payment 

### Why 409 for capturing twice, and not 400?
409 is conflict cause the payment is there, but this capture processing can only be done once thus resulting in a conflict


### Day 6

### In the capture UPDATE statement, which columns did EF set, and why only those?
only the update column as this is the only column that changed in the tracking
### Does [ProducesResponseType] change what the endpoint actually returns? What is it for?
no it doesnt, it just clarifies the possible response types
### Why have a separate GetByIdForReadAsync instead of putting AsNoTracking on the one method?
as no tracking make the instance not tracked, increasing the performance of the app. but putting asnotracking on every get will remove the possibility of saving the context.


### Day 7  wrap-up

### Walk me through what happens, layer by layer, when POST payments/id/capture is called.
validation on the guid in controller, infrastrucure layer will extract payment by id. domain will validate on the status if its ok, domain will update the status and infra will save the changes. controller will return the response with the status code
### Two requests capture the same payment at the exact same moment. What happens in your current code?
currently, if two requests read the same payment status at the same time, they will both perform the update and save the changes, resulting in a race condition. The last one to save will overwrite the first one, leading to inconsistent state.
### When would AsNoTracking cause a bug, and when is it the right choice?
As no tracking will cause a bug when we will need to update the entity after reading it as its not tracked and savechanges will not do anything. its the right choice if we only want to read it without updating it, as it will improve performance and reduce memory usage.


### Day 8 

### Why is IPaymentProvider in Domain and NileTelcoProvider in Infrastructure? (One line; you know this one now.)
the provider itslef is an infrastructure concern the domain should only see an interface. this also make the testing easier for mocking.
### Why deterministic failures instead of Random?
to make the tests more predictable and reliable, allowing for consistent results and easier debugging.
### Why is singleton fine for NileTelcoProvider but was wrong for PaymentRepository? What would make it wrong for the provider too? (Hint: Day 7, captive dependency.)
its ok for the provider to be singleton as it has no state if it had state singleton will cause data corruption.