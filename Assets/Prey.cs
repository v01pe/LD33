using UnityEngine;
using System.Collections;

public class Prey : Actor
{
	public float speed;
	public float keepDirTime;
	
	private Vector2 direction;
	private float dirVariation;
	private float changeDirTime;
	private float keepDirVariation;

	// Use this for initialization
	override public void Start()
	{
		base.Start();
		
		size = 2;
		color = Color.red;
		speed = 25f;
		lifeTime = 1f;
		keepDirTime = 0.2f;
		keepDirVariation = 0.1f;
		dirVariation = 100f;

		position = field.dimensions;
		position.x *= Random.value;
		position.y *= Random.value;
		direction = Vector2.left;
		Rotate(Random.value * 360);
	}
	
	// Update is called once per frame
	override public void FixedUpdate ()
	{
		if (Time.time > changeDirTime)
		{
			Rotate(Random.value * dirVariation - dirVariation/2);
			CalcNewDirTime();
		}

		position += direction * speed * Time.deltaTime;

		Vector2 fieldSize = field.dimensions;
		if (position.x < 0 && direction.x < 0 || position.x > fieldSize.x && direction.x > 0) direction.x *= -1;
		if (position.y < 0 && direction.y < 0 || position.y > fieldSize.y && direction.y > 0) direction.y *= -1;

		base.FixedUpdate();
	}

	private void Rotate(float degrees)
	{
		float radians = degrees * Mathf.Deg2Rad;

		direction = new Vector2(
			direction.x * Mathf.Cos(radians) - direction.y * Mathf.Sin(radians),
			direction.x * Mathf.Sin(radians) + direction.y * Mathf.Cos(radians)
		);
	}

	private void CalcNewDirTime()
	{
		changeDirTime = Time.time + keepDirTime + Random.value * keepDirVariation - keepDirVariation/2;
	}
}
