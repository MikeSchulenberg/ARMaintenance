using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

using Mono.Data.Sqlite;
using System.Data;
using System;
using System.IO;


public class ConnectDB : MonoBehaviour {

    private string dbpath, query, tablename, lookupValue, text;
    private IDbConnection dbcon;
    private IDbCommand dbcmd;
    private IDataReader reader;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ConnectToDB ()
    {
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

        // open connection to the SQLite3 database
        dbcon = (IDbConnection)new SqliteConnection(dbpath);
        dbcon.Open();

    }

    public void Query (string input, string record)
    {
        query = "SELECT TableName, LookupValue FROM TableList WHERE Input = '" + input + "'";
        // create database command from query command string
        dbcmd = dbcon.CreateCommand();

        // Set command text to value of query
        dbcmd.CommandText = query;

        // Read the database
        //IDataReader reader;
        reader = dbcmd.ExecuteReader();
        

        while (reader.Read())
        {
            tablename = reader.GetString(0);
            lookupValue = reader.GetString(1);
        }

        reader.Close();
        reader = null;

        query = "SELECT " + lookupValue + " FROM " + tablename + " WHERE " + input + " = '" + record + "'";
        Debug.Log("Query # 2 = " + query);
        dbcmd.CommandText = query;
        reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            text = reader.GetString(0);
        }
        Debug.Log("RETURNING VALUE : " + text);
        reader.Close();
        reader = null;

    }

    public void CloseConn ()
    {
        try {
            reader.Close();
            reader = null;

            dbcmd.Dispose();
            dbcmd = null;

            dbcon.Close();
            dbcon = null;
            Debug.Log("SUCCESSFULLY CLOSED THE CONNECTION!");
        } catch (Exception e) {
            Debug.Log("TROUBLE CLOSING CONNECTION!!!!");
        }
    }

    public string GetText ()
    {
        return text;
    }

}
