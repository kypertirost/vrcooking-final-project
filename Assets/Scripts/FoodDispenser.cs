using UnityEngine;
using UnityEngine.Networking;

public class FoodDispenser : NetworkBehaviour
{
    public GameObject food1;
    public GameObject food2;
    GameObject destroy;

    void OnCollisionEnter(Collision col)
    {

        // Add the GameObject collided with to the list.
        destroy = col.gameObject;
    }
    [Command]
    public void CmdDispense()
    {
        if (destroy == null)
        {
            int random = Random.Range(1, 3);
            if (random == 1)
            {
                NetworkServer.Spawn((GameObject)Instantiate(food1, transform.position + new Vector3(0, 0.5f, 0), transform.rotation));
            }
            else if (random == 2)
            {
                NetworkServer.Spawn((GameObject)Instantiate(food2, transform.position + new Vector3(0, 0.5f, 0), transform.rotation));
            }

        }
        else
        {
            Destroy(destroy.gameObject);
            int random = Random.Range(1, 4);
            if (random == 1)
            {
                NetworkServer.Spawn((GameObject)Instantiate(food1, transform.position + new Vector3(0, 0.5f, 0), transform.rotation));
            }
            else if (random == 2)
            {
                NetworkServer.Spawn((GameObject)Instantiate(food2, transform.position + new Vector3(0, 0.5f, 0), transform.rotation));
            }
        }

    }
}
