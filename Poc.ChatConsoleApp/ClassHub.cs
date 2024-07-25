using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poc.ChatConsoleApp
{
    public class ClassHub
    {
        HubConnection connection;
        string _server;
        string _username;
        string _chatroom;
        

        public ClassHub(string server, string username, string chatroom)
        {
            _server = server;
            _username = username;
            _chatroom = chatroom;
        }

        public async void Connect()
        {
            connection = new HubConnectionBuilder().WithUrl(_server).Build();
            await connection.StartAsync();

            connection.On("ReceiveSpecificMessage", (string username, string msg) =>
            {
                if(username != _username)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{msg}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($" - {username}");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            });

            await connection.InvokeAsync("JoinSpecificChatRoom", new { username = _username, chatroom = _chatroom });
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{_username} has joined {_chatroom}");
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public async void SendMessage(string msg)
        {
            try
            {
                await connection.InvokeAsync("SendMessage", msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
