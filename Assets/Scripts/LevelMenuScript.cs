using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelMenuScript : MonoBehaviour
{

	public void PlayLevelOne()
   {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayLevelTwo()
   {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 2);
    }

}
