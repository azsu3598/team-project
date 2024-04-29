using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DiceTextNumberSc : MonoBehaviour
{
    // Start is called before the first frame update
    Text text;
    public static int diceNumber;
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = diceNumber.ToString();
    }
}
