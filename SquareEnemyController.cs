using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareEnemyController : MonoBehaviour {
    public int health;
    public float speed;
    public float spawnTime;
    //minX, maxX, minY, maxY
    public float[] spawnPoints;
    //first element holds negative values -x,-y
    //second element holds positive values x,y
    private Vector2[] mapBorders;

	// Use this for initialization
	void Start () {
        mapBorders = GameObject.Find("Player").GetComponent<PlayerController>().mapBorders;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= mapBorders[0][1] + -5f)
        {
            Destroy(gameObject);
        }
	}

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0, -speed, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.Find("Player"))
        {
            Debug.Log("Player was hit by square enemy!");
            GameObject.Find("GameController").GetComponent<SoundController>().isPlayerHit = true;
            GameObject.Find("GameController").GetComponent<FinishGame>().isGameOver = true;
            Destroy(gameObject);
        }
    }
}
