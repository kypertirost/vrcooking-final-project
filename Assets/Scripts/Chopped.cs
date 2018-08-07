using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Chopped : NetworkBehaviour {
    public GameObject choppedEggplant;
    public GameObject choppedBanana;
    public GameObject choppedTomatoe;
    public GameObject choppedCarrot;
    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.name == "eggplant")
        {
            Instantiate(choppedEggplant,transform.position + new Vector3(0, 0.5f, 0), transform.rotation);

        }else if (other.gameObject.name == "banana")
        {
            Instantiate(choppedEggplant,transform.position + new Vector3(0, 0.5f, 0), transform.rotation);

        }
        else if (other.gameObject.name == "tomatoe")
        {
            Instantiate(choppedEggplant,transform.position + new Vector3(0, 0.5f, 0), transform.rotation);

        }
        else if (other.gameObject.name == "eggplant")
        {
            Instantiate(choppedEggplant,transform.position + new Vector3(0, 0.5f, 0), transform.rotation);

        }
    }
}
