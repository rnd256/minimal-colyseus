using System;
using Colyseus;
using UnityEngine;

public class GameController : MonoBehaviour {
  async void Start() {
    Client client = new Colyseus.Client("ws://localhost:2567");

    try {
      Room<State> room = await client.JoinOrCreate<State>("demo");
      Debug.Log("Joined room successfully!");
    } catch (Exception e) {
      Debug.Log("Error joining: " + e.Message);
    }
  }
}
