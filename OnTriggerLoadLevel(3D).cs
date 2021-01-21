using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnTriggerLoadLevel(3D) : MonoBehaviour
{
	public float TheDistance;
	public GameObject ActionDisplay;
	public GameObject ActionText;
	public GameObject fadeOut;
    public string levelToLoad;
	
	void Update () 
	{
		TheDistance = PlayerCasting.DistanceFromTarget;
	}

	void OnMouseOver () 
	{
		if (TheDistance <= 3) 
		{
			ActionText.GetComponent<Text> ().text = "To the Beach";
			ActionDisplay.SetActive (true);
			ActionText.SetActive (true);
		}

		if (Input.GetButtonDown ("Action"))
			{
			if (TheDistance <= 3) 
			{	
		        fadeOut.SetActive(true);
                StartCoroutine(TransferScene());
			}
		}
	}

	void OnMouseExit() 
	{
		AttackBlocker.BlockSword = 0;
		ActionDisplay.SetActive (false);
		ActionText.SetActive (false);
	}
	
	IEnumerator TransferScene()
	{
	    ActionDisplay.SetActive (false);
		ActionText.SetActive (false);
		yield return new WaitForSeconds(2);
        SceneManager.LoadScene(levelToLoad);  
		
	}
	
	
	
	
}
