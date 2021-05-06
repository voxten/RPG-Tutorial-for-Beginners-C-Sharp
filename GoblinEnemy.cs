using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinEnemy : MonoBehaviour 
{
	  public int EnemyHealth = 10;
	  public static int Health;
    public GameObject TheGoblin;
	  public int GoblinStatus;
	  public int BaseXP = 60;
	  public int CalculatedExp;
	  public GoblinAI GoblinAIScript;
	  public GoblinShowHealth GoblinShowHealthScript;
	  public static int GlobalGoblin;
	
	  void Start()
	  {
		    GoblinAIScript = GetComponent<GoblinAI>();
		    GoblinShowHealthScript = GetComponent<GoblinShowHealth>();
	  }
	
	  void DeductPoints (int DamageAmount) 
	  {
		    EnemyHealth -= DamageAmount;
	  }

	  void Update () 
	  {
		    Health = EnemyHealth;
		    GlobalGoblin = GoblinStatus;
		    if (EnemyHealth <= 0) 
		    {
			      if (GoblinStatus == 0) 
			      {
			          StartCoroutine (DeathGoblin ());
			      }
		    }
	   }
     
	   IEnumerator DeathGoblin () 
	   {
		      GoblinAIScript.enabled = false;		
		      GoblinStatus = 6;
		      CalculatedExp = BaseXP * GlobalLevel.CurrentLevel;
		      GlobalExp.CurrentExp += CalculatedExp;
		      yield return new WaitForSeconds (0.5f);
		      GetComponent<BoxCollider>().enabled = false;
		      GetComponent<CapsuleCollider>().enabled = false;
		      GoblinShowHealthScript.enabled = false;
		      TheGoblin.GetComponent<Animation>().Play("death");
	   }
}
