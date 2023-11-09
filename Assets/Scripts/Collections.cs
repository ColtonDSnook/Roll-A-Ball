using UnityEngine;
using UnityEngine.AI;

using TMPro;
using System.Collections;

public class Collections : MonoBehaviour
{

    
    public TextMeshProUGUI countText;
    public GameObject EnemyDesignEnd;
    public GameObject Enemy;
    public GameObject CutSceneTrigger;
    public GameObject counter;
    public GameObject fight;
    public EnemySpeedAdjuster enemySpeedAdjuster;
    public NavMeshAgent navMeshAgent;

    private Rigidbody rb;
    private int count;

    void Start()
    { 
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();

        EnemyDesignEnd.SetActive(false);

        enemySpeedAdjuster = FindObjectOfType<EnemySpeedAdjuster>();
    }



    void OnTriggerEnter(Collider other)
    {
     
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            count = count + 1;

            SetCountText();
            MushSpeed();
        }
    }

    

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 8)
        {
            counter.SetActive(false);
            EnemyDesignEnd.SetActive(true);
            Enemy.SetActive(false);
            CutSceneTrigger.SetActive(true);
            StartCoroutine(FightBack());
        }

        IEnumerator FightBack()
        {
            fight.SetActive(true);
            yield return new WaitForSeconds(1);
            fight.SetActive(false);
            yield return new WaitForSeconds(1);
            fight.SetActive(true);
            yield return new WaitForSeconds(1);
            fight.SetActive(false);
            yield return new WaitForSeconds(1);
            fight.SetActive(true);
            yield return new WaitForSeconds(1);
            fight.SetActive(false);
        }
    }
    void MushSpeed()
    {
        if (count <= 4)
        {
            enemySpeedAdjuster.ogSpeed = 8;
            navMeshAgent.speed = enemySpeedAdjuster.ogSpeed;
        }

        else 
        {
            enemySpeedAdjuster.ogSpeed = 7;
            navMeshAgent.speed = enemySpeedAdjuster.ogSpeed;
        }
    }
}
