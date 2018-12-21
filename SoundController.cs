using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {
    public AudioClip enemyApproachingSound;
    public AudioClip projectileFireSound;
    public AudioClip squareEnemyDieSound;
    public AudioClip playerDieSound;
    public AudioSource audioSource;

    public bool isSquareEnemyKilled;
    public bool isProjectileFired;
    public bool isPlayerHit;

	// Use this for initialization
	private void Start () {
        audioSource.PlayOneShot(enemyApproachingSound);
        isSquareEnemyKilled = false;
        isPlayerHit = false;
        isProjectileFired = false;
    }

    private void FixedUpdate()
    {
        PlaySound();
    }

    private void PlaySound()
    {
        if (isSquareEnemyKilled == true)
        {
            audioSource.PlayOneShot(squareEnemyDieSound);
            isSquareEnemyKilled = false;
        }
        if (isProjectileFired == true)
        {
            audioSource.PlayOneShot(projectileFireSound);
            isProjectileFired = false;
        }
        if (isPlayerHit == true)
        {
            audioSource.PlayOneShot(playerDieSound);
            isPlayerHit = false;
        }
    }
}
