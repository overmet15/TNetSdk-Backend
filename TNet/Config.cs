using CsToml;

namespace TNet;

internal class Config
{
    public static ushort Port = 6750;

    public static ushort MaxRooms = 100;
    public static ushort MaxClients = 500;

    public static ushort MinRoomIndex = 1000;
    public static ushort MaxRoomIndex = 9999;

    public static float HeartbeatTimeout = 10;

    public static string EncryptionKey = string.Empty;
    public static TNetGeneration Gen = TNetGeneration.Gen0;

    public static bool EnableMasterServer;
    public static string MasterAddress = string.Empty;
    public static string MasterEncryptionKey = string.Empty;
    public static string MasterAPIKey = string.Empty;


    public static void Read()
    {
        var assemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

        if (string.IsNullOrEmpty(assemblyPath)) throw new Exception("Error loading configs, assembly path is null.");

        var path = Path.Combine(Path.GetDirectoryName(assemblyPath)!, "Config.toml");

        using var configContents = new FileStream(path, FileMode.Open);

        var config = CsTomlSerializer.Deserialize<TomlDocument>(configContents).RootNode;
        
        Port = config["Port"].GetNumber<ushort>();

        MaxRooms = config["MaxRooms"].GetNumber<ushort>();
        MaxClients = config["MaxClients"].GetNumber<ushort>();

        MinRoomIndex = config["MinRoomIndex"].GetNumber<ushort>();
        MaxRoomIndex = config["MaxRoomIndex"].GetNumber<ushort>();

        HeartbeatTimeout = config["HeartbeatTimeout"].GetNumber<float>();

        EncryptionKey = config["EncryptionKey"].GetString();
        Gen = (TNetGeneration)config["Gen"].GetNumber<int>();

        EnableMasterServer = config["EnableMasterServer"].GetBool();
        MasterAddress = config["MasterAddress"].GetString();
        MasterEncryptionKey = config["MasterEncryptionKey"].GetString();
        MasterAPIKey = config["MasterAPIKey"].GetString();
    }
}
