using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Pot : NetworkBehaviour {

    public GameObject soupPrefab;
    public void MakeANewDish(Transform soupTransform)
    {
        Instantiate(soupPrefab, new Vector3(7.289f, -31.08683f, 58.001f), Quaternion.identity);
    }
}
