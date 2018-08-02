using UnityEngine;
using UnityEngine.Networking;

    public class Player_Controller : NetworkBehaviour
    {

         Transform cameraTransform;
        Transform cameraContainerTransform;
        public Transform visorTransform;
        public Vector3 direction;



        public override void OnStartLocalPlayer()
        {
            GetComponent<Renderer>().material.color = Color.blue;
            cameraTransform = Camera.main.transform;
            cameraContainerTransform = cameraTransform.parent;
            
            visorTransform = transform.Find("Visor");
            cameraContainerTransform.position = visorTransform.position;
            Debug.Log("start local player: visor position = " + visorTransform.position + " camera posn = " + cameraContainerTransform.position);
        }

        void Update()
        {
            if (!isLocalPlayer)
            {
                return;
            }

            // rotate the player to match the camera's rotation (controlled by GoogleVR)
            Vector3 yrot = cameraTransform.rotation.eulerAngles;
            // only rotate around y axis
            yrot.x = 0;
            yrot.z = 0;
            transform.eulerAngles = yrot;
            //        transform.rotation = cameraTransform.rotation;

            // move the camera to match the player's position
            cameraContainerTransform.position = visorTransform.position;

        }

    }

