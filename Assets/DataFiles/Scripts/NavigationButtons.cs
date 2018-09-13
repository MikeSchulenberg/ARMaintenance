using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class NavigationButtons : MonoBehaviour {

	private string nextScene, prevScene, currentScene;	// consider making private
	//initializing variables for tests
	public void Construct(string currentscene, string prevscene, string nextscene ){
		currentScene = currentscene;
		prevScene = prevscene;
		nextScene = nextscene;

	}
	// initialize the currentScene value
	void Start () {
		currentScene = SceneManager.GetActiveScene().name;
		Debug.Log ("Current Scene set to " + '"' + currentScene + '"');
	}

	public void goToMainMenu() {
		SceneManager.LoadScene("Home");
		SceneHandler.Instance.clearPrevScene();
		Debug.Log("Main Menu Button pressed");
	}

	public void goToNextScene() {
		// get the name of the button that called this goToNextScene function
		string button = EventSystem.current.currentSelectedGameObject.name;
		Debug.Log("The name of the button is " + button);

		// retrieve the name of the next scene
		string nextSceneName = SceneHandler.Instance.getNextScene(button);
		Debug.Log("Button " + button + " called " + nextSceneName);

		// push the current scene to the top of the previous scene stack
		SceneHandler.Instance.pushPrevScene(currentScene);
		Debug.Log ("SceneHandler changed prevScene value to " + '"' + SceneHandler.Instance.getPrevScene() + '"');

		// load the next scene
		SceneManager.LoadScene(nextSceneName);
		Debug.Log("Next Button pressed");
	}

	// Return user to the previous scene
	public void goToPrevScene() {
		// return the previous scene name from the stack
		prevScene = SceneHandler.Instance.getPrevScene();
		Debug.Log("Current Previous Scene set to " + prevScene);

		// load the previous scene
		SceneManager.LoadScene(prevScene);

		// pop the top off the previous scene stack
		SceneHandler.Instance.popPrevScene();

		Debug.Log("Prev Button pressed " + prevScene);
	}

    	public void closeApp() {
		Application.Quit();
		Debug.Log("Close Button pressed");
	}

    	public void refreshScene() {
        	SceneManager.LoadScene(currentScene);
        	Debug.Log("Refreshed Scene Button Pressed.");
    	}
}
