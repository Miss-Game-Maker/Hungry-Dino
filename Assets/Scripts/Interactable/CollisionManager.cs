using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 5;
    private float timeElapsed;
    private float yVelocity;

    private RandomSpawner spawner;
    private GameObject respawnGameObject;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 5;
        respawnGameObject = GameObject.FindGameObjectWithTag("Respawn");
        spawner = respawnGameObject.GetComponent<RandomSpawner>();
        timeElapsed = spawner.timeElapsed;
    }

    // Update is called once per frame
    void Update()
    {
        yVelocity = -speed * timeElapsed;
        rb.velocity = new UnityEngine.Vector2(0, yVelocity);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Finish")
        {
            Destroy(this.gameObject);
        }
    }
}