using System;
using Colyseus;
using UnityEngine;

public class GameController : MonoBehaviour {
  async void Start() {
    Client client = new Colyseus.Client("ws://localhost:2567");

    Room<State> room;
    try {
      Debug.Log("Joining room...");
      room = await client.JoinOrCreate<State>("demo");
      Debug.Log("Joined room successfully!");
    } catch (Exception e) {
      Debug.Log("Error joining: " + e.Message);
      return;
    }

    room.OnError += (int code, string message) => {
      Debug.Log(string.Format("Error code {0}. Message: {1}", code, message));
    };

    room.OnLeave += (NativeWebSocket.WebSocketCloseCode code) => {
      Debug.Log(string.Format("Leaving room with code: {0}", code));
    };
  }
}
