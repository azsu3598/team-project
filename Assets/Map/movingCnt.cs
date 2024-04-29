using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class movingCnt : MonoBehaviour
{
    Text myText;
    public static int movingCnt_1 = 0;
    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();
    }

    void Update()
    {
        myText.text = movingCnt_1.ToString();
    }
}
