using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moving : MonoBehaviour
{
    Vector3 up = Vector3.zero,
    right = new Vector3(0, 90, 0),
    down = new Vector3(0, 180, 0),
    left = new Vector3(0, 270, 0),
    currentDirection = Vector3.zero;
    Vector3 nextPos, destination, direction;
    float speed = 5f;
    float rayLength = 1f;
    bool canMove;

    public static int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentDirection = up;
        nextPos = Vector3.forward;
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (count != 0)
        {

            if (Input.GetKeyDown(KeyCode.W))
            {
                nextPos = Vector3.forward;
                currentDirection = up;
                canMove = true;

            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                nextPos = Vector3.back;
                currentDirection = down;
                canMove = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                nextPos = Vector3.right;
                currentDirection = right;
                canMove = true;

            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                nextPos = Vector3.left;
                currentDirection = left;
                canMove = true;

            }
            if (Vector3.Distance(destination, transform.position) <= 0.00001f)
            {
                transform.localEulerAngles = currentDirection;
                if (canMove)
                {
                    if (Valid())
                    {
                        destination = transform.position + nextPos;
                        direction = nextPos;
                        movingCnt.movingCnt_1++;
                        canMove = false;
                        count--;
                    }
                }
            }
            Invoke("move", 0.3f);
            Check(); // 움직이고 나서 체크하는 거로 바꿈
        }
    }

    bool Valid()
    {
        Ray myRay = new Ray(transform.position + new Vector3(0, 0.25f, 0), transform.forward);
        RaycastHit hit;
        Debug.DrawRay(myRay.origin, myRay.direction, Color.red);
        if (Physics.Raycast(myRay, out hit, rayLength))
        {
            if (count == 0)
            {
                if (hit.collider.tag == "enemy")
                {
                    Destroy(hit.transform.gameObject);
                    SceneManager.LoadScene("BattleScene");

                    return false;
                }
            }
            if (hit.collider.tag == "Wall")
            {
                return false;
            }
        }
        return true;

    }

    bool Check() 
    {
        Ray myRay = new Ray(transform.position + new Vector3(0, 0.25f, 0), transform.forward);
        RaycastHit hit;
        Debug.DrawRay(myRay.origin, myRay.direction, Color.red);
        if (Physics.Raycast(myRay, out hit, rayLength))
        {
            if (count == 0)
            {
                if (hit.collider.tag == "enemy")
                {
                    hit.transform.gameObject.SetActive(false);
                    //Destroy(hit.transform.gameObject);
                    SceneManager.LoadScene("BattleScene");

                    return false;
                }
            }
        }
        return true;
    }

    private void Awake()
    {
        var obj = FindObjectsOfType<Moving>();
        if (obj.Length == 1)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
    }
    /*public void OnTriggerEnter(Collider other)
    {
        if(count == 0)
        {
            if(other.tag == "enemy")
            {
                other.transform.gameObject.SetActive(false);
                SceneManager.LoadScene("BattleScene");
            }
        }
    }*/
    public void move()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }
}
