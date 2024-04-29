using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState //enum 
{
    START,
    PLAYERTURN,
    ENEMYTURN,
    WON,
    LOST
};

public class Battle : MonoBehaviour
{
    public Camera cmr;
    public GameObject playerPrefab;  // ����ǰ ���� -- ���� ���� �� ���� ����. �����ؼ� ������ �ؾ� �ҵ�
    public GameObject enemyPrefab;
    public Canvas hpbar;
    //DicePsy ddd = GameObject.Find("GameObject").GetComponent<DicePsy>();

    Unit playerUnit;
    Unit enemyUnit; //Unit Ŭ����
    public static int count_side = 0;

    public hpstate playerhp;
    public hpstate enemyhp;

    public BattleState state;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());

    }

    IEnumerator SetupBattle()
    {
        GameObject playerGo = Instantiate(playerPrefab);  //����ǰ�� �޾ƿ� ��ġ�� ����
        playerUnit = playerGo.GetComponent<Unit>();
        GameObject enemyGo = Instantiate(enemyPrefab);
        enemyUnit = enemyGo.GetComponent<Unit>();
        
        playerhp.SetupHP(playerUnit);
        enemyhp.SetupHP(enemyUnit);

        yield return new WaitForSeconds(2f);  // 2���Ŀ� ����


        state = BattleState.PLAYERTURN;
        PlayerTurn();

    }

    void PlayerTurn()
    {
       // Debug.Log("�÷��̾� ��");
       // Debug.Log("���� ���ݷ� : ");
      //  Debug.Log(playerUnit.damage + count_side);
    }
    public void onAttackButton()    // ���� ��ư ������ ��
    {
        if (state != BattleState.PLAYERTURN) // �÷��̾� �� �ƴϸ� �۵� x
            return;
        StartCoroutine(PlayerAttack());

    }
    public void onHealButton() // �� ��ư ������ �� 
    {
        //SceneManager.LoadScene("Map");
        if (state != BattleState.PLAYERTURN) // �÷��̾� �� �ƴϸ� �۵� x 
            return;
        StartCoroutine(PlayerHeal());
    }

    IEnumerator PlayerHeal()
    {

        playerUnit.Heal(5 + count_side); //ü�� 5ȸ��
        playerhp.SetupHP(playerUnit);  // �����̴��� �ݿ�
        Debug.Log("ü�� ȸ��");
        state = BattleState.ENEMYTURN;  // ���� ������ ����
        yield return new WaitForSeconds(1f);    //1�� ��ٸ�
        StartCoroutine(EnemyTurn());    // ���� ��
    }



    IEnumerator PlayerAttack()
    {

            /*if (count_side != 0)
            {*/
                state = BattleState.ENEMYTURN;  // ���� ������ ����
                bool isDead = enemyUnit.TakeDamage(playerUnit.damage + count_side);  //  ���͸� �����Ͽ� ������ true�� ����, �������� false�� ����
                Debug.Log(playerUnit.damage + count_side + "��ŭ�� ���ظ� �־���.");
                enemyhp.SetupHP(enemyUnit);    // �����̴� �ݿ�
                                               // Damage the enemy
            count_side = 0;
                yield return new WaitForSeconds(2f);    //2�� ���
                                                        // check if the enemy is dead
                if (isDead) // ������ ����
                {
                    state = BattleState.WON;
                    EndBattle(); // ��Ʋ ��
                }
                else
                {
                    StartCoroutine(EnemyTurn()); // ���� �� ����
                }

            //}

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
            state = BattleState.LOST;
            EndBattle();    // ��
        }
        else
        {
            state = BattleState.PLAYERTURN; // �÷��̾� ��
            PlayerTurn();   // �÷��̾� ��
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)    // state �� ��
        {
            Debug.Log("���� �� �̰��.");
            SceneManager.LoadScene("Map");
        }
        else if (state == BattleState.LOST)
        {
            Debug.Log("������ ���ߴ�.");
        }
    }

    
}
