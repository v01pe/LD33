using UnityEngine;
using System.Collections;

public class Field : MonoBehaviour
{
	public Color neutralColor = Color.white;
	public int height = 480;

	Texture2D texture;
	private Color[] pixels;
	private float[] lifeTimes;
	private int width;

	// Use this for initialization
	void Start ()
	{
		Camera camera = Camera.main;
		float camHeight = camera.orthographicSize * 2f;
//		float camWidth = height * camera.aspect;

		width = (int)(height * camera.aspect);
		float texelRatio = (float)height / camHeight;

		texture = new Texture2D(width, height, TextureFormat.ARGB32, false);
		
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = Sprite.Create(texture, new Rect(0,0,width,height), new Vector2(0.5f,0.5f), texelRatio);

		pixels = texture.GetPixels();
		lifeTimes = new float[pixels.Length];
		for (int i = 0; i < pixels.Length; i++)
		{
			pixels[i] = neutralColor;
			lifeTimes[i] = 0f;
		}
		texture.SetPixels(pixels);
		texture.Apply(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		for (int i = 0; i < pixels.Length; i++)
		{
			lifeTimes[i] -= Time.deltaTime;
			pixels[i] = (lifeTimes[i] <= 0) ? neutralColor : pixels[i];
		}

		texture.SetPixels(pixels);
		texture.Apply(false);
	}

	public Vector2 dimensions
	{
		get { return new Vector2(height * Camera.main.aspect, height); }
	}
	
	public void PaintDot(Color color, Vector2 position, float size, float lifeTime, float lifeVariation=0f)
	{
		float sqrRadius = size * size / 4;
		Vector2 extents = Vector2.one * size;
		
		Rect rect = new Rect(position - extents/2, extents);
		if (rect.xMin < 0) rect.xMin = 0;
		if (rect.yMin < 0) rect.yMin = 0;
		if (rect.xMax > width-1) rect.xMax = width-1;
		if (rect.yMax > height-1) rect.yMax = height-1;

		for (int x=(int)rect.xMin; x<=rect.xMax; x++)
		{
			for (int y=(int)rect.yMin; y<=rect.yMax; y++)
			{
				float dX = position.x - x;
				float dY = position.y - y;
				if (dX*dX + dY*dY <= sqrRadius)
				{
					int i = x + y*width;
					pixels[i] = color;
					lifeTimes[i] = lifeTime + Random.value * lifeVariation - lifeVariation/2;
				}
			}
		}
	}
}
