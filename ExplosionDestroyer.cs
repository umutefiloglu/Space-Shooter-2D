using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(DestroyThisObject());
	}
	
	IEnumerator DestroyThisObject()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
