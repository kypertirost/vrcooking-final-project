using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sj1948FinalProject{
    /***
     * PickupMe component allows user to select this object and 
     * move it with their gaze
     ******/
    public class Pickup_Drop : MonoBehaviour
    {
        public bool grabbed = false;  // have i been picked up, or not?
        Rigidbody myRb;
        float Magnitude;

        // Use this for initialization
        void Start()
        {
            myRb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (grabbed)
            {
                //if the object is clicked on, it will remain in the center of the frame of the camera aka the player's perspective
                //relativePos is the position the object should be in in relationship to the camera
                var relativePos = Magnitude * Camera.main.transform.forward + Camera.main.transform.position - transform.position+new Vector3(0,0,0);
                myRb.velocity = relativePos * 100;

            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.name=="cooker"){
                Destroy(transform.gameObject);
                GameObject soup = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                soup.transform.localScale = new Vector3(0.7f, 0.07f, 0.7f);
                soup.transform.parent = collision.transform;
                soup.name = "soup";
                soup.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
                soup.transform.localPosition = Vector3.zero;
            }
        }
        /*
         * PickupOrDrop
         * Handle the event when the user clicks the button while 
         * gaze is on this object.  Toggle grabbed state.
         */
        public void PickupOrDrop()
        {
            if (grabbed)
            {  // now drop it
                //transform.parent = null;  // release the object
                grabbed = false;
                myRb.useGravity = true; // isKinematic = false;  //    .useGravity = true;
            }
            else
            {   // pick it up:
                // make it move with gaze, keeping same distance from camera
                //Magnitude is the length of the vector
                Magnitude = Vector3.Project(transform.position - Camera.main.transform.position, Camera.main.transform.forward).magnitude;
                grabbed = true;
                myRb.useGravity = false; //.isKinematic = true; //  .useGravity = false;

            }
        }
    }
}
