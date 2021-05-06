using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalkAI : MonoBehaviour
{
	public int Xpos;
	public int Zpos;
	public GameObject NPCDest; //NPC Destination
	
	void Start ()
    	{
    		Xpos = Random.Range(488, 510);
       		Zpos = Random.Range(461, 480);
        	NPCDest.transform.position = new Vector3(Xpos, 0, Zpos);
        	StartCoroutine(RunRandomWalk());
	}
	
	void Update ()
	{
        	transform.LookAt(NPCDest.transform);
        	transform.position = Vector3.MoveTowards(transform.position, NPCDest.transform.position, 0.01f * Time.timeScale);
	}
	IEnumerator RunRandomWalk ()
    	{
        	yield return new WaitForSeconds(3);
        	Xpos = Random.Range(488, 510);
       		Zpos = Random.Range(461, 480);
        	NPCDest.transform.position = new Vector3(Xpos, 0, Zpos);
        	StartCoroutine(RunRandomWalk());
    	}
}

