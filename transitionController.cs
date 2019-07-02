using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionController : MonoBehaviour {
    bool unloaded = false;
	// Use this for initialization
	void Start () {
        
		
	}

    IEnumerator loadNextScene()
    {
        yield return SceneManager.LoadSceneAsync(transitionvals.nextLevel, LoadSceneMode.Additive);
        GetComponent<Animator>().SetTrigger("fadeOut");
        if (!unloaded)
            unloadOld();
    }

    public void unloadOld()
    {
        unloaded = true;
        Debug.Log(transitionvals.closableLevel);
        SceneManager.UnloadSceneAsync(transitionvals.closableLevel);
        StartCoroutine(loadNextScene());

    }

    public void unloadThis() {
        SceneManager.UnloadSceneAsync("transitions");
        
    }
	
    public static void startTransition(string oldScene, string newScene)
    {
        transitionvals.closableLevel = oldScene;
        transitionvals.nextLevel = newScene;

        SceneManager.LoadSceneAsync("transitions", LoadSceneMode.Additive);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
