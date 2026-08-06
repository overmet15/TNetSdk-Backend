namespace TNet;

internal enum TNetGeneration
{
    /// <summary>
    /// CoM:Z, TLCK
    /// </summary>
    Gen0 = 0,
    /// <summary>
    /// CoM:DH
    /// </summary>
    Gen1 = 1,
    /// <summary>
    /// CoM:Infinity
    /// </summary>
    Gen2 = 2
}

/*
 * The difference between gens is quite big
 * On Gen 0 server has to send the JoinRoomRes to the room's creator after creating a room.
 * But on Gen 1 Client automatically sends a join request to the room after Create Room Response. 
 * 
 * Gen 2 is a compleatly different story, it has like 15 additional commands
 * and some implementations that dont exist in most of the games.
 */