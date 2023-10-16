using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CutSceneEnter : MonoBehaviour
{
    public GameObject Player;
    public GameObject cutsceneCam;

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        cutsceneCam.SetActive(true);
        Player.SetActive(false);
        StartCoroutine(FinishCut());
    }

    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(3);
        cutsceneCam.SetActive(false);
    }
}
