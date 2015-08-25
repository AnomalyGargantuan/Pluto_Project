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
					addRoom();
					Debug.Log("BAM!"); 
				}
		);
	}

	void addRoom()
	{
		GameController controller = GameController.instance;

		List<List<GameObject>> grid = controller.grid;

		//Primeiro vem a coluna
		foreach(List<GameObject> Row in grid)
		{
			for(int x = 0; x < Row.Count; x++)
			{
				bool prevAvailable = false;
				bool nextAvailable = false;
				GameObject cell = Row[x];

				if(x != 0)
				{
					prevAvailable = ! Row[x-1].GetComponent<EmptyRoom>().isAvailable;
				}

				if(x < Row.Count-1)
				{
					nextAvailable = ! Row[x+1].GetComponent<EmptyRoom>().isAvailable;
				}

				if(prevAvailable || nextAvailable)
				{
					Row[x].GetComponent<EmptyRoom>().makeSelectable();
				}
			}
		}
	}
}
