using CommonComponents;
using UnityEngine;

public class HackingSpawner : Damagable
{
    public GameObject[] thingsToSpawn;
    public int timesLeftToSpawn;
    public Vector2 spawnPosition;
    public float spawnPosMaxY;
    public float spawnPosMinY;
    public float spawnPosMaxX;
    public float spawnPosMinX;
    public float spawnTimer;
    public float spawnTime;
    public bool isTimeTrial;

    void Start()
    {
        this.transform.position = spawnPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer <=0)
        {
            if (!isTimeTrial)
            {
                if (timesLeftToSpawn < 0)
                {
                    Instantiate(thingsToSpawn[Random.Range(0, thingsToSpawn.Length)], new Vector3(Random.Range(spawnPosMinX, spawnPosMaxX), Random.Range(spawnPosMinY, spawnPosMaxY), 0), Quaternion.identity);
                    spawnTimer = spawnTime;
                }
            }
            else
            {
                Instantiate(thingsToSpawn[Random.Range(0, thingsToSpawn.Length)], new Vector3(Random.Range(spawnPosMinX, spawnPosMaxX), Random.Range(spawnPosMinY, spawnPosMaxY), 0), Quaternion.identity);
                spawnTimer = spawnTime;
            }
            
            
        }
        spawnTimer -= Time.deltaTime;


    }
}
