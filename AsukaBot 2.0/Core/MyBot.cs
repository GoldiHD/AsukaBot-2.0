﻿using System;
using Discord.WebSocket;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using System.IO;
using Discord;
using System.Reflection;

namespace AsukaBot_2._0.Core
{
    class MyBot
    {
        private string botToken;
        public static DiscordSocketClient client;
        private CommandService command;
        private IServiceProvider service;
        private Random RNG = new Random();

        public async Task Start()
        {
            Console.WriteLine("Created by Lars H M/Goldi");
            if(Directory.Exists(Directory.GetCurrentDirectory()+ "//assets"))
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "//assets//credentials.txt"))
                {

                    client = new DiscordSocketClient();
                    command = new CommandService();

                    botToken = File.ReadAllText(Directory.GetCurrentDirectory() + "//assets//credentials.txt").Remove(0, 15);
                    //SingleTon.GetRPGThread().StartUp();
                    //SingleTon.SetClient(client);
                    //event subcribsion
                    client.Log += Log;
                    client.UserJoined += AnnouceUserJoined;
                    await ChangeStatus();

                    try
                    {
                        await RegisterCommandAsync();
                    }
                    catch
                    {
                        Console.WriteLine("");
                        Console.ReadKey();
                    }

                    try
                    {
                      

                        await client.LoginAsync(TokenType.Bot, botToken);
                    }
                    catch
                    {
                        Console.WriteLine("your token seems to be incorrect, check credentials.txt and see if you have given it the correct token yet\n[Press enter to continue]");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    //SingleTon.GetConsoleCheckerInstance().StartUp();
                    await client.StartAsync();
                    await Task.Delay(-1);
                }
                else
                {
                    Console.WriteLine("no credentials file could be found at: " + Directory.GetCurrentDirectory() + "//assets//credentials.txt \nso one have been created");
                    File.WriteAllText(Directory.GetCurrentDirectory() + "//assets//credentials.txt", "Discord token: ");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("no credentials file could be found at: " + Directory.GetCurrentDirectory() + "//assets//credentials.txt \nso one have been created and you might be missing some of the asset files intented for the programs");
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "//assets");
                File.WriteAllText(Directory.GetCurrentDirectory() + "//assets//credentials.txt", "Discord token: ");
                Console.ReadKey();
            }
        }

        private async Task AnnouceUserJoined(SocketGuildUser user)
        {
            SocketGuild guild = user.Guild;
            SocketTextChannel channel = guild.DefaultChannel;
            await channel.SendMessageAsync($"Welcome, {user.Mention}");
        }

        public async Task ChangeStatus()
        {
            string[] GameStatues = new string[] { "Working on code with senpai", "Deleting code", "Selling user data to FBI", "Creating virus", "9/11 was an inside job", "The earth is flat", "Leading the communist party", "Making memes", "Ruining peoples lifes", "iuewfusdnkvnsoefnsef, i fell a sleep on the keyboard again", "Being a chad", "delaying berserk", "Reading shitty managa", "Investigating 9/11", "totally not prepering for the singularity", "Goldi puts the I in autism", "Missing what makes me whole", "Crying myself to sleep yet again", "Laugthing with her again", "Dreaming of how it could have been", "For the emperor" };
            await client.SetGameAsync(GameStatues[RNG.Next(0, GameStatues.Length)]);
        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        public async Task RegisterCommandAsync()
        {
            client.MessageReceived += HandleCommandAsync;
            await command.AddModulesAsync(Assembly.GetEntryAssembly());
            //await command.AddModuleAsync<StandardCommands>();
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            SocketUserMessage message = arg as SocketUserMessage;
            if (message == null || message.Author.IsBot)
            {
                return;
            }
            int argPos = 0;
            if (message.HasStringPrefix("!", ref argPos) || message.HasMentionPrefix(client.CurrentUser, ref argPos))
            {
                SocketCommandContext context = new SocketCommandContext(client, message);
                IResult result = await command.ExecuteAsync(context, argPos, service);
                if (!result.IsSuccess)
                {
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }
    }
}
