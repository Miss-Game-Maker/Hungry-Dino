using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    private float speed;
    [HideInInspector]
    public float timeElapsed;
    private float timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.5f;
        timeRemaining = speed;
        timeElapsed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = speed / timeElapsed;
            int randEnemy = Random.Range(0, (1 * 70 + 1 * 28 + 1 * 2));
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);
            int enemy = 0;
            if (randEnemy < 70)
            {
                enemy = 0;
            }
            else if (randEnemy < 98)
            {
                enemy = 1;
            }
            else if (randEnemy < 100)
            {
                enemy = 2;
            }

            Instantiate(enemyPrefabs[enemy], spawnPoints[randSpawnPoint].position, transform.rotation, GameObject.FindGameObjectWithTag("Enemy").transform);
        }

        timeElapsed += (Time.deltaTime / 60);
    }
}
