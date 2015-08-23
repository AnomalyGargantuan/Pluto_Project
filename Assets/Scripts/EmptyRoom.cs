using UnityEngine;
using System.Collections;

public class EmptyRoom : MonoBehaviour 
{
	public Vector2 gridPos;
	Renderer renderer;
	public bool isAvailable = true;
	public bool selectable = false;

	void Start()
	{
		renderer = this.GetComponent<Renderer>();
		renderer.enabled = false;
	}
}
