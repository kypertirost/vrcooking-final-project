using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class growing : MonoBehaviour {

    Vector3 temp;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name=="cube"){
            Destroy(collision.gameObject);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        temp = transform.localScale;
        temp.y += Time.deltaTime;
        transform.localScale = temp;
	}
}
