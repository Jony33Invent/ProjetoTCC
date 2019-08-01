using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class mainMenuScript : MonoBehaviour
{
	public GameObject menu;

 	public void NextScene(){
 		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
 	}
 	public void LastScene(){
 		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
 	}

 	public void LoadMenu(){
 		SceneManager.LoadScene(0);
 	}
 	public void LoadGame(){
 		SceneManager.LoadScene(1);
 	}
 	public void LoadOver(){
 		SceneManager.LoadScene(2);
 	}
 	public void QuitGame(){
 		Application.Quit();
 	}
 	public void CloseMenu(){
 	 Time.timeScale = 1;
                menu.SetActive(false);
 	}
}
