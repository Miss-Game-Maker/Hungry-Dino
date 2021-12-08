using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveInput;

    private UnityEngine.Vector3 origin;

    private Animator animator;

    public TextMeshProUGUI pointText;
    public TextMeshProUGUI highScoreText;
    private int pointCounter;
    [HideInInspector]
    public int highScoreCounter;
    private HeartManager healthCounter;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        origin = new UnityEngine.Vector3(transform.position.x, transform.position.y, transform.position.z);
        healthCounter = GetComponent<HeartManager>();
        pointCounter = 0;
        pointText.text = pointCounter.ToString();
        highScoreCounter = PlayerPrefs.GetInt("High Score");
        highScoreText.text = highScoreCounter.ToString();


    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new UnityEngine.Vector2(moveInput * 14, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Change animation from idle to moving and vice versa
        if (moveInput == 0)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }

        // Flipping character depending on whether you press right or left
        if (moveInput > 0)
        {
            transform.eulerAngles = new UnityEngine.Vector3(0, 0, 0);

        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new UnityEngine.Vector3(0, 180, 0);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pizza")
        {
            pointCounter += 1;
            pointText.text = pointCounter.ToString();
            if (pointCounter > highScoreCounter)
            {
                highScoreCounter = pointCounter;
                highScoreText.text = pointCounter.ToString();
            }
            AudioController.AudioPlayOnce((int)AudioType.EAT);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Slime")
        {
            healthCounter.Health -= 1;
            healthCounter.UpdateHealthUI();
            pointText.text = pointCounter.ToString();
            AudioController.AudioPlayOnce((int)AudioType.HIT);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Heart")
        {
            if (healthCounter.Health < 3)
            {
                healthCounter.Health += 1;
            }
            healthCounter.UpdateHealthUI();
            AudioController.AudioPlayOnce((int)AudioType.HEART);
            Destroy(col.gameObject);
        }
    }
}
