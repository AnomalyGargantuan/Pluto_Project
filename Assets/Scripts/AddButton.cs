using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AddButton : MonoBehaviour 
{
	[SerializeField] private Button MyButton = null;

	void Start() 
	{ 
		MyButton.onClick.AddListener
		(
			() => 
				{
				//Codigo aqui!
					Debug.Log("BAM!"); 
				}
		);
	}

	void addRoom()
	{
		GameController controller = GameController.instance;

		List<List<GameObject>> grid = controller.grid;

		foreach(List<GameObject> Row in grid)
		{

		}
	}
}
