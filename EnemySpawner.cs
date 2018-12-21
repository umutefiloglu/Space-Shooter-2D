using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public bool isGameOver;
    public int gameLevel;
    public GameObject squareEnemy;

    private void Awake()
    {
        isGameOver = false;
    }

    // Use this for initialization
    void Start () {
        gameLevel = 1;
        StartCoroutine(SquareEnemyInstantiator());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        
    }

    IEnumerator SquareEnemyInstantiator()
    {
        while (isGameOver == false)
        {
            float randomEnemyX = Random.Range(squareEnemy.GetComponent<SquareEnemyController>().spawnPoints[0], squareEnemy.GetComponent<SquareEnemyController>().spawnPoints[2]);
            float randomEnemyY = Random.Range(squareEnemy.GetComponent<SquareEnemyController>().spawnPoints[1], squareEnemy.GetComponent<SquareEnemyController>().spawnPoints[3]);

            if (gameLevel == 1)
            {
                Instantiate(squareEnemy, new Vector3(randomEnemyX, randomEnemyY, 0), Quaternion.identity);
                yield return new WaitForSeconds(squareEnemy.GetComponent<SquareEnemyController>().spawnTime);
            }
        }
        yield return null;
    }
}
