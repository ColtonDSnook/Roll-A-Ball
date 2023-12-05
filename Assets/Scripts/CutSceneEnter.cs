using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;


public class CutSceneEnter : MonoBehaviour
{
    public GameObject Player;
    public GameObject cutsceneCam;
    public GameObject Fade;
    public GameObject EffectEnd;
    public GameObject EffectEndAnim;
    public AudioSource scream;
    public PlayableDirector stab;

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        EffectEndAnim.SetActive(true);
        EffectEnd.SetActive(false);
        cutsceneCam.SetActive(true);
        Player.SetActive(false);
        scream.Play();
        StartCoroutine(FinishCut());
        stab.Play();
    }

    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(2);
        Fade.SetActive(true);
        yield return new WaitForSeconds(2);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadSceneAsync("Game End");
    }
}
