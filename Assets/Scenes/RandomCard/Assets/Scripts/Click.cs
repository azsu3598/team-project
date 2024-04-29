using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    RandomCard rand;
    string name_;
    float a = 0;
    public Text text;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                rand = GameObject.Find("RandomCard").GetComponent<RandomCard>();
                name_ = hit.transform.gameObject.name.Substring(0, 5);
                Debug.Log(name_);
                for(int i = 0; i < 4; i++)
                {
                    if(string.Compare(name_, rand.lootTable.list[i].item.ToString().Substring(0, 5)) == 0)
                    {
                        Debug.Log("weight : ");
                        Debug.Log(rand.lootTable.list[i].weight);
                        a = rand.lootTable.list[i].weight;
                        text.text = a.ToString();
                    }
                }
            }
        }
    }
}
