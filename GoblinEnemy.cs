using System.Collections;
using Experience;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy.Goblin
{
	public class GoblinEnemy : MonoBehaviour 
	{
		[Header("Enemy")]
		[SerializeField] private GameObject theEnemy;

		[Header("Enemy Variables")]
		[SerializeField] private int _enemyHealth;
		[SerializeField] private int _baseXp;
		private int _calculatedExp;
		private bool _isDead;
	
		[Header("Items")]
		[SerializeField] private GameObject bag;
		[SerializeField] private GameObject itemStash;
		
		[Header("Scripts")]
		[SerializeField] private GoblinAI goblinAIScript;
		[SerializeField] private GoblinShowHealth goblinShowHealthScript;

		[Header("Exp")]
		[SerializeField] private GameObject xpContent;
		[SerializeField] private GameObject xpBlock;
		private GameObject _xpShower;
		private Transform _xpNumber;

		[Header("Canvas")]
		[SerializeField] private GameObject Canvas;

		private void Start()
		{
			//enemyHealth = MonstersData.Instance.GoblinHealth;
			//_baseXp = MonstersData.Instance.GoblinExp;	
			goblinAIScript = GetComponent<GoblinAI>();
			goblinShowHealthScript = GetComponent<GoblinShowHealth>();
		}

		private void DeductPoints(int _damageAmount) 
		{
			_enemyHealth -= _damageAmount;
		}

		private void Update() 
		{
			if (_enemyHealth <= 0) 
			{
				if (_isDead == false) 
				{
					StartCoroutine(DeathGoblin());
				}
			}
		}

		private IEnumerator DeathGoblin() 
		{
			goblinAIScript.enabled = false;	
			goblinShowHealthScript.enabled = false;	
			_isDead = true;

			_calculatedExp = _baseXp * GlobalExp.CurrentLevel;
			GlobalExp.CurrentExp += _calculatedExp;

			itemStash.transform.SetParent(Canvas.transform);
			itemStash.SetActive(false);

			_xpShower = Instantiate(xpBlock, xpContent.transform);
			_xpShower.SetActive(true);
			_xpShower.transform.SetParent(xpContent.transform);

			_xpNumber = _xpShower.transform.Find("xpCount/xp");
			_xpNumber.transform.GetComponent<Text>().text = "+" + _baseXp;

			yield return new WaitForSeconds (0.5f);

			GetComponent<BoxCollider>().enabled = false;
			GetComponent<CapsuleCollider>().enabled = false;
			GetComponent<Rigidbody>().isKinematic = true;

			theEnemy.GetComponent<Animation>().Play("death");

			yield return new WaitForSeconds (0.5f);

			Bag.SetActive(true);

			Destroy(_xpShower, 5);
			Destroy(theEnemy, 5);
			Destroy(itemStash, 900);
			Destroy(gameObject, 900);
		}
	}
}