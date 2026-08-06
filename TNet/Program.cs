using TNet;
using TNet.Helpers;

Console.CursorVisible = false;
Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;


Config.Read();

// log

Logger.Info($"Gen set to '{Config.Gen}'");

EncrpytionHelper.Initialize();

Logger.Info($"Heartbeat Timeout (seconds): '{Config.HeartbeatTimeout}'");

Logger.Info($"Max rooms: '{Config.MaxRooms}'");
Logger.Info($"Max clients: '{Config.MaxClients}'");

//Logger.Info($"Minimum room id: '{Variables.MinRoomValue}'");
//Logger.Info($"Maximum room id: '{Variables.MaxRoomValue}'");

if (Config.MinRoomIndex > Config.MaxRoomIndex)
{
    Logger.Error("Minimum room id cannot be bigger than maximum. Aborting.");
    return;
}

// Prevent from typing.
_ = Task.Run(() => { while (true) Console.ReadKey(true); });

await Lobby.Run(Config.Port);