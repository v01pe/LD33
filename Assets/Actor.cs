using UnityEngine;
using System.Collections;

public abstract class Actor : MonoBehaviour
{
	public Field field;
	public Color color;
	public float lifeTime = 2f;
	public float lifeVariation = 0f;
	public float size = 10f;

	protected Vector2 position;
	// Use this for initialization
	virtual public void Start()
	{
		if (field == null)
		{
			enabled = false;
		}
	}
	
	// Update is called once per frame
	virtual public void FixedUpdate ()
	{
		field.PaintDot(color, position, size, lifeTime, lifeVariation);
	}
}
