using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnTriggerLoadLevel(3D) : MonoBehaviour
{
	[Header("Distance")]
	[SerializeField] private float _theDistance;
	
	[Header("Action Object")]
	[SerializeField] private string _actionText; //Example: [E] To the Beach
	[SerializeField] private GameObject actionObject;

	[Header("Load Scene")]
	[SerializeField] private string _levelToLoad;
	[SerializeField] private GameObject fadeOut;
    
	private void Update() 
	{
		_theDistance = PlayerCasting.distanceFromTarget;
	}

	private void OnMouseOver() 
	{
		if (_theDistance <= 3) 
		{
			actionObject.GetComponent<Text>().text = _actionText;
			actionObject.SetActive(true);
			if (Input.GetButtonDown ("Action"))
			{
				fadeOut.SetActive(true);
        		StartCoroutine(TransferScene());
			}
		}
	}

	private void OnMouseExit() 
	{
		actionObject.SetActive(false);
	}
	
	private IEnumerator TransferScene()
	{
		actionObject.SetActive(false);
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene(_levelToLoad);  
	}
}
