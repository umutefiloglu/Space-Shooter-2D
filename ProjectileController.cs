using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {
    //projectile transform speed
    public float transformSpeed;
    public Vector2[] mapBorders;
    public GameObject ExplosionEffect;

    // Use this for initialization
    void Start () {
        mapBorders = GameObject.Find("Player").GetComponent<PlayerController>().mapBorders;
        GameObject.Find("GameController").GetComponent<SoundController>().isProjectileFired = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //fixed frame
    private void FixedUpdate()
    {
        TransformProjectile();

        //check if projectile should be destroyed or not
        if (transform.position.y >= mapBorders[1].y + 1f)
        {
            Destroy(gameObject);
        }
    }

    //projectile transform
    private void TransformProjectile()
    {
        transform.Translate(0, transformSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SquareEnemy")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreCalculator>().score += 100;
            Instantiate(ExplosionEffect, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), Quaternion.identity);
            GameObject.Find("GameController").GetComponent<SoundController>().isSquareEnemyKilled = true;
            Debug.Log("Square enemy was hit by projectile!");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
