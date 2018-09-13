using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ConfirmationMenu : MonoBehaviour {
    public ConnectDB dbcon;
	public GameObject menu;
	public CanvasGroup uiButtons;
	public Text confirmationMsg;
	enum ConfirmationMode {goHome, callExpert};
	ConfirmationMode currentMode;
    //objects used for call expert layout.
    public Sprite callIcon;
    public Sprite endCallIcon;
    public Button CallButton;
    public Image ExpertSupportCameraFeed;
    public static bool onCall;

    // Use this for initialization
    void Start () 
	{
		hideMenu();
        //this sets the expert camera feed if the user is on call with a expert.
        if (onCall)
        {
            showExpert();
        }
        else
        {
            hideExpert();
        }

    }

	public void prepForCallExpert()
	{
        try
		{
            if (!onCall)
            {
                dbcon.ConnectToDB();
                dbcon.Query("Task", "CallExpert");
                dbcon.CloseConn();
                confirmationMsg.text = dbcon.GetText();
            } else if(onCall)
            {
                dbcon.ConnectToDB();
                dbcon.Query("Task", "HangUp");
                dbcon.CloseConn();
                confirmationMsg.text = dbcon.GetText();
            }
		}

		catch (Exception e)
		{
			Debug.Log(e.Message);
		}
		
		finally
		{
			currentMode = ConfirmationMode.callExpert;
			unhideMenu();
        }
	}

	public void prepForCompleteJob()
	{
        try
		{
			dbcon.ConnectToDB();
        	dbcon.Query("Task", "CompleteJob");
        	dbcon.CloseConn();
        	confirmationMsg.text = dbcon.GetText();
		}

		catch (Exception e)
		{
			Debug.Log(e.Message);
		}
        
		finally
		{
			currentMode = ConfirmationMode.goHome;
			unhideMenu();
		}
	}

	public void prepForGoHome()
	{
		try
		{
			dbcon.ConnectToDB();
        	dbcon.Query("Task", "GoHome");
        	dbcon.CloseConn();
        	confirmationMsg.text = dbcon.GetText();
		}

		catch (Exception e)
		{
			Debug.Log(e.Message);
		}
		
		finally
		{
			currentMode = ConfirmationMode.goHome;
			unhideMenu();
		}
	}

	public void confirm()
	{
		switch (currentMode)
		{
			case ConfirmationMode.callExpert:
                if (CallButton.image.sprite == callIcon)
                {
                    showExpert();
                    onCall = true;
                } else if (CallButton.image.sprite == endCallIcon)
                {
                    hideExpert();
                    onCall = false;
                }
                hideMenu();
               // SceneHandler.Instance.pushPrevScene(SceneManager.GetActiveScene().name);
               // SceneManager.LoadScene("CallExpert");
                break;
			case ConfirmationMode.goHome:
				if (!SceneHandler.Instance.isPrevSceneEmpty()) {
					SceneHandler.Instance.clearPrevScene();
				}
				onCall = false;
				SceneManager.LoadScene("Home");
				break;
		}
	}

	public void cancel()
	{
		hideMenu();
	}

	private void hideMenu()
	{
		menu.SetActive(false);
		enableUIbuttons();
	}
	private void unhideMenu()
	{
		menu.SetActive(true);
		disableUIbuttons();
	}

	private void disableUIbuttons()
	{
		if (uiButtons != null)
			uiButtons.interactable = false;
	}

	private void enableUIbuttons()
	{
		if (uiButtons != null)
			uiButtons.interactable = true;
	}

    private void showExpert()
    {
        CallButton.image.sprite = endCallIcon;
        ExpertSupportCameraFeed.enabled = true;
    }

    private void hideExpert()
    {
        CallButton.image.sprite = callIcon;
        ExpertSupportCameraFeed.enabled = false;
    }
}
