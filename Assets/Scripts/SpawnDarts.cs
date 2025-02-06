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
        if (dartCount < 1)
        {
            dartCount++;

            GameObject newDart = Instantiate(dartPrefab,gameObject.transform.position,Quaternion.Euler(90,0,0));

        }
    }
}
