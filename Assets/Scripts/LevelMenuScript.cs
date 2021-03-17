using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuScript : MonoBehaviour
{
	public void PlayLevelOne()
   {
   		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
}
