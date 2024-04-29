using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cube : MonoBehaviour
{

    public static cube instance = null;
    public bool one = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (one == true)
            {
                this.tag = "Untagged";
                gameObject.GetComponent<BoxCollider>().enabled = false;
                gameObject.SetActive(false);
                Debug.Log(other.transform.position);
               
                //Destroy(this.gameObject);
                one = false;
               
                SceneManager.LoadScene("BattleScene");
                //other.transform.position = transform.position + new Vector3(0.5f, 0, 0);
            }
        }
    }*/
    private void Awake()
    {
        var obj = FindObjectsOfType<Moving>();
        if (obj.Length == 1)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
    }
}
