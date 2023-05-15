using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    // // Start is called before the first frame update
    // private void Start()
    // {
    //     var currentScene = SceneManager.GetActiveScene();
    //     int currentLevel = int.Parse(currentScene.name.Split("Level")[1]);
    //     int nextLevel = currentLevel + 1;
    //     var nextScene = SceneManager.GetSceneByName("Level"+nextLevel);
    //     if(nextScene == null)
    //         this.gameObject.SetActive(false);
    // }

    public void NextLevel(string nextLevelName)
    {
        SceneManager.LoadScene(nextLevelName);
    }
}
