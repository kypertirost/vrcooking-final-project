using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class SoupControl : NetworkBehaviour {

    [SyncVar] public bool grabbed = false;

    Rigidbody myRb;


    // Use this for initialization
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    [Command]
    public void CmdPickupOrDrop()
    {
        if (grabbed)
        {  // now drop it
            transform.parent = null;  // release the object
            grabbed = false;
            myRb.useGravity = true;
            myRb.isKinematic = false;//    .useGravity = true;
        }
        else
        {   // pick it up:
            // make it move with gaze, keeping same distance from camera
            //Magnitude is the length of the vector
            transform.parent = Camera.main.transform;  // attach object to camera
            grabbed = true;
            myRb.useGravity = false; 
            myRb.isKinematic = true;

        }
    }
}
