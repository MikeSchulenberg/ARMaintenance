using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

using Mono.Data.Sqlite;
using System.Data;
using System;
using System.IO;

public class queryTaskInstruction : MonoBehaviour {
	// variables for database query
	public Text instruction;
    public ConnectDB dbcon;

    void Start () {

        string currentScene = SceneManager.GetActiveScene().name;
        //Debug.Log("Current Scene is " + currentScene);

        dbcon.ConnectToDB();
        dbcon.Query("Scene", currentScene);
        dbcon.CloseConn();
        instruction.text = dbcon.GetText();
        //Debug.Log("------------------------WE GOT THE TEXT--------------------: " + dbcon.GetText());
    }

/*
	// Use this for initialization
	void Start () {
		// test dbpath
		string dbpath;

		#if UNITY_IOS
		dbpath = "URI=" + Application.dataPath + "/Raw/jobsDB.db";
		Debug.Log("Building for iOS platform");
		#endif

		#if UNITY_STANDALONE_OSX
		dbpath = "URI=" + Application.dataPath + "/StreamingAssets/jobsDB.db";
		Debug.Log("Building for OSX platform");
		#endif

		#if UNITY_STANDALONE_WIN
		dbpath = "URI=file:" + Application.dataPath + "/StreamingAssets/jobsDB.db";
//		dbpath = "URI=" + System.IO.Path.Combine(Application.streamingAssetsPath, "jobsDB.db");
		Debug.Log("Building for Windows platform");
		#endif

		#if UNITY_ANDROID
		dbpath = "jar:file://" + Application.dataPath + "!/assets/StreamingAssets/jobsDB.db";
		Debug.Log("Building for Android platform");
		#endif

		#if UNITY_EDITOR
		Debug.Log("Playing in Unity Editor");
		#endif

		Debug.Log("Database Path set to " + dbpath);

		// iOS database path => comment out Windows/MacOS and Android database path if using iOS
//		string dbpath = "URI=" + Application.dataPath + "/Raw/jobsDB.db";

		// Windows or MacOS database path => comment out iOS and Android database path if using Windows/MacOS
//		string dbpath = "URI=" + Application.dataPath + "/StreamingAssets/jobsDB.db";

		// Android database path => comment out iOS and Windows/MacOS database path if using Android
//		string dbpath = "jar:file://" + Application.dataPath + "!/assets/StreamingAssets/jobsDB.db";

		// Dynamically detect current scene name
		string currentScene = SceneManager.GetActiveScene().name;
		Debug.Log("Current Scene is " + currentScene);

		// query command string to be used at dbcon.CreateCommand() call
		string query = "SELECT TaskInstruction FROM JobTasks WHERE Scene = '" + currentScene + "'";

		// open connection to the SQLite3 database
		IDbConnection dbcon;
		dbcon = (IDbConnection)new SqliteConnection(dbpath);
		dbcon.Open();

		// create database command from query command string
		IDbCommand dbcmd;
		dbcmd = dbcon.CreateCommand();

		// Set command text to value of query
		dbcmd.CommandText = query;

		// Read the database
		IDataReader reader;
		reader = dbcmd.ExecuteReader();

		while (reader.Read()) {
			string task = reader.GetString(0);
			instruction.text = task;	// set value for text component in top Panel of scene
			Debug.Log("Task is " + task);
		}
		Debug.Log("Successfully read query results ... putting toys back in toy box");

		// Cleanup
		reader.Close();
		reader = null;

		dbcmd.Dispose();
		dbcmd = null;

		dbcon.Close();
		dbcon = null;
	}
*/


	// Update is called once per frame
	void Update () {

	}
}
