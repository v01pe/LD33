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

	private bool justBorn;

	// Use this for initialization
	virtual public void Start()
	{
		field = FindObjectOfType<Field>();
		justBorn = true;
	}
	
	// Update is called once per frame
	virtual public void FixedUpdate ()
	{
		if (justBorn || Alive())
		{
			Paint();
			justBorn = false;
		}
		else
		{
			Die();
		}
	}

	private void Paint()
	{
		field.PaintDot(type, color, position, size, lifeTime, lifeVariation);
	}

	virtual protected bool Alive()
	{
		return enabled && field.CheckLifeSigns(type, position, size * 1.5f);
	}

	virtual protected void Die()
	{
		enabled = false;
	}

	abstract public Type type { get; }
}
