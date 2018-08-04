using UnityEngine;
using UnityEngine.Networking;

public class Player_Controller : NetworkBehaviour
{

    private Transform cameraTransform;
    private Transform cameraContainerTransform;
    public Vector3 direction;



    public override void OnStartLocalPlayer()
    {

        GameObject empty = new GameObject();
        empty.name = "Camera";
        cameraTransform = Camera.main.transform;
        //GetComponent<Renderer>().material.color = Color.blue;
        cameraContainerTransform = empty.transform;
        cameraTransform.parent = cameraContainerTransform;

        //visorTransform = transform.Find("Visor");
        //cameraContainerTransform.position = visorTransform.position;
        //Debug.Log("start local player: visor position = " + visorTransform.position + " camera posn = " + cameraContainerTransform.position);
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        transform.rotation = cameraTransform.rotation;
        cameraContainerTransform.position = transform.position;
        Vector3 heightRevised = cameraContainerTransform.position;
        heightRevised.y = -29.07f;
        cameraContainerTransform.position = heightRevised;
    }

}

