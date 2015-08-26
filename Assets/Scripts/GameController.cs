using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour 
{
	public static GameController instance;

	public GameObject kitchenPrefab;
	public GameObject PowerPrefab;
	public GameObject WaterPrefab;
	public GameObject entrancePrefab;

	public GameObject placeHoldPrefab;

	public Text foodText;
	public Text waterText;
	public Text powerText;

	private Renderer roomRenderer;
	private float singleRoomWidth;
	private float singleRoomHeight;

	private ResourceHandler food;
	private ResourceHandler water;
	private ResourceHandler power;

	List<List<RoomHandler>> rooms = new List<List<RoomHandler>>();
	public List<List<GameObject>> grid = new List<List<GameObject>>();

	void Start()
	{
		instance = this;

		roomRenderer = kitchenPrefab.GetComponent<Renderer>();

		initResources();
		setSizes();
		createGrid();

		initializeRooms();

		//addRoom(kitchenPrefab);
		//addRoom(PowerPrefab);
		//addRoom(WaterPrefab);
	}

	//Set the sizes of the rooms to calculate the world Position
	void setSizes()
	{
		singleRoomWidth = roomRenderer.bounds.size.x;
		singleRoomHeight = roomRenderer.bounds.size.y;
	}

	//Initialize the resources of the vault
	void initResources()
	{
		food = new ResourceHandler(foodText, 100, 100, "Comida");
		water = new ResourceHandler(waterText, 100, 100, "Agua");
		power = new ResourceHandler(powerText, 100, 100, "Energia");
	}

	//Create the grid;
	void createGrid()
	{
		GameObject hexGridGO = new GameObject("Grid");

		for(int y = 0; y < 2; y++)
		{
			List<GameObject> row = new List<GameObject>();
			for( int x = 0; x < 9; x++)
			{
				Vector2 gridPos = new Vector2(x, y);

				GameObject emptyRoom = ((GameObject) Instantiate(placeHoldPrefab));

				emptyRoom.name = "Room " + gridPos;
				emptyRoom.transform.position = calcWorldPos(gridPos);
				emptyRoom.transform.parent = hexGridGO.transform;
				emptyRoom.GetComponent<EmptyRoom>().gridPos = gridPos;
				emptyRoom.GetComponent<EmptyRoom>().parent = emptyRoom;

				row.Add(emptyRoom);
			}
			grid.Add(row);
		}
	}

	//Calcula a posiçao que a sala sera colocada no mundo
	Vector3 calcWorldPos(Vector2 gridPos)
	{
		float x = gridPos.x * (-singleRoomWidth);
		float y = gridPos.y * (-singleRoomHeight);
		
		return new Vector3(x, y, 0);
	}

	//Rotina que adiciona sala ao mapa
	public void addRoom(GameObject roomPrefab, GameObject grid)
	{
		Vector2 gridPos = grid.GetComponent<EmptyRoom>().gridPos;
		grid.GetComponent<EmptyRoom>().isAvailable = false;
		
		GameObject room = ((GameObject) Instantiate(roomPrefab));
		room.transform.position = calcWorldPos(gridPos);
		RoomHandler handler = room.GetComponent<RoomHandler>();
		handler.gridPos = gridPos;

		grid = room;

		//TODO Alterar como trabalha com o mapa
		//room.Add(handler);
	}

	void initializeRooms()
	{
		//Set first 2 spaces unavailable (X,Y)
		grid[0][0].GetComponent<EmptyRoom>().isAvailable = false;
		grid[0][1].GetComponent<EmptyRoom>().isAvailable = false;

		//GameObject room = Instantiate(entrancePrefab);

		//Debug.Log(grid[0][2].GetComponent<EmptyRoom>().gridPos);
		addRoom(entrancePrefab, grid[0][2]);
		addRoom(entrancePrefab, grid[1][2]);
	}


	//Nao sei se sera usado
	Vector3 getInitPos()
	{
		return new Vector3();
	}

	//Talvez nao sera necessario
	Vector2 calcGridPos()
	{
		return new Vector2();
	}

	public void UnmarkSelectable()
	{
		foreach(List<GameObject> row in grid)
		{
			foreach(GameObject cell in row)
			{
				cell.GetComponent<EmptyRoom>().selectable = false;
				cell.GetComponent<EmptyRoom>().renderer.enabled = false;
			}

		}
	}
}