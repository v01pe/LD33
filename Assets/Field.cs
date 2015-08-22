using UnityEngine;
using System.Collections;

public class Field : MonoBehaviour
{
	public int height = 480;

	Texture2D texture;
	private Color[] pixels;
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
		for (int i = 0; i < pixels.Length; i++)
		{
			pixels[i] = Color.white;
		}
		texture.SetPixels(pixels);
		texture.Apply(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		texture.SetPixels(pixels);
		texture.Apply(false);
	}
	
	public void PaintDot(Color color, Vector2 position, float size)
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
				}
			}
		}
	}
}
