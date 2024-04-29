using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanCard : MonoBehaviour
{
    private int r1;
    void Start()
    {
        r1 = Random.Range(-15,15);
        transform.Rotate(new Vector3(0,0,r1));
    }
}