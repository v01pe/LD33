using UnityEngine;
using System.Collections;

public class Field : MonoBehaviour
{
	public int height = 480;

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

		Texture2D texture = new Texture2D(width, height, TextureFormat.ARGB32, false);
		
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = Sprite.Create(texture, new Rect(0,0,width,height), new Vector2(0.5f,0.5f), texelRatio);

		pixels = texture.GetPixels();
		for (int i = 0; i < pixels.Length; i++)
		{
			pixels[i] = Color.green;
			pixels[i].a = 255;
		}
		texture.SetPixels(pixels);
		texture.Apply();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
}
