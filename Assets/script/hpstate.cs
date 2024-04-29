using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpstate : MonoBehaviour
{
    public Text hp_state;
    // Start is called before the first frame update
    public void SetupHP(Unit unit)
    {
        hp_state.text = unit.currentHP.ToString();
    }
}
