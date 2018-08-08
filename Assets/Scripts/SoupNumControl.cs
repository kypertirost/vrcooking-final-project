using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine;

public class SoupNumControl : NetworkBehaviour {
    
    public Text soupText;
    public GameObject Timer;
    GameTimer gameStatus;
    private int numSoup;

    private bool start = false;

    private void Start()
    {
        start = true;
        gameStatus = Timer.GetComponent<GameTimer>();
        Debug.Log(gameStatus);
        numSoup = 0;
        soupText.text = "You Finished: " + numSoup.ToString() + " soups";
        
    }

    private void Update()
    {
        
        if (gameStatus != null && System.Math.Abs(gameStatus.timer - (-2.0f) )< 0.0001) {
            start = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (start && collision.transform.name == "plate") {
            Destroy(collision.gameObject);
            numSoup++;
            soupText.text = "You Finished: " + numSoup.ToString() + " soups";
        }
    }
}
