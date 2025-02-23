using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dart : MonoBehaviour
{
    Quaternion targetRotation;

    DartBoard board;

    Rigidbody rb;

    [SerializeField]
    Vector3 localGravity;

    [SerializeField]
    float speed;

    [SerializeField]
    float rotateSpeed;

    [SerializeField]
    float scrollSpeed;

    [SerializeField]
    float moveSpeed;

    Vector3 temp;

    bool isEnabledToMove = true;

    Vector3 lastMousePosition;

    bool hit = false;

    void Start()
    {
        targetRotation = transform.rotation;

        rb = GetComponent<Rigidbody>();

        temp = localGravity;

        localGravity = Vector3.zero;

        board = GameObject.FindWithTag("Board").GetComponent<DartBoard>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isEnabledToMove)
        {
            MoveDart();
            TurnDart();
            ThrowDart();
        }


        rb.velocity += localGravity;
        transform.Rotate(new Vector3(Mathf.Abs(rb.velocity.y) * rotateSpeed, 0, 0));
    }


    private void ThrowDart()
    {

        if (Input.GetMouseButtonUp(0))
        {
            localGravity = temp;
            rb.velocity = transform.up * speed;

            isEnabledToMove = false;

            Invoke("DestroyIt", 2.5f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hit)
        {
            Debug.Log(other.gameObject.name);
            localGravity = Vector3.zero;
            hit = true;
            rb.velocity = Vector3.zero;

            NotifyDartBoard(other.transform.parent.gameObject);

            gameObject.transform.parent = board.transform;
        }

    }

    void DestroyIt()
    {
        Destroy(gameObject);
    }

    void NotifyDartBoard(GameObject obj)
    {
        board.UpdateTotalPoints(obj);
    }
    
    void MoveDart()
    {
        float deltaX = 0,deltaY = 0;

        if (Input.GetMouseButton(0))
        {
            deltaX = Input.mousePosition.x- lastMousePosition.x;
            deltaY = Input.mousePosition.y - lastMousePosition.y;
        }

        transform.position += new Vector3(deltaX, deltaY, 0) * moveSpeed;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.5f, 1.5f),Mathf.Clamp(transform.position.y, 2.7f, 3.5f),transform.position.z);


        lastMousePosition = Input.mousePosition;
    }

    void TurnDart()
    {
        float rotationSpeed = 5f;
        float delta = Input.GetAxis("Mouse ScrollWheel");

        if (Mathf.Abs(delta) > 0.01f)
        {
            targetRotation *= Quaternion.Euler(delta * scrollSpeed, 0, 0);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

}
