using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPad : MonoBehaviour {

    public int code;
    float disableTimer=0;
    public void Update()
    {
        if(disableTimer>0){
            disableTimer -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="banana" && disableTimer<=0){
            
            foreach(TeleportPad tp in FindObjectsOfType<TeleportPad>()){
                
                if(tp.code==code && tp!=this){
                    tp.disableTimer = 2;
                    Vector3 position = tp.gameObject.transform.position;
                    position.y += 2;
                    other.gameObject.transform.position = position;
                }
            }
        }
    }
}
