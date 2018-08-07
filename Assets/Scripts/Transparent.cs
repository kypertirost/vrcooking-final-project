using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Transparent : NetworkBehaviour {

    public GameObject Popup;
    [SyncVar]
    public float alphaLevel = 1f;
    private bool continuing=true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}
    public void Maketransparent(){
        
        if (continuing==true)
        {
            alphaLevel -=0.1f;
    
           
            GetComponent<Renderer>().material.color = new Color(GetComponent<Renderer>().material.color.r, GetComponent<Renderer>().material.color.g, GetComponent<Renderer>().material.color.b, alphaLevel);
            if (alphaLevel <= 0)
            {
                continuing = false;
                Destroy(transform.gameObject);
                Instantiate(Popup, transform.position, Quaternion.identity);
            }
        } 




    }
}
