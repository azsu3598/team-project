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
    public GameObject playerPrefab;  // 복제품 개념 -- 아직 개념 잘 이해 못함. 공부해서 다음에 해야 할듯
    public GameObject enemyPrefab;
    public Canvas hpbar;
    //DicePsy ddd = GameObject.Find("GameObject").GetComponent<DicePsy>();

    Unit playerUnit;
    Unit enemyUnit; //Unit 클래스
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
        GameObject playerGo = Instantiate(playerPrefab);  //복제품을 받아온 위치에 복제
        playerUnit = playerGo.GetComponent<Unit>();
        GameObject enemyGo = Instantiate(enemyPrefab);
        enemyUnit = enemyGo.GetComponent<Unit>();
        
        playerhp.SetupHP(playerUnit);
        enemyhp.SetupHP(enemyUnit);

        yield return new WaitForSeconds(2f);  // 2초후에 시작


        state = BattleState.PLAYERTURN;
        PlayerTurn();

    }

    void PlayerTurn()
    {
       // Debug.Log("플레이어 턴");
       // Debug.Log("현재 공격력 : ");
      //  Debug.Log(playerUnit.damage + count_side);
    }
    public void onAttackButton()    // 어택 버튼 눌렀을 때
    {
        if (state != BattleState.PLAYERTURN) // 플레이어 턴 아니면 작동 x
            return;
        StartCoroutine(PlayerAttack());

    }
    public void onHealButton() // 힐 버튼 눌렀을 때 
    {
        //SceneManager.LoadScene("Map");
        if (state != BattleState.PLAYERTURN) // 플레이어 턴 아니면 작동 x 
            return;
        StartCoroutine(PlayerHeal());
    }

    IEnumerator PlayerHeal()
    {

        playerUnit.Heal(5 + count_side); //체력 5회복
        playerhp.SetupHP(playerUnit);  // 슬라이더에 반영
        Debug.Log("체력 회복");
        state = BattleState.ENEMYTURN;  // 몬스터 턴임을 저장
        yield return new WaitForSeconds(1f);    //1초 기다림
        StartCoroutine(EnemyTurn());    // 몬스터 턴
    }



    IEnumerator PlayerAttack()
    {

            /*if (count_side != 0)
            {*/
                state = BattleState.ENEMYTURN;  // 몬스터 턴임을 저장
                bool isDead = enemyUnit.TakeDamage(playerUnit.damage + count_side);  //  몬스터를 공격하여 죽으면 true값 저장, 안죽으면 false값 저장
                Debug.Log(playerUnit.damage + count_side + "만큼의 피해를 주었다.");
                enemyhp.SetupHP(enemyUnit);    // 슬라이더 반영
                                               // Damage the enemy
            count_side = 0;
                yield return new WaitForSeconds(2f);    //2초 기달
                                                        // check if the enemy is dead
                if (isDead) // 죽으면 실행
                {
                    state = BattleState.WON;
                    EndBattle(); // 배틀 끝
                }
                else
                {
                    StartCoroutine(EnemyTurn()); // 몬스터 턴 시작
                }

            //}

        // Change state based on what happened
    }
    IEnumerator EnemyTurn()
    {
        count_side = 0;


        yield return new WaitForSeconds(1f);    //1초 기달

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);  //위와 동일

        playerhp.SetupHP(playerUnit); // 체력 반영

        enemyUnit.damage += 1; // 필요 없는거

        yield return new WaitForSeconds(1f);    // 1초 기달

        if (isDead) // 죽으면
        {
            state = BattleState.LOST;
            EndBattle();    // 끝
        }
        else
        {
            state = BattleState.PLAYERTURN; // 플레이어 턴
            PlayerTurn();   // 플레이어 턴
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)    // state 값 비교
        {
            Debug.Log("전투 끝 이겼다.");
            SceneManager.LoadScene("Map");
        }
        else if (state == BattleState.LOST)
        {
            Debug.Log("전투에 패했다.");
        }
    }

    
}
