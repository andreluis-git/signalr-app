using Poc.ChatConsoleApp;
string username = string.Empty;
string chatroom = string.Empty;

while (username == string.Empty && chatroom == string.Empty)
{
    try
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Digite o nome de usuario:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        username = Console.ReadLine() ?? throw new ArgumentNullException();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Digite o nome da sala:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        chatroom = Console.ReadLine() ?? throw new ArgumentNullException();
    } catch
    {
        Console.WriteLine("O usuário ou sala não podem ser vazios");
        username = string.Empty;
        chatroom = string.Empty;
    }
}


ClassHub conn = new ClassHub("http://localhost:5273/Chat", username, chatroom);
conn.Connect();

string? msg = "";

while (msg != "exit")
{
    msg = Console.ReadLine();
    if (msg is not null)
        conn.SendMessage(msg);
}