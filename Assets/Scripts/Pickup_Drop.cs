using UnityEngine;
using UnityEngine.Networking;
namespace sj1948FinalProject{
    /***
     * PickupMe component allows user to select this object and 
     * move it with their gaze
     ******/
    public class Pickup_Drop : NetworkBehaviour
    {
        [SyncVar]
        public bool grabbed = false;  // have i been picked up, or not?
        Rigidbody myRb;
        private Transform soup;


        // Use this for initialization
        void Start()
        {
            myRb = GetComponent<Rigidbody>();
        }


        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.name == "cooker" && transform.gameObject.name != "plate"){
                Destroy(transform.gameObject);
                soup = collision.transform.Find("soup");
                if (soup){
                    Vector3 soupScale = soup.localScale;
                    soupScale.y += 0.05f;
                    soup.localScale = soupScale;
                    Debug.Log("soup now rise!");
                    if (soup.localScale.y >= 0.15f)
                    {
                        Pot pot = collision.gameObject.GetComponent<Pot>();
                        pot.MakeANewDish(soup);
                        Destroy(soup.gameObject);
                    }
                } else {
                    soup = GameObject.CreatePrimitive(PrimitiveType.Cylinder).transform;
                    soup.parent = collision.transform;
                    soup.localScale = new Vector3(0.9f, 0.05f, 0.9f);
                    soup.name = "soup";
                    soup.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
                    soup.localPosition = Vector3.zero;
                    Debug.Log(soup);
                }

            }
        }



        /*
        * PickupOrDrop
        * Handle the event when the user clicks the button while 
        * gaze is on this object.  Toggle grabbed state.
        */
        [Command]
        public void CmdPickupOrDrop()
        {
            if (grabbed)
            {  // now drop it
                transform.parent = null;  // release the object
                grabbed = false;
                myRb.useGravity = true;   //    .useGravity = true;
                myRb.isKinematic = false;
            }
            else
            {   // pick it up:
                // make it move with gaze, keeping same distance from camera
                //Magnitude is the length of the vector
                transform.parent = Camera.main.transform;  // attach object to camera
                grabbed = true;
                myRb.useGravity = false; //.isKinematic = true; //  .useGravity = false;
                myRb.isKinematic = true;

            }
        }

    }
}
