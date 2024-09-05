using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{

    public string name;
    public int score;
    public Sprite avatar;
    public string avatarLink;
    public PlayerType type;

    public Player()
    {
        name = "Unnamed";
        score = 0;
        type = PlayerType.Default;
    }
    // More constructors should be here
    public Player(string name, int score, string avatarLink, PlayerType type)
    {
        this.name = name;
        this.score = score;
        this.avatarLink = avatarLink;
        this.type = type;
    }
    public Player(PlayerRaw playerRaw)
    {
        this.name = playerRaw.name;
        this.score = int.Parse(playerRaw.score);
        this.avatarLink = playerRaw.avatar;

        if (!Enum.TryParse<PlayerType>(playerRaw.type, out this.type))
        {
            this.type = PlayerType.Default;
        }
    }
    public enum PlayerType
    {
        Diamond,
        Gold,
        Bronze,
        Silver,
        Default
    }


    public static List<Player> ParsePlayers(string leaderboardJSON)
    {
        List<Player> convertedPlayers = new List<Player>();

        var jsonObject = JsonConvert.DeserializeObject<LeaderboardWrapper>(leaderboardJSON);

        foreach (PlayerRaw playerRaw in jsonObject.leaderboard)
        {
            Player newPlayer = new Player(playerRaw);
            convertedPlayers.Add(newPlayer);
        }

        return convertedPlayers;
    }

    private class LeaderboardWrapper
    {
        public List<PlayerRaw> leaderboard;
    }
    
}
public class PlayerRaw
{
    public string name = "Unnamed";
    public string score = "0";
    public string avatar;
    public string type = "Default";
}