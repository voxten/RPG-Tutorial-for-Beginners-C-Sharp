using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy.Goblin
{
	public class GoblinShowHealth : MonoBehaviour
	{
		[Header("Distance")]
		[SerializeField] private float _theDistance;
	
		[Header("Canvas Objects")]
		[SerializeField] private GameObject monsterText;
		[SerializeField] private GameObject healthEnemy;
		[SerializeField] private GameObject healthBar;

		[Header("Enemy Health")]
		private int _healthValue;

		[Header("Scripts")]
		public GoblinEnemy goblinEnemyScript;

		private void Start() 
		{
			goblinEnemyScript = GetComponent<GoblinEnemy>();		
		}

		private void Update() 
		{
			_healthValue = goblinEnemyScript.enemyHealth;
			_theDistance = PlayerCasting.distanceFromTarget;

			if (PlayerCasting.isUp)
			{
				monsterText.SetActive(false);
				healthEnemy.SetActive(false);
			}
		}

		private void OnMouseOver() 
		{
			if (HealthMonitor.Dead == false)
			{
				if (goblinEnemyScript.isDead == false)
				{
					if (PlayerCasting.isUp == false)
					{
						if (_theDistance <= 10) 
						{
							monsterText.GetComponent<Text> ().text = "Goblin";
							healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2((_healthValue * 45), 20);
							monsterText.SetActive(true);
							healthEnemy.SetActive(true);
						}
						else 
						{
							monsterText.SetActive(false);
							healthEnemy.SetActive(false);
						}	
					}

				}
				else 
				{
					healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 20);
				}
			}
		}

		private void OnMouseExit() 
		{
			monsterText.SetActive(false);
			healthEnemy.SetActive(false);
		}
	}
}