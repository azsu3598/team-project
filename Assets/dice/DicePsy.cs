using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePsy : MonoBehaviour
{
    // Start is called before the first frame update
    static Rigidbody rb;
    public static Vector3 diceVelocity;
    public int a;
    public Camera cmr1;
    public Camera cmr2;
    //public Canvas cnv;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        a = 1;
    }

    // Update is called once per frame
    void Update()
    {
        diceVelocity = rb.velocity;
        if (cmr2.enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                float dirX = Random.Range(0, 500);
                float dirY = Random.Range(0, 500);
                float dirZ = Random.Range(0, 500);
                transform.position = new Vector3(100, 103, 100);
                transform.rotation = Quaternion.identity;
                rb.AddForce(transform.up * 500);
                rb.AddTorque(dirX, dirY, dirZ);

                Invoke("scene", 4);
            }
        }
        }
    public void scene()
    {
        Moving.count = GameObject.Find("GameObject").GetComponent<DiceStat>().side;
        cmr1.enabled = true;
        cmr2.enabled = false;  
    }

    public void roll()
    {
        float dirX = Random.Range(0, 500);
        float dirY = Random.Range(0, 500);
        float dirZ = Random.Range(0, 500);
        transform.position = new Vector3(0, 92, 0);
        transform.rotation = Quaternion.identity;
        rb.AddForce(transform.up * 500);
        rb.AddTorque(dirX, dirY, dirZ);

        Invoke("scene", 4);
    }
}
