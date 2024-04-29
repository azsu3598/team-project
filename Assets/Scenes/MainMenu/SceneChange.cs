using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    /*void Update()
    {
        if(Input.GetMouseButtonDown(0))
            SceneManager.LoadScene("Map");
    }*/

    public void onClick()
    {
        SceneManager.LoadScene("Map");
    }
}
