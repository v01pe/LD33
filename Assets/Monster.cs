using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour
{
	public Field field;
	public float size = 10f;
	public float speed = 10f;

	private Vector2 position;
	// Use this for initialization
	void Start ()
	{
		if (field == null)
		{
			enabled = false;
		}
		else
		{
			position = Vector2.one * 300;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector2 velocity = Vector2.one * speed;

		velocity.x *= Input.GetAxis("Horizontal");
		velocity.y *= Input.GetAxis("Vertical");

		position += velocity * Time.deltaTime;

		field.PaintDot(Color.green, position, size);
	}
}
