using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CutSceneEnter : MonoBehaviour
{
    public GameObject Player;
    public GameObject cutsceneCam;
    public GameObject Fade;
    public GameObject EffectEnd;

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        cutsceneCam.SetActive(true);
        Player.SetActive(false);
        StartCoroutine(FinishCut());
    }

    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(1);
        EffectEnd.SetActive(false);
        yield return new WaitForSeconds(1);
        Fade.SetActive(true);
        yield return new WaitForSeconds(1);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadSceneAsync("Game End");
    }
}
