using UnityEngine;
using System.Collections;

public class Robot : Actor
{
	public float speed;
	public float keepDirTime;
	
	private Vector2 direction;
	private float changeDirTime;
	private float keepDirVariation;
	
	static private uint sideIndex = 0;

	// Use this for initialization
	override public void Start()
	{
		base.Start();

		size = 3;
		color = Color.black;
		speed = 35f;
		lifeTime = 8f;
		keepDirTime = 3.5f;
		keepDirVariation = 0.5f;

		CalcNewDirTime();

		Vector2 fieldSize = field.dimensions;

		switch (sideIndex)
		{
		case 0:
			position = new Vector2(fieldSize.x/2, 0);
			direction = Vector2.up;
			break;
		case 1:
			position = new Vector2(fieldSize.x/2, field.dimensions.y);
			direction = Vector2.down;
			break;
		case 2:
			position = new Vector2(0, field.dimensions.y/2);
			direction = Vector2.right;
			break;
		case 3:
			position = new Vector2(fieldSize.x, field.dimensions.y/2);
			direction = Vector2.left;
			break;
		}
		sideIndex = (sideIndex+1) % 4;
	}
	
	// Update is called once per frame
	override public void FixedUpdate ()
	{
		if (Time.time > changeDirTime)
		{
			direction = new Vector2(direction.y, direction.x) * ((Random.value > 0.5) ? 1 : -1);
			CalcNewDirTime();
		}
		position += direction * speed * Time.deltaTime;

		Vector2 fieldSize = field.dimensions;
		if (position.x < 0 || position.y < 0 || position.x > fieldSize.x || position.y > fieldSize.y)
		{
			direction *= -1;
		}



		base.FixedUpdate();
	}

	private void CalcNewDirTime()
	{
		changeDirTime = Time.time + keepDirTime + Random.value * keepDirVariation - keepDirVariation/2;
	}
}
