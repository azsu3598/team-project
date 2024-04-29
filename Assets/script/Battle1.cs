using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum bs //enum 
{
    START,
    PLAYERTURN,
    ENEMYTURN,
    WON,
    LOST
};

public class Battle1 : MonoBehaviour
{
    public Camera cmr;
    //public GameObject playerPrefab;  // ����ǰ ���� -- ���� ���� �� ���� ����. �����ؼ� ������ �ؾ� �ҵ�
    public GameObject enemyPrefab;
    public Canvas hpbar;
    //DicePsy ddd = GameObject.Find("GameObject").GetComponent<DicePsy>();

    public Unit playerUnit;
    Unit enemyUnit; //Unit Ŭ����
    public static int count_side = 0;

    public hpstate playerhp;
    public hpstate enemyhp;

    public bs state;

    void Start()
    {
        state = bs.START;
        StartCoroutine(SetupBattle());

    }

    IEnumerator SetupBattle()
    {
        //GameObject playerGo = Instantiate(playerPrefab);  //����ǰ�� �޾ƿ� ��ġ�� ����
        //playerUnit = playerGo.GetComponent<Unit>();
        GameObject enemyGo = Instantiate(enemyPrefab);
        enemyUnit = enemyGo.GetComponent<Unit>();

        playerhp.SetupHP(playerUnit);
        enemyhp.SetupHP(enemyUnit);

        yield return new WaitForSeconds(2f);  // 2���Ŀ� ����


        state = bs.PLAYERTURN;
        PlayerTurn();

    }

    void PlayerTurn()
    {
        Debug.Log("�÷��̾� ��");
        Debug.Log("���� ���ݷ� : ");
        Debug.Log(playerUnit.damage + count_side);
    }
    public void onAttackButton()    // ���� ��ư ������ ��
    {
        if (state != bs.PLAYERTURN) // �÷��̾� �� �ƴϸ� �۵� x
            return;
        if (count_side == 0)
        {
            hpbar.enabled = false;
            cmr.transform.position = new Vector3(4, 94, -10);
            cmr.transform.rotation = Quaternion.Euler(0, 0, 0);
        }


        StartCoroutine(PlayerAttack());

    }
    public void onHealButton() // �� ��ư ������ �� 
    {
        //SceneManager.LoadScene("Map");
        if (state != bs.PLAYERTURN) // �÷��̾� �� �ƴϸ� �۵� x 
            return;
        StartCoroutine(PlayerHeal());
    }

    IEnumerator PlayerHeal()
    {

        playerUnit.Heal(5 + count_side); //ü�� 5ȸ��
        playerhp.SetupHP(playerUnit);  // �����̴��� �ݿ�
        Debug.Log("ü�� ȸ��");
        state = bs.ENEMYTURN;  // ���� ������ ����
        yield return new WaitForSeconds(1f);    //1�� ��ٸ�
        StartCoroutine(EnemyTurn());    // ���� ��
    }



    IEnumerator PlayerAttack()
    {

            if (count_side != 0)
            {
                state = bs.ENEMYTURN;  // ���� ������ ����
                bool isDead = enemyUnit.TakeDamage(playerUnit.damage + count_side);  //  ���͸� �����Ͽ� ������ true�� ����, �������� false�� ����
                Debug.Log(playerUnit.damage + count_side + "��ŭ�� ���ظ� �־���.");
                enemyhp.SetupHP(enemyUnit);    // �����̴� �ݿ�
                                               // Damage the enemy
            count_side = 0;
                yield return new WaitForSeconds(2f);    //2�� ���
                                                        // check if the enemy is dead
                if (isDead) // ������ ����
                {
                    state = bs.WON;
                    EndBattle(); // ��Ʋ ��
                }
                else
                {
                    StartCoroutine(EnemyTurn()); // ���� �� ����
                }

            }

        // Change state based on what happened
    }
    IEnumerator EnemyTurn()
    {
        count_side = 0;


        yield return new WaitForSeconds(1f);    //1�� ���

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);  //���� ����

        playerhp.SetupHP(playerUnit); // ü�� �ݿ�

        enemyUnit.damage += 1; // �ʿ� ���°�

        yield return new WaitForSeconds(1f);    // 1�� ���

        if (isDead) // ������
        {
            state = bs.LOST;
            EndBattle();    // ��
        }
        else
        {
            state = bs.PLAYERTURN; // �÷��̾� ��
            PlayerTurn();   // �÷��̾� ��
        }
    }

    void EndBattle()
    {
        if (state == bs.WON)    // state �� ��
        {
            Debug.Log("���� �� �̰��.");
            SceneManager.LoadScene("Map");
        }
        else if (state == bs.LOST)
        {
            Debug.Log("������ ���ߴ�.");
        }
    }
}
