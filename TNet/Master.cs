using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TNet;

internal class Master
{
	public static async Task<bool> IpBanned(string ip)
	{
		if (!Config.EnableMasterServer) return false;

		//ip = Hash(ip);

		return false;
	}

	private static string Hash(string input) => Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(input)));
}