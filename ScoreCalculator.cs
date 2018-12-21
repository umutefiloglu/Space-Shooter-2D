using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour {
    public GameObject GUI;
    public int score;

    private void Awake()
    {
        score = 0;
        GUI.GetComponent<Text>().text = "Score: " + score;
    }
	
	private void FixedUpdate ()
    {
        GUI.GetComponent<Text>().text = "Score: " + score; ;
    }
}
