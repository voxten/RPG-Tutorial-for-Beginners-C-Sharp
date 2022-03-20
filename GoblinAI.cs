using System.Collections;
using Player;
using UnityEngine;

namespace Enemy.Goblin
{
    public class GoblinAI : MonoBehaviour
    {
        [Header("Bools")]
        private bool _attackTrigger;
        private bool _dealingDamage;
        private bool _deathRemove;

        [Header("Distance")]
        [SerializeField] private float targetDistance;
        [SerializeField] private float allowedRange;
        private RaycastHit _shot;

        [Header("Enemy")]
        [SerializeField] private float enemySpeed;
        [SerializeField] private GameObject theEnemy;
    
        [Header("Player")]
        [SerializeField] private GameObject thePlayer;
    
        [Header("Scripts")]
        [SerializeField] private GoblinEnemy goblinEnemyScript;

        [Header("Rest")]
        private int _attackCount;

        private void Start() 
        {
            allowedRange = MonstersData.GoblinRange;
            goblinEnemyScript = GetComponent<GoblinEnemy>();	
        }

        void Update()
        {
            var position = thePlayer.transform.position;
            transform.LookAt(new Vector3(position.x, this.transform.position.y, position.z));
            if(Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out _shot))
            {
                targetDistance = _shot.distance;
                if (targetDistance <= allowedRange)
                {
                    enemySpeed = 0.005f;
                    if (_attackTrigger == false)
                    {
                        if (HealthMonitor.Dead == false)
                        {
                            theEnemy.GetComponent<Animation>().Play("run");
                            transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, enemySpeed * Time.timeScale);
                        }
                        else 
                        {
                            enemySpeed = 0;
                            if(_deathRemove == false) 
                            {
                                theEnemy.GetComponent<Animation>().Play("remove_weapons");
                                _deathRemove = true;
                            }
                        }
                    }
                }
                else
                {
                    enemySpeed = 0;
                    theEnemy.GetComponent<Animation>().Play("combat_idle"); 
                }
            }
		
            if (_attackTrigger)
            {
                if (_dealingDamage == false)
                {
                    enemySpeed = 0;
                    if (_attackCount == 0)
                    {
                        theEnemy.GetComponent<Animation>().Play("attack3");
                        StartCoroutine(AttackAnim1());
                        _attackCount = 1;
                    }
                    else 
                    {
                        theEnemy.GetComponent<Animation>().Play("attack1");
                        StartCoroutine(AttackAnim2());
                        _attackCount = 0;
                    }
                }
            }
        }

        private void OnTriggerEnter(Collider other) 
        {
            if (other.CompareTag("Player"))
            {
                _attackTrigger = true;
            }
        }

        private void OnTriggerStay(Collider other) 
        {
            if (HealthMonitor.Dead)
            {
                _attackTrigger = false;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _attackTrigger = false;
            }
        }

        private IEnumerator AttackAnim1()
        {
            _dealingDamage = true;
            yield return new WaitForSeconds (0.68f);
            if (goblinEnemyScript.isDead != true)
            {
                HealthMonitor.HealthValue -= 10;
            }
            yield return new WaitForSeconds (0.4f);
            _dealingDamage = false;
        }

        private IEnumerator AttackAnim2()
        {
            _dealingDamage = true;
            yield return new WaitForSeconds (1.16f);
            if (goblinEnemyScript.isDead != true)
            {
                HealthMonitor.HealthValue -= 50;
            }
            yield return new WaitForSeconds (0.4f);
            _dealingDamage = false;
        }
    }
}