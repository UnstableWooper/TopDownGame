using System;
using System.Collections;
using UnityEngine;
using Upgrades;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]private GameObject[] enemies;
        
        [SerializeField]private float roundLength;
        [SerializeField]private float roundPhasesLength;
        [SerializeField]private float roundPhases;
        [SerializeField]private Vector2 enemyRangeAmount; // vector2 for pick random between x, and y 
        //[SerializeField]public Vector2 enemyAddAmount;
        [SerializeField]private Transform[] spawnPoints;
        
        public bool StartRound{get; private set;}
        private GameObject[] _enemyCount;

        private GameObject _camera;
        private Upgrade _upgrade;
        
        void Start()
        {
            _camera = GameObject.FindGameObjectWithTag("MainCamera");
            _upgrade = GetComponent<Upgrade>();
            
            StartRound = true;
        }

        private void Update()
        {
            if (StartRound)
            {
                StartRound = false;
                _upgrade.NewRound();
                StartCoroutine(Wave(0));
                
            }
            _enemyCount = GameObject.FindGameObjectsWithTag("Enemy");
        }

        IEnumerator Wave(int round)
        {
            for (int i = 0; i < roundPhases; i++)
            {
                int enemyAmount = Mathf.RoundToInt(Random.Range(enemyRangeAmount.x, enemyRangeAmount.y));
                for (int n = 0; n < enemyAmount; n++)
                {
                    
                    int pickRandEnemeyType = Random.Range(0, enemies.Length + round );
                    int pickRandSpawnPoint = Random.Range(0, spawnPoints.Length);
                    Instantiate(enemies[pickRandEnemeyType], spawnPoints[pickRandSpawnPoint].transform.position + _camera.transform.position, Quaternion.identity);
                }
                yield return new WaitForSeconds(roundPhasesLength);
            }
            yield return new WaitUntil(() => _enemyCount.Length == 0);
            StartRound = true;
            round++;
        }
    }
}
