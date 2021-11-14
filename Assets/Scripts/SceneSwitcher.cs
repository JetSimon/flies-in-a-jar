using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    [SerializeField]
    Animator fuzzAnimator;

    [SerializeField]
    string scene;

    public void SwitchScene()
    {
        StartCoroutine(_SwitchScene(scene,1f));

    }

    
    IEnumerator _SwitchScene(string s, float t)
    {
        fuzzAnimator.SetTrigger("Fade");
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene(s);
        yield break;
    }
}