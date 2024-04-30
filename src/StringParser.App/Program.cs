using StringParser.App;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.CommandLine;

// Setups up default hosting model
var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureLogging(logging => logging.ClearProviders());
builder.ConfigureServices(services => services.AddTransient<StringParserService>());

// Builds and runs the app, then runs the command line tool, then stops the app.
var app = builder.Build();
await app.StartAsync();
await GetRootCommand().InvokeAsync(args);
await app.StopAsync();


// Returns the root command
RootCommand GetRootCommand()
{
    // Adds the message argument to the root of the CLI
    var messageArgument = new Argument<string>("message", "An argument that is parsed as a string.");
    var rootCommand = new RootCommand
    {
        messageArgument
    };

    // Tells the root to assume the message argument was passed
    rootCommand.SetHandler((messageArgumentValue, stringParserService) =>
    {
        // Pass input to service and return to user
        Console.Write(stringParserService.Parse(messageArgumentValue));
    },
        // ties the two inputs to the SetHandler action
        messageArgument,
        new GenericBinder<StringParserService>(app.Services));

    return rootCommand;
}
