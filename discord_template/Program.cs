using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Configuration;

namespace discord_template
{
    class Program
    {
        public static AppSettingsReader reader = new AppSettingsReader();

        private static DiscordSocketClient? _client;
        private static CommandService? _commands;

        public static void Main(string[] args)
        {
            // ギルドコマンドを登録する
            DirectoryInit.init();
            CommandSender.RegisterGuildCommands();
            Console.WriteLine("CommandSender SUCCESS!!");

            _ = new Program().MainAsync();

            Thread.Sleep(-1);
        }

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.Log += Log;
            _client.Ready += Client_Ready;
            _client.SlashCommandExecuted += SlashCommandHandler;
            _client.SelectMenuExecuted += SelectMenuHandler;
            _client.ModalSubmitted += ModalHandler;

            _commands = new CommandService();
            _commands.Log += Log;

            await _client.LoginAsync(TokenType.Bot, reader.GetValue("token", typeof(string)).ToString());
            await _client.StartAsync();

            // Block this task until the program is closed.
            while (true)
            {
                await Task.Yield();
            }
        }

        private Task Log(LogMessage message)
        {
            if (message.Exception is CommandException cmdException)
            {
                Console.WriteLine($"[Command/{message.Severity}] {cmdException.Command.Aliases.First()}" + $" failed to execute in {cmdException.Context.Channel}.");
                Console.WriteLine(cmdException);
            }
            else { Console.WriteLine($"[General/{message.Severity}] {message}"); }

            return Task.CompletedTask;
        }
        public async Task Client_Ready()
        {
            //クライアント立ち上げ時の処理
            await Task.CompletedTask;
        }

        //
        // そのうち消すかも
        private async Task SlashCommandHandler(SocketSlashCommand command)
        {
            _ = Task.Run(() =>
            {

            });

            await Task.CompletedTask;
        }

        //
        // セレクトメニューのイベント処理
        private static async Task SelectMenuHandler(SocketMessageComponent arg)
        {
            _ = Task.Run(() =>
            {

            });
            await Task.CompletedTask;
        }

        //
        // モーダルのイベント処理
        private static async Task ModalHandler(SocketModal modal)
        {
            _ = Task.Run(() =>
            {

            });

            await Task.CompletedTask;
        }
    }
}