using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformtoCamera : MonoBehaviour {
    Vector3 pos;
	// Use this for initialization
	void Start () {
        pos = Camera.main.transform.localPosition;
       
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = pos;
	}
}
