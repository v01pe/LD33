using UnityEngine;
using System.Collections;

public class Monster : Actor
{
	public float speed = 10f;
	
	// Use this for initialization
	override public void Start ()
	{
		base.Start();

		position = field.dimensions/2;
	}
	
	// Update is called once per frame
	override public void FixedUpdate ()
	{
		Vector2 velocity = Vector2.one * speed;

		velocity.x *= Input.GetAxis("Horizontal");
		velocity.y *= Input.GetAxis("Vertical");

		position += velocity * Time.deltaTime;

		base.FixedUpdate();
	}

	override public Type type
	{
		get { return Type.MONSTER; }
	}
}
