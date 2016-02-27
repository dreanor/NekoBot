﻿using DiscordSharp;
using NekoBot.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace NekoBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Config config = LoadConfig();
                DiscordClient client = new DiscordClient();
                MessageService messageService = new MessageService(client, config);

                Login(client, messageService, config);

                Console.WriteLine("Press enter to Exit.");
                Console.ReadLine();
                client.Logout();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadKey();
            }
        }

        private static Config LoadConfig()
        {
            try
            {
                if (!File.Exists("config.json"))
                {
                    string json = JsonConvert.SerializeObject(GetDefaultConfig(), Formatting.Indented);
                    File.WriteAllText("config.json", json);
                    ThrowCredentialsException();
                }

                return JsonConvert.DeserializeObject<Config>(File.ReadAllText("config.json"));
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static Config GetDefaultConfig()
        {
            return new Config("email", "password", new List<string> { "admin", "mod" }, new List<string> { "nekobot", "general" });
        }

        private static void Login(DiscordClient client, MessageService messageService, Config config)
        {
            client.ClientPrivateInformation.email = config.Email;
            client.ClientPrivateInformation.password = config.Password;
            client.MessageReceived += messageService.MessageReceived;
            client.PrivateMessageReceived += messageService.PrivateMessageReceived;

#if DEBUG
            client.TextClientDebugMessageReceived += (o, e) => Console.WriteLine(e.message.Message);
#endif

            try
            {
                client.SendLoginRequest();
            }
            catch (Exception)
            {
                ThrowCredentialsException();
            }

            Thread t = new Thread(client.Connect);
            t.Start();
        }

        private static void ThrowCredentialsException()
        {
            throw new InvalidOperationException("Couldn't connect to Discord. Please check your credentials in the config.json file.");
        }
    }
}
