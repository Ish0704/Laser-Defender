using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSON : MonoBehaviour
{
    Player playerInstance = new Player();
    
    void Start()
    {
        playerInstance.playerId = "8484239823";
        playerInstance.playerLoc = "Powai";
        playerInstance.playerNick = "Random Nick";

        //Convert to JSON
        string playerToJson = JsonUtility.ToJson(playerInstance);
        Debug.Log(playerToJson);

        string jsonString = "{\"playerId\":\"8484239823\",\"playerLoc\":\"Powai\",\"playerNick\":\"Random Nick\"}";
        Player player = JsonUtility.FromJson<Player>(jsonString);
        Debug.Log(player.playerLoc);
    }
}
[Serializable]
public class Player
{
    public string playerId;
    public string playerLoc;
    public string playerNick;

}
