using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject[] playerPrefabs;

    private PlayerPlatformerController[] playerFighterList;
    private static GameController instance;
    
    public static GameController Instance() {
        return instance;
    }

    public PlayerPlatformerController[] GetAllPlayers() {
        return playerFighterList;
    }

    private void Awake() {
        instance = this;
    }
    
    public void UpdateOpponentTanks(RTPacket _packet) {

    }

    public void InstantiateOpponentShells(RTPacket _packet) {

    }

    public void UpdateOpponentShells(RTPacket _packet) {

    }

    public void RegisterOpponentCollision(RTPacket _packet) {

    }

    public void OnOpponentDisconnected(int _peerId) {

    }
}
