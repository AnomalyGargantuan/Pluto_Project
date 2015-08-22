using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject kitchenPrefab;
	public GameObject PowerPrefab;
	public GameObject WaterPrefab;

	public Text foodText;
	public Text waterText;
	public Text powerText;

	private Renderer roomRenderer;
	private float singleRoomWidth;
	private float singleRoomHeight;

	private ResourceHandler food;
	private ResourceHandler water;
	private ResourceHandler power;

	void Start()
	{
		roomRenderer = kitchenPrefab.GetComponent<Renderer>();

		initResources();

		setSizes();
		addKitchen();
		addPower();
		addWater();
	}

	void setSizes()
	{
		singleRoomWidth = roomRenderer.bounds.size.x;
		singleRoomHeight = roomRenderer.bounds.size.y;
		Debug.Log(singleRoomWidth);
		Debug.Log(singleRoomHeight);
	}

	void initResources()
	{
		food = new ResourceHandler(foodText, 10, 100, "Comida");
		water = new ResourceHandler(waterText, 10, 100, "Agua");
		power = new ResourceHandler(powerText, 10, 100, "Energia");
	}

	Vector3 getInitPos()
	{
		return new Vector3();
	}

	Vector3 calcWorldPos(Vector2 gridPos)
	{
		float x = gridPos.x * (-singleRoomWidth);
		float y = gridPos.y * (-singleRoomHeight);

		return new Vector3(x, y, 0);
	}

	void addKitchen()
	{
		//Vector3 initPos = getInitPos();
		Vector2 gridPos = new Vector2(1,0);

		GameObject hex = ((GameObject) Instantiate(kitchenPrefab)); //.GetComponent<HexTile>();
		hex.transform.position = calcWorldPos(gridPos);
	}

	void addPower()
	{
		//Vector3 initPos = getInitPos();
		Vector2 gridPos = new Vector2(0,1);
		
		GameObject hex = ((GameObject) Instantiate(PowerPrefab)); //.GetComponent<HexTile>();
		hex.transform.position = calcWorldPos(gridPos);
	}

	void addWater()
	{
		//Vector3 initPos = getInitPos();
		Vector2 gridPos = new Vector2(2,0);
		
		GameObject hex = ((GameObject) Instantiate(WaterPrefab)); //.GetComponent<HexTile>();
		hex.transform.position = calcWorldPos(gridPos);
	}
}