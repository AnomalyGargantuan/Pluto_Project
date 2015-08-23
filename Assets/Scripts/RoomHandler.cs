using UnityEngine;
using System.Collections;

public class RoomHandler : MonoBehaviour {

	int roomLevel = 1;
	int roomSize = 1;
	int maxSize;

	public int powerCost;
	public Vector2 gridPos;

	void upgrade()
	{
		roomLevel += 1;
	}
}
