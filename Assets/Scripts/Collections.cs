using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
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
    public AudioSource crunch;

    private Rigidbody rb;
    private int count;

    [SerializeField] private Volume postProcessingVolume;
    private ChromaticAberration chromaticAberration;

    void Start()
    { 
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();

        EnemyDesignEnd.SetActive(false);

        enemySpeedAdjuster = FindObjectOfType<EnemySpeedAdjuster>();

        postProcessingVolume.profile.TryGet(out chromaticAberration);
    }



    void OnTriggerEnter(Collider other)
    {
     
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            count = count + 1;

            SetCountText();
            crunch.Play();
            MushSpeed();
            VFXChanger();
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
            enemySpeedAdjuster.ogSpeed = 6.5f;
            navMeshAgent.speed = enemySpeedAdjuster.ogSpeed;
        }

        else 
        {
            enemySpeedAdjuster.ogSpeed = 6;
            navMeshAgent.speed = enemySpeedAdjuster.ogSpeed;
        }
    }



    void VFXChanger()
    {
        switch (count)
        {
            case 0:
                chromaticAberration.intensity.value = 0f;
                break;
            case 1:
                chromaticAberration.intensity.value = 0.15f;
                break;
            case 2:
                chromaticAberration.intensity.value = 0.30f;
                break;
            case 3:
                chromaticAberration.intensity.value = 0.45f;
                break;
            case 4:
                chromaticAberration.intensity.value = 0.60f;
                break;
            case 5:
                chromaticAberration.intensity.value = 0.75f;
                break;
            case 6:
                chromaticAberration.intensity.value = 0.90f;
                break;
            case 7:
                chromaticAberration.intensity.value = 1f;
                break;
            case 8:
                chromaticAberration.intensity.value = 1f;
                break;
        }
    }
}
