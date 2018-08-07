using UnityEngine;
using UnityEngine.Networking;

public class Player_Controller : NetworkBehaviour
{


    public GameObject cameraContainer;
    public Vector3 direction;



    public override void OnStartLocalPlayer()
    {
        cameraContainer = Camera.main.transform.parent.gameObject;
     
    }
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        cameraContainer.transform.position = transform.GetChild(0).transform.position;

    }

}

