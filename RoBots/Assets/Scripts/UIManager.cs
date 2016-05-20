using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	GameObject[] pauseObjects;

	// Use this for initialization
	void Start () 
	{
		// sets cursor 
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

		// set's pause.
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag ("ShowOnPause");

		foreach (GameObject g in pauseObjects) 
		{
			g.SetActive (false);
		}
		//hidePaused ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Cancel")) 
		{	
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused ();
			} 
			else if (Time.timeScale == 0) 
			{
				Time.timeScale = 1;
				hidePaused ();
			}
		}
	}

	// Reloads the Level
	public void Reload()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	//
	public void pauseControl()
	{
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
			showPaused ();
		} 
		else if (Time.timeScale == 0) 
		{
			Time.timeScale = 1;
			hidePaused();
		}
	}

	public void showPaused()
	{
		foreach (GameObject g in pauseObjects) 
		{
			g.SetActive (true);
		}
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void hidePaused() 
	{
		foreach (GameObject g in pauseObjects) 
		{
			g.SetActive (false);
		}
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	public void LoadLevel(string level)
	{
		Application.LoadLevel (level);
	}
}
