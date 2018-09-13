using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {
//	private string prevScene;	//working on adding nextScene
	private static Stack<string> prevSceneStack = new Stack<string>();
	private static readonly Dictionary<string, string> homeLinkTo = new Dictionary<string, string>() {
		{"Electrical_Icon", "ElectricalMaintence"},
		{"Mechanical_Icon", "RegularMaintence"},
		{"Emergency_Electrical_Icon", "EmergencyElectrical"},
		{"Emergency_Mechanical_Icon", "EmergencyMechanical"}
	};

	private static Dictionary<string, string> jobCatLinkTo = new Dictionary<string, string>() {
		// Regular Scheduled Electrical Maintenance
		{"Install_Batteries_Into_Flashlight", "01-InstallFlashlightBatteries"},
		{"Replace_Lightbulb", "sampleTask"},
		{"Install_240_VPlug", "sampleTask"},
		{"Replace_Circuit_Board", "sampleTask"},

		// Regular Scheduled Mechanical Maintenance
		{"Replace_Washer", "unscrew_Bolt_From_ziplock"},
		{"Replace_Oil_Filter", "sampleTask"},
		{"Replace_APU", "sampleTask"},
		{"Change_Tire", "sampleTask"},

		// Emergency Electrical Maintenance
		{"Replace_CB1", "sampleTask"},
		{"Replace_CB2", "sampleTask"},
		{"Replace_CB3", "sampleTask"},
		{"Replace_CB4", "sampleTask"},

		// Emergency Mechanical Maintenance
		{"Repair_BrakeLines1", "sampleTask"},
		{"Repair_BrakeLines2", "sampleTask"},
		{"Repair_BrakeLines3", "sampleTask"},
		{"Repair_BrakeLines4", "sampleTask"}
	};

	private static Dictionary<string, string> nextLinkTo = new Dictionary<string, string>() {
		{"01-InstallFlashlightBatteries", "02-InstallFlashlightBatteries"},
		{"02-InstallFlashlightBatteries", "03-InstallFlashlightBatteries"},
		{"03-InstallFlashlightBatteries", "04-InstallFlashlightBatteries"},
		{"04-InstallFlashlightBatteries", "05-InstallFlashlightBatteries"},
		{"unscrew_Bolt_From_Ziplock", "Take_Washer_Off_Bolt"},
		{"Take_Washer_Off_Bolt", "Place_Washer_on_Bolt"},
		{"Place_Washer_on_Bolt", "Screw_Bolt_into_Ziplock"}
	};

	public static SceneHandler Instance { get; private set; }

	void Awake () {

		if (Instance != null && Instance != this) {
			Destroy (gameObject);
		}

		Instance = this;

		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
		prevSceneStack.Push(SceneManager.GetActiveScene().name);
		Debug.Log("prevScene value is initialized to " + '"' + prevSceneStack.Peek() + '"');
	}

	// pushPrevScene is called when the user navigates to the next scene
	public void pushPrevScene (string name) {
		prevSceneStack.Push(name);
		Debug.Log("prevScene value is changed to " + prevSceneStack.Peek());
	}

	// popPrevScene is called when the user navigates to the previous scene
	public void popPrevScene () {
		prevSceneStack.Pop();
		if (!isPrevSceneEmpty()) {
			Debug.Log("prevScene value is changed to " + prevSceneStack.Peek());
		}
		else {
			Debug.Log("prevScene stack is empty");
		}

	}

	// returns the previous scene string value
	public string getPrevScene () {
		return prevSceneStack.Peek();
	}

	// returns state of stack
	public bool isPrevSceneEmpty() {
		return prevSceneStack.Count > 0;
	}

	// clear previous scene stack
	public void clearPrevScene() {
		prevSceneStack.Clear();
	}

	// homeLinkTo navigation
	public string getNextScene (string key) {
		Debug.Log("The key value is " + key);

		string currentScene = SceneManager.GetActiveScene().name;
		Debug.Log("The current scene is " + currentScene);

		if (currentScene == "Home") {
			return homeLinkTo[key];
		}
		else if (jobCatLinkTo.ContainsKey(key)) {
			return jobCatLinkTo[key];
		}
		else {
			return nextLinkTo[currentScene];
		}
	}
}
