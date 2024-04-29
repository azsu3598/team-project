using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cmr : MonoBehaviour
{
    Vector3 abc;
    // Start is called before the first frame update
    void Start()
    {
        abc = new Vector3(0, 3, -1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GameObject.Find("pon_2").transform.position + abc;
    }
}
