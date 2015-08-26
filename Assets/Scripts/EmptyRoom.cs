using UnityEngine;
using System.Collections;

public class EmptyRoom : MonoBehaviour 
{
	public Vector2 gridPos;
	public bool isAvailable = true;
	public bool selectable = false;
	public GameObject parent;

	public Renderer renderer;

	void Start()
	{
		renderer = this.GetComponent<Renderer>();
		renderer.enabled = false;
	}

	public void makeSelectable()
	{
		if(this.isAvailable)
		{
			renderer.enabled = true;
			selectable = true;
		}
	}

	void OnMouseEnter() 
	{
		renderer.material.color = Color.gray;
	}

	void OnMouseExit()
	{
		renderer.material.color = Color.black;
	}

	void OnMouseUp()
	{
		if(this.selectable)
		{
			GameController gc = GameController.instance;
			GameObject room = gc.kitchenPrefab;

			gc.addRoom(room, this.parent);
			isAvailable = false;
			//selectable = false;
			renderer.enabled = false;

			gc.UnmarkSelectable();
		}
	}
}
