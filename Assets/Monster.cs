using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour
{
	public Field field;
	public float size = 10f;

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
		field.PaintDot(Color.green, position, size);
	}
}
