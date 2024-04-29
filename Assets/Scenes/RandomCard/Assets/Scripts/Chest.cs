using UnityEngine;

public class Chest : MonoBehaviour
{
    public WeightedRandomList<Transform> lootTable;

    public Transform itemHolder;
    public Transform itemHolder_2;
    public Transform itemHolder_3;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("close");
        HideItem();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (IsOpen())
            {
                animator.SetTrigger("close");
                HideItem();
            }
            else
            {
                animator.SetTrigger("open");
            }
        }
    }

    bool IsOpen()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("ChestOpen");
    }

    void HideItem()
    {
        itemHolder.localScale = Vector3.zero;
        itemHolder_2.localScale = Vector3.zero;
        itemHolder_3.localScale = Vector3.zero;
        itemHolder.gameObject.SetActive(false);
        itemHolder_2.gameObject.SetActive(false);
        itemHolder_3.gameObject.SetActive(false);

        foreach (Transform child in itemHolder)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in itemHolder_2)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in itemHolder_3)
        {
            Destroy(child.gameObject);
        }
    }

    void ShowItem()
    {
        Transform item = lootTable.GetRandom();
        Transform item_2 = lootTable.GetRandom();
        Transform item_3 = lootTable.GetRandom();
        Instantiate(item, itemHolder);
        Instantiate(item_2, itemHolder_2);
        Instantiate(item_3, itemHolder_3);
        itemHolder.gameObject.SetActive(true);
        itemHolder_2.gameObject.SetActive(true);
        itemHolder_3.gameObject.SetActive(true);
    }
}
