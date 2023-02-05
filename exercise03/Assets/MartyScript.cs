using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MartyScript : MonoBehaviour
{
    float moveSpeed = 5f;
    float rotateSpeed = 75f;
    float beetEat = 0f;
    float launchForce = 2000f;
    float pineEat = 0f;
    public CapsuleCollider cc;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        gameObject.transform.Translate(gameObject.transform.forward * Time.deltaTime * moveSpeed * vAxis, Space.World);
        gameObject.transform.Rotate(0, rotateSpeed * Time.deltaTime * hAxis, 0);
        if (beetEat == 7f)
        {
            rb.useGravity = false;
            rb.AddForce(gameObject.transform.up * launchForce);

        }
        if (pineEat == 4f)
        {
            cc.isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("beet"))
        {
            Destroy(other.gameObject);
            moveSpeed = moveSpeed + 2f;
            beetEat = beetEat + 1f;
        }

        if (other.CompareTag("pine"))
        {
            Destroy(other.gameObject);
            moveSpeed = moveSpeed - 2f;
            pineEat = pineEat + 1f;
        }
    }

}
