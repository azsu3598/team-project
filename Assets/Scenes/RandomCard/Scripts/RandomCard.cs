using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCard : MonoBehaviour
{
    public WeightedRandomList<Transform> lootTable;
    public Transform Carditem_1;
    public Transform Carditem_2;
    public Transform Carditem_3;
    private int r1;
    private int r2;
    private int r3;
    void Start()
    {
        r1 = Random.Range(-1,1);
        r2 = Random.Range(-1,1);
        r3 = Random.Range(-1,1);
        ShowItem();
        Carditem_1.gameObject.transform.Rotate(new Vector3(0,0,r1));
        Carditem_2.gameObject.transform.Rotate(new Vector3(0,0,r2));
        Carditem_3.gameObject.transform.Rotate(new Vector3(0,0,r3));
    }

    void ShowItem()
    {

        Transform item = lootTable.GetRandom();
        Transform item_2 = lootTable.GetRandom();
        Transform item_3 = lootTable.GetRandom();
        Instantiate(item, Carditem_1);
        Instantiate(item_2, Carditem_2);
        Instantiate(item_3, Carditem_3);
        Carditem_1.gameObject.SetActive(true);
        Carditem_2.gameObject.SetActive(true);
        Carditem_3.gameObject.SetActive(true);
        //lootTable.list[0].weight;
    }
}