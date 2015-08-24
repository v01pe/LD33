using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour
{
	public GUIText text;
	public GUIText gameOver;

	private int score;
	private int prey;
	private bool over;

	private static int bestScore = 0;
	private static bool hintVisible = true;

	// Use this for initialization
	void Start ()
	{
		score = 0;
		over = false;
		UpdateText();
		gameOver.text = (hintVisible) ? "Move with WASD or cursor keys" : "";
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (hintVisible && Input.anyKeyDown && !over)
		{
			gameOver.text = "";
			hintVisible = false;
		}

		if (Input.GetButtonDown("Reset"))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public void AddScore(int add=1)
	{
		score += add;
		if (score > bestScore)
		{
			bestScore = score;
		}
		UpdateText();
	}

	public void AddPrey(int add=1)
	{
		prey += add;
		UpdateText();

		if (prey == 0)
		{
			GameOver("You wiped out all our prey and will starve to death!");
		}
	}

	private void UpdateText()
	{
		text.text = "prey left: " + prey + "\nscore: " + score + "\nbest: " + bestScore;
	}

	public void GameOver(string message)
	{
		gameOver.text = "GAME OVER\n" + message + "\npress R to restart";
		over = true;
	}
}
