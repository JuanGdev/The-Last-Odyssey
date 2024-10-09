using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTransitions : MonoBehaviour
{
    Animator animator;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        DeathScript.OnDeath += Death;
        LevelEndCutscene.OnLevelEnded += LevelFinished;
    }

    private void OnDisable()
    {
        DeathScript.OnDeath -= Death;
        LevelEndCutscene.OnLevelEnded -= LevelFinished;
    }

    void Death() => StartCoroutine(Death_());

    void LevelFinished() => StartCoroutine(LevelFinished_());

    IEnumerator Death_()
    {
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1.5f);
        int currentSceneId = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneId);
    }

    IEnumerator LevelFinished_()
    {
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1.5f);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(currentScene.name, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        SceneManager.LoadScene("LoadingUIScene", LoadSceneMode.Additive);

        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("LevelSelector", LoadSceneMode.Single);
    }
}
