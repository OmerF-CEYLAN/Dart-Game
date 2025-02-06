using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{

    Rigidbody rb;

    bool isAllowed = false;

    [SerializeField]
    Vector3 localGravity;

    [SerializeField]
    float speed;

    [SerializeField]
    float rotateSpeed;

    Vector3 temp;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        temp = localGravity;

        localGravity = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity += localGravity;
        gameObject.transform.Rotate(new Vector3(-rb.velocity.y * rotateSpeed, 0, 0));
    }


    private void OnMouseUpAsButton()
    {
        localGravity = temp;
        rb.velocity = new Vector3(0, 0, speed);
        isAllowed = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        localGravity = Vector3.zero;
        isAllowed = false;
        rb.velocity = Vector3.zero;
    }


}
