using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //speed of movement
    public float playerSpeed;
    //first element holds negative values -x,-y
    //second element holds positive values x,y
    public Vector2 []mapBorders;
    //shooting speed
    public float shootingSpeed;
    //is player shooting?
    public bool isShooting;
    //projectile object
    public GameObject projectile;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnProjectile(shootingSpeed));
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    //physical calculations
    void FixedUpdate()
    {
        PlayerMovement();
        PlayerShootingTimer();
    }

    //function that controls player's movement
    private void PlayerMovement()
    {
        //left movement
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > mapBorders[0].x)
        {
            transform.Translate(-playerSpeed, 0, 0);
        }

        //right movement
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < mapBorders[1].x)
        {
            transform.Translate(playerSpeed, 0, 0);
        }

        //down movement
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > mapBorders[0].y)
        {
            transform.Translate(0, -playerSpeed, 0);
        }

        //up movement
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < mapBorders[1].y)
        {
            transform.Translate(0, playerSpeed, 0);
        }
    }
    
    //function that controls player's shooting time
    private void PlayerShootingTimer()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            isShooting = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isShooting = false;
        }
    }
    
    //function spawning projectile
    IEnumerator SpawnProjectile(float shootingSpeed)
    {
        while (true)
        {
            if (isShooting == true)
            {
                Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
                yield return new WaitForSeconds(shootingSpeed);
            }
            else
            {
                yield return null;
            }
        }
    }
}
