using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDarts : MonoBehaviour
{
    [SerializeField]
    GameObject dartPrefab;

    [SerializeField]
    int dartCount = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag(dartPrefab.tag) == null)
        {

            GameObject newDart = Instantiate(dartPrefab,gameObject.transform.position,Quaternion.Euler(90,0,0));

        }
    }
}
