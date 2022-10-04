using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalkAI : MonoBehaviour
{
	[Header("NPC")]
	[SerializeField] private int walkTimeChange = 3;
	[SerializeField] private GameObject npcDest; 
	
	[Header("X Position")]
	[SerializeField] private int xMinPos;
	[SerializeField] private int xMaxPos;
	private int _xPos;

	[Header("Z Position")]
	[SerializeField] private int zMinPos;
	[SerializeField] private int zMaxPos;
	private int _zPos;
	
	private void Start()
	{
		RangeInitialization()
		StartCoroutine(RunRandomWalk());
	}
	
	private void Update()
	{
		transform.LookAt(npcDest.transform);
		transform.position = Vector3.MoveTowards(transform.position, npcDest.transform.position, 0.01f * Time.timeScale);
	}

	private IEnumerator RunRandomWalk()
	{
		yield return new WaitForSeconds(walkTimeChange);
		RangeInitialization()
		StartCoroutine(RunRandomWalk());
	}

	private void RangeInitialization()
	{
		_xPos = Random.Range(xMinPos, xMaxPos);
		_zPos = Random.Range(zMinPos, zMaxPos);
		npcDest.transform.position = new Vector3(_xPos, 0, _zPos);
	}
}