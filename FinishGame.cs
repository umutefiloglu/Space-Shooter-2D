using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour {
    public bool isGameOver;

    private void Awake()
    {
        isGameOver = false;
    }

    private void FixedUpdate()
    {
        if (isGameOver == true)
        {
            SceneManager.LoadScene("SampleScene");
            isGameOver = false;
        }
    }
}
