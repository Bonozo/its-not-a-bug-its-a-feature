// This script UV scrolls a texture

using UnityEngine;
using System.Collections;

public class TextureScroller : MonoBehaviour
{
	public Vector2 scrollSpeed = Vector2.zero;

	private Vector2 scroller = Vector2.zero;
    private Renderer textureRenderer;      //  Caching is still slightly faster

    private void Awake() 
    {
        textureRenderer = gameObject.GetComponent<Renderer>();
    }

	void Update ()
	{
		// scroll
        textureRenderer.material.SetTextureOffset("_MainTex", scroller);

		// step
		scroller = scroller + scrollSpeed * Time.deltaTime;
	}
}
