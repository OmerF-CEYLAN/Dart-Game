using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    Vector3 lastMousePosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        temp = localGravity;

        localGravity = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            float delta = Input.mousePosition.y - lastMousePosition.y;

            transform.Rotate(delta * Time.deltaTime * 1,0,0 );

        }

        lastMousePosition = Input.mousePosition;

        rb.velocity += localGravity;
        transform.Rotate(new Vector3(Mathf.Abs(rb.velocity.y) * rotateSpeed, 0, 0));
    }


    private void OnMouseUpAsButton()
    {
        localGravity = temp;
        rb.velocity = transform.up * speed;
        isAllowed = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        localGravity = Vector3.zero;
        isAllowed = false;
        rb.velocity = Vector3.zero;

        Invoke("DestroyIt",1f);
    }

    void DestroyIt()
    {
        Destroy(gameObject);
    }

}
