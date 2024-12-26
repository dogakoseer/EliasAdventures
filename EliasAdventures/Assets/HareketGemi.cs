using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class HareketGemi : MonoBehaviour
{
    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.A))
            rb.AddForce(Vector3.left);
       
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector3.right);

        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.up);

        if (Input.GetKey(KeyCode.S))
            rb.AddForce(Vector3.down);
       
    }
}
