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
    private DepthOfField depthOfField;
    private LensDistortion lensDistortion;
    private ColorAdjustments colorAdjustments;

    void Start()
    { 
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();

        EnemyDesignEnd.SetActive(false);

        enemySpeedAdjuster = FindObjectOfType<EnemySpeedAdjuster>();

        postProcessingVolume.profile.TryGet(out chromaticAberration);
        postProcessingVolume.profile.TryGet(out depthOfField);
        postProcessingVolume.profile.TryGet(out lensDistortion);
        postProcessingVolume.profile.TryGet(out colorAdjustments);
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
                depthOfField.gaussianStart.value = 10f;
                depthOfField.gaussianEnd.value = 50f;
                lensDistortion.intensity.value = 0f;
                colorAdjustments.contrast.value = 0f;
                colorAdjustments.saturation.value = 0f;
                break;
            case 1:
                chromaticAberration.intensity.value = 0.15f;
                depthOfField.gaussianStart.value = 9f;
                depthOfField.gaussianEnd.value = 45f;
                lensDistortion.intensity.value = 0.1f;
                colorAdjustments.contrast.value = -5f;
                colorAdjustments.saturation.value = 0f;
                break;
            case 2:
                chromaticAberration.intensity.value = 0.30f;
                depthOfField.gaussianStart.value = 8f;
                depthOfField.gaussianEnd.value = 40f;
                lensDistortion.intensity.value = 0.2f;
                colorAdjustments.contrast.value = -10f;
                colorAdjustments.saturation.value = 10f;
                break;
            case 3:
                chromaticAberration.intensity.value = 0.45f;
                depthOfField.gaussianStart.value = 7f;
                depthOfField.gaussianEnd.value = 35f;
                lensDistortion.intensity.value = 0.3f;
                colorAdjustments.contrast.value = -15f;
                colorAdjustments.saturation.value = 25f;
                break;
            case 4:
                chromaticAberration.intensity.value = 0.60f;
                depthOfField.gaussianStart.value = 6f;
                depthOfField.gaussianEnd.value = 30f;
                lensDistortion.intensity.value = 0.4f;
                colorAdjustments.contrast.value = -20f;
                colorAdjustments.saturation.value = 40f;
                break;
            case 5:
                chromaticAberration.intensity.value = 0.75f;
                depthOfField.gaussianStart.value = 5f;
                depthOfField.gaussianEnd.value = 25f;
                lensDistortion.intensity.value = 0.5f;
                colorAdjustments.contrast.value = -25f;
                colorAdjustments.saturation.value = 55f;
                break;
            case 6:
                chromaticAberration.intensity.value = 0.90f;
                depthOfField.gaussianStart.value = 4f;
                depthOfField.gaussianEnd.value = 20f;
                lensDistortion.intensity.value = 0.6f;
                colorAdjustments.contrast.value = -30f;
                colorAdjustments.saturation.value = 70f;
                break;
            case 7:
                chromaticAberration.intensity.value = 1f;
                depthOfField.gaussianStart.value = 3f;
                depthOfField.gaussianEnd.value = 15f;
                lensDistortion.intensity.value = 0.7f;
                colorAdjustments.contrast.value = -35f;
                colorAdjustments.saturation.value = 85f;
                break;
            case 8:
                chromaticAberration.intensity.value = 1f;
                depthOfField.gaussianStart.value = 2f;
                depthOfField.gaussianEnd.value = 10f;
                lensDistortion.intensity.value = 0.8f;
                colorAdjustments.contrast.value = -40f;
                colorAdjustments.saturation.value = 100f;
                break;
        }
    }
}
