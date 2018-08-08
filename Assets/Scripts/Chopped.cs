using UnityEngine;
using UnityEngine.Networking;

public class Chopped : NetworkBehaviour
{
    public GameObject choppedEggplant;
    public GameObject choppedCarrot;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "eggplant")
        {
            NetworkServer.UnSpawn(other.gameObject);
            NetworkServer.Spawn((GameObject)Instantiate(choppedEggplant, transform.position + new Vector3(0, 0.5f, 0), transform.rotation));

        }
        else if (other.gameObject.name == "carrot")
        {
            NetworkServer.UnSpawn(other.gameObject);
            NetworkServer.Spawn((GameObject)Instantiate(choppedCarrot, transform.position + new Vector3(0, 0.5f, 0), transform.rotation));

        }
    }
}
