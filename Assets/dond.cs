using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dond : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        var obj = FindObjectsOfType<Moving>();
        if (obj.Length == 1)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
    }
}
