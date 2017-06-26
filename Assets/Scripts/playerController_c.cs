using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController_c : MonoBehaviour {

    private Rigidbody rb;
    public float speed = 0.1f;
    public int overlappedID = -1;
    public float time;

    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        rb.transform.position += new Vector3(moveH, 0, moveV) * speed;

        if (Input.GetKeyDown(KeyCode.I))
            Debug.Log("overlapped ID: " + overlappedID);

        //    rb.AddForce(movement);


    }
}
