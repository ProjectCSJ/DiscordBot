using Discord;
using Discord.Commands;
using Discord.WebSocket;

var token = "YOUR BOT TOKEN";
var client = new DiscordSocketClient();

client.Log += LogAsync;
client.Ready += OnReady;
client.MessageReceived += OnReceiveMessage;
client.SlashCommandExecuted += OnReceiveSlashCommand;

await client.LoginAsync(TokenType.Bot, token);
await client.StartAsync();

Task LogAsync(LogMessage message)
{
    if (message.Exception is CommandException cmdException)
    {
        Console.WriteLine($"[Command/{message.Severity}] {cmdException.Command.Aliases.First()}"
            + $" failed to execute in {cmdException.Context.Channel}.");
        Console.WriteLine(cmdException);
    }
    else
        Console.WriteLine($"[General/{message.Severity}] {message}");

    return Task.CompletedTask;
}

async Task OnReady() { }
async Task OnReceiveMessage(SocketMessage msg) { }
async Task OnReceiveSlashCommand(SocketSlashCommand cmd) { }
