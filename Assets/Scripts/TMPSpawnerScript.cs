using UnityEngine;

public class TMPSpawnerScript : MonoBehaviour
{
    public GameObject tmp;
    public float spawnRate = 3; //Second per spawn
    private float timer = 0; //default timer is start from 0
    public float heightOffset = 1; //heightOffset for enemies spawn at random place based on vertical (y)
    void Start()
    {
        spawnTMP(); //spawn first enemies
    }
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
        spawnTMP();
        timer = 0;
        }
    }
    void spawnTMP()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(tmp, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint),0), transform.rotation);
    }
}
