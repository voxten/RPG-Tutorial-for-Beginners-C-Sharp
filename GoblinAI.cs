using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAI : MonoBehaviour
{
	public GameObject ThePlayer;
    	public float TargetDistance;
    	public float AllowedRange = 20;
    	public GameObject TheEnemy;
    	public float EnemySpeed;
    	public int AttackTrigger;
    	public RaycastHit Shot;
	public int DealingDamage;

	void Update ()
	{
		transform.LookAt (ThePlayer.transform);
        	if(Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        	{
            		TargetDistance = Shot.distance;
            		if (TargetDistance <= AllowedRange)
            	{
                	EnemySpeed = 0.02f;
                	if (AttackTrigger == 0)
                	{
                    		TheEnemy.GetComponent<Animation>().Play("run");
                    		transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, EnemySpeed * Time.timeScale);
                	}
			}
			else
       			{
                		EnemySpeed = 0;
                		TheEnemy.GetComponent<Animation>().Play("combat_idle");
        		}
        	}
        	if (AttackTrigger == 1)
        	{
			if (DealingDamage == 0)
			{
				EnemySpeed = 0;
          			TheEnemy.GetComponent<Animation>().Play("attack3");
				StartCoroutine(TakingDamage());
			}
           
       		}
	}

    	void OnTriggerEnter()
    	{
        	AttackTrigger = 1;
    	}

    	void OnTriggerExit()
    	{
        	AttackTrigger = 0;
    	}
	
	IEnumerator TakingDamage()
	{
		DealingDamage = 2;
		yield return new WaitForSeconds (0.68f);
		if (GoblinEnemy.GlobalGoblin != 6)
		{
			HealthMonitor.healthValue -= 10;
		}
		yield return new WaitForSeconds (0.2f);
		DealingDamage = 0;
	}
	
	
}
