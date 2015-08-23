using UnityEngine;
using System.Collections;

public abstract class Actor : MonoBehaviour
{
	public enum Type
	{
		NONE = 0,
		MONSTER,
		ROBOT,
		PREY
	};
	
	public Color color;
	public float lifeTime = 2f;
	public float lifeVariation = 0f;
	public float size = 10f;

	protected Field field;
	protected Vector2 position;

	// Use this for initialization
	virtual public void Start()
	{
		field = FindObjectOfType<Field>();
	}
	
	// Update is called once per frame
	virtual public void FixedUpdate ()
	{
		field.PaintDot(type, color, position, size, lifeTime, lifeVariation);
	}

	abstract public Type type { get; }
}
