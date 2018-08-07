using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class GameTimer : NetworkBehaviour {

    [SyncVar] public float gameTime = 120.0f; // game max time;
    [SyncVar] public float timer = -1.0f; // the current running time;
    [SyncVar] public int minPlayers = 1; // TEST = 1, PRODUCTION = ; minimum required player
    [SyncVar] public bool master = false; // true if the time is server time; all client timer synchronize from master
    Text textInfo;
    GameTimer serverTimer;

    private void Start()
    {
        textInfo = transform.GetComponent<Text>();
        if (isServer) {
            serverTimer = this;
            master = true;
            textInfo.text = "Game Hasn't Start Yet!";
        } else if (isClient) {
            GameTimer[] timers = FindObjectsOfType<GameTimer>();// give all timers
            for (int i = 0; i < timers.Length; i ++) { // loop find master
                if (timers[i].master) {
                    serverTimer = timers[i];
                    textInfo = timers[i].textInfo;
                }
            }

        }
    }
    private void Update()
    {
        if (master) {
            if (timer >= gameTime) {
                timer = -2;
                textInfo.text = "Game Finished";
            } else if (System.Math.Abs(timer - (-1)) < 0.0001) {
                if (NetworkServer.connections.Count < minPlayers) {
                    timer = -1;
                    textInfo.text = "Game Hasn't Start Yet!";
                } else {
                    timer = 0;
                }
            } else if (System.Math.Abs(timer - -2) < 0.0001) {
                timer = -2;
            }
            else {
                timer += Time.deltaTime;
                textInfo.text = "Time is Passed: " + timer + "s";
            }  
        } 

        if (isLocalPlayer) {
            if (serverTimer) {
                gameTime = serverTimer.gameTime;
                timer = serverTimer.timer;
                minPlayers = serverTimer.minPlayers;
                textInfo = serverTimer.textInfo;
            } else {
                Debug.Log("Something else happens");
            }
        }
    }
}
