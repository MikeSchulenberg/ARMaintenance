using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class NavigationButtonTest {

	[UnityTest]
	public IEnumerator TestgoToMainMenu() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		var gameObject = new GameObject();
		var menu = gameObject.AddComponent<NavigationButtons> ();
		var sceneHandler = gameObject.AddComponent<SceneHandler> ();
		menu.Construct ("Home", "Home", "");
		menu.goToMainMenu ();
		yield return null;

		LogAssert.Expect (LogType.Log, "Main Menu Button pressed");

	}

	[UnityTest]
	public IEnumerator TestCloseApp(){
		var gameObject = new GameObject ();
		var closeapp = gameObject.AddComponent<NavigationButtons> ();
		closeapp.closeApp ();
		yield return null;
		LogAssert.Expect (LogType.Log, "Close Button pressed");
	}
	[UnityTest]
	public IEnumerator TestRefreshScene(){
		var gameObject = new GameObject ();
		var refresh = gameObject.AddComponent<NavigationButtons> ();
		refresh.Construct ("Home", "Home", "");
		refresh.refreshScene ();
		yield return null;
		LogAssert.Expect (LogType.Log, "Refreshed Scene Button Pressed.");
	}


}
