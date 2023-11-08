using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.ProBuilder;
using UnityEngine.SceneManagement;

public class EnemySpeedAdjuster : MonoBehaviour
{
    public NavMeshAgent enemy;


    public void ChaseTimer()
    {
        enemy = FindObjectOfType<NavMeshAgent>();
        StartCoroutine(Stamina());
    }

    IEnumerator Stamina()
    {
        yield return new WaitForSeconds(10);
        float newSpeed = 3.0f;
        enemy.speed = newSpeed;
        yield return new WaitForSeconds(8);
        float ogSpeed = 8.0f;
        enemy.speed = ogSpeed;

    }
}
