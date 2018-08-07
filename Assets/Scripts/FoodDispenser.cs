using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FoodDispenser : NetworkBehaviour {
    public GameObject food1;
    public GameObject food2;
    public GameObject food3;
    public GameObject food4;
    GameObject destroy;

    void OnCollisionEnter(Collision col)
    {
        
        // Add the GameObject collided with to the list.
        destroy = col.gameObject;
    }
    public void Dispense(){
        if (destroy == null)
        {
            int random = Random.Range(1, 5);
            if (random == 1)
            {
                Instantiate(food1, transform.position + new Vector3(0, 1, 0), transform.rotation);
            }
            else if (random == 2)
            {
                Instantiate(food2, transform.position + new Vector3(0, 1, 0), transform.rotation);
            }
            else if (random == 3)
            {
                Instantiate(food3, transform.position + new Vector3(0, 1, 0), transform.rotation);
            }
            else
            {
                Instantiate(food4, transform.position + new Vector3(0, 1, 0), transform.rotation);
            }

        }
        else
        {
            Destroy(destroy.gameObject);
            int random = Random.Range(1, 4);
            if (random == 1)
            {
                Instantiate(food1, transform.position + new Vector3(0, 1, 0), transform.rotation);
            }
            else if (random == 2)
            {
                Instantiate(food2, transform.position + new Vector3(0, 1, 0), transform.rotation);
            }
            else if (random == 3)
            {
                Instantiate(food3, transform.position + new Vector3(0, 1, 0), transform.rotation);
            }
            else
            {
                Instantiate(food4, transform.position + new Vector3(0, 1, 0), transform.rotation);
            }
        }

    }
}
