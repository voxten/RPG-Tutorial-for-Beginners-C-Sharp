using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinShowHealth : MonoBehaviour
{
	public float TheDistance;
	public GameObject EnemyText;
	public GameObject healthGoblin;
	public GameObject healthBar;
	private int healthValue;

	void Update () 
	{
		healthValue = GoblinEnemy.Health;
		TheDistance = PlayerCasting.DistanceFromTarget;
		healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(healthValue, 20);
	}

	void OnMouseOver () 
	{
		if (TheDistance <= 10) 
		{
			EnemyText.GetComponent<Text> ().text = "Goblin";
			EnemyText.SetActive (true);
			healthGoblin.SetActive (true);
		}		
	}

	void OnMouseExit() 
	{
		EnemyText.SetActive (false);
		healthGoblin.SetActive (false);
	}
	
}
