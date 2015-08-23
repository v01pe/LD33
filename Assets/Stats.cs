using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour
{
	public GUIText text;

	private int score;


	// Use this for initialization
	void Start ()
	{
		score = 0;
		AddScore(0);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void AddScore(int add=1)
	{
		score += add;
		text.text = "score: " + score;
	}
}
