using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateScene : MonoBehaviour
{

    private void Update()
    {
        loadNextLevel();
    }

    public void loadNextLevel()
    {
        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator loadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(levelIndex);
    }

}
