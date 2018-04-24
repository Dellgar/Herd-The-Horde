using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//WIP

public class IntroScreen : MonoBehaviour {

    public Image fadePanel;
    public float fadeDuration;


    public GameObject txtScreen1;
    public GameObject txtScreen2;
    public SpriteRenderer introScreen1;
    public SpriteRenderer introScreen2;

    private bool isFadedIn;

    void Start () {
        fadePanel = GameObject.Find("fadePanel").GetComponent<Image>();
        introScreen1 = GameObject.Find("First").GetComponent<SpriteRenderer>();
        introScreen2 = GameObject.Find("Second").GetComponent<SpriteRenderer>();

        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {
        //fade in
        fadePanel.CrossFadeAlpha(0f, fadeDuration, true);
        yield return new WaitForSeconds(fadeDuration);

        //show text
        txtScreen1.SetActive(true);

        //WAIT THE TEXT
        yield return new WaitForSeconds(3);
        fadePanel.CrossFadeAlpha(1f, fadeDuration/2, true);
        yield return new WaitForSeconds(fadeDuration/2);

        Debug.Log("set screens");
        introScreen1.enabled = false;
        txtScreen1.SetActive(false);

        introScreen2.enabled = true;
        

        //fade in
        fadePanel.CrossFadeAlpha(0f, fadeDuration, true);
        yield return new WaitForSeconds(fadeDuration-1);

        txtScreen2.SetActive(true);
        
        //WAIT THE TEXT
        yield return new WaitForSeconds(8);
        fadePanel.CrossFadeAlpha(1f, fadeDuration / 7, true);
        yield return new WaitForSeconds(fadeDuration / 7);

        SceneLoader sceneLoader = GetComponent<SceneLoader>();
        sceneLoader.LoadOverworld();
        yield return null;
    }

}
