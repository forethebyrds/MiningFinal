using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private bool recentlySpawnedGold = false;

	public GameObject OreCube;
	public GameObject bronzePrefabCube;
	public GameObject silverPrefabCube;
	public GameObject goldPrefabCube;

	public static int bronzePoints = 1;
	public static int silverPoints = 10;
	public static int goldPoints = 100;

	public static int score = 0;

	public static int bronzeCount = 0;
	public static int silverCount = 0;
	public static int goldCount = 0;


	OreType myType = OreType.Bronze;

	float createBronzeTime = 3f;
	float spawnSilverTime = 12.0f;
	float stopSpawningTime = 6.0f;
	float timeToAct = 0.0f;
	float spawnTime = 3.0f;
	

	
	// Use this for initialization
	void Start () {
		
		timeToAct += createBronzeTime;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Time.time >= timeToAct) {
			timeToAct += spawnTime;
		
			// Check to spawn gold first, since it's highest priority
			if (bronzeCount == 2 && silverCount == 2 && recentlySpawnedGold == false) {
				Instantiate(goldPrefabCube,
				            new Vector3(Random.Range(-9f, 9f), Random.Range(-3f, 5f), 0),
				            Quaternion.identity);
				goldCount++;
				recentlySpawnedGold = true;
			}
			else if (bronzeCount < 4) {
				Instantiate(bronzePrefabCube,
				            new Vector3(Random.Range(-9f, 9f), Random.Range(-3f, 5f), 0),
				            Quaternion.identity);
				bronzeCount++;
				recentlySpawnedGold = false;
			}
			else if (bronzeCount >= 4) {
				Instantiate(silverPrefabCube,
				            new Vector3(Random.Range(-9f, 9f), Random.Range(-3f, 5f), 0),
				            Quaternion.identity);
				silverCount++;
				recentlySpawnedGold = false;
			}
			
			timeToAct += createBronzeTime;
			print ("SPAWN A CUBE!!");
			print (Time.time);
			timeToAct = 0f;
		}
	}
}

