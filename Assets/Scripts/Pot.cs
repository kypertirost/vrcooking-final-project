using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour {

    public GameObject soupPrefab;
    public void MakeANewDish(Transform soupTransform)
    {
        Instantiate(soupPrefab, new Vector3(7.289f, -31.08683f, 58.001f), Quaternion.identity);
    }
}
