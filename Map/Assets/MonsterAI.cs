/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour {

    public GameObject thePlayer;
    public GameObject theEnemy;
    public float enemySpeed = 0.01f;
    public bool attackTrigger = false;
    public bool isAttacking = false;
    public GameWinningManager gameManager;

    void Update () {
        transform.LookAt(thePlayer.transform);
        if (attackTrigger == false)
        {
            enemySpeed = 0.01f;
            transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, enemySpeed);
        }
        if (attackTrigger == true && isAttacking == false)
        {
            enemySpeed = 0;
            StartCoroutine(InflictDamage());
        }

    }

    void OnTriggerEnter()
    {
        attackTrigger = true;
    }

    void OnTriggerExit()
    {
        attackTrigger = false;
    }


    IEnumerator InflictDamage()
    {
        isAttacking = true;
        yield return new WaitForSeconds(1.1f);
        gameManager.WinGameMonster();
        yield return new WaitForSeconds(0.2f);
        isAttacking = false;
    }

}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour {

    public GameObject player;
    private NavMeshAgent enemy;

	// Use this for initialization
	void Start () {
      enemy = GetComponent<NavMeshAgent>();
    }

	// Update is called once per frame
	void Update () {

        enemy.SetDestination(player.transform.position);

    }
}
