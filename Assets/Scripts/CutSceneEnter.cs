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
    public GameObject EffectEndAnim;
    public AudioSource scream;

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        EffectEndAnim.SetActive(true);
        EffectEnd.SetActive(false);
        cutsceneCam.SetActive(true);
        Player.SetActive(false);
        StartCoroutine(FinishCut());
    }

    IEnumerator FinishCut()
    {
        scream.Play();
        yield return new WaitForSeconds(2);
        Fade.SetActive(true);
        yield return new WaitForSeconds(1);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadSceneAsync("Game End");
    }
}
