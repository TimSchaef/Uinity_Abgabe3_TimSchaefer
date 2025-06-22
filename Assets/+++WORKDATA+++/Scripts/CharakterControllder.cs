using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;

public class CharakterControllderSide : MonoBehaviour
{
    // Defines the Charakter Speed and Jumpforce( can also be adjusten in the Inspector)
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpForce = 10f;
    private float direction = 0f;

    private Rigidbody2D rb;
// Defines The GroundLayer for the GroundCheck 
    [Header("GroundCheck")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform transformfromGroundCheck;
//Defines The Coin Manager and UIManager
    [Header("Manager")]
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private UIManager uiManager;
//Defines the countdown text
    [Header("Countdown")]
    [SerializeField] private TextMeshProUGUI countdownText;

    private bool canMove = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(StartCountdown());
    }
// basic Movement, let the Charakter Move left, Right and Jump
    void Update()
    {
        if (canMove)
        {
            direction = 0f;

            if (Keyboard.current.aKey.isPressed)
                direction = -1;
            if (Keyboard.current.dKey.isPressed)
                direction = 1;
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
                Jump();

            rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
        }
    }
// lets the Charakter Jump when groundCheck is active
    void Jump()
    {
        if (Physics2D.OverlapCircle(transformfromGroundCheck.position, 0.1f, groundLayer))
        {
            rb.linearVelocity = new Vector2(0, jumpForce);
        }
    }
// Objekts with Collider, that react with the Charakter(Coin, Diamond and Obstecal that kills the Player)
    private void OnTriggerEnter2D(Collider2D other)
    {
        // defines the Coin that gives +1
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinManager.AddCoin(1); 
        }
// defines the Diamond that give +5
        if (other.CompareTag("Diamond"))
        {
            Destroy(other.gameObject);
            coinManager.AddCoin(5); 
        }
// Defines the Obstical that kills the player
        if (other.CompareTag("Obstacle"))
        {
            uiManager.ShowPanelLost();
            rb.linearVelocity = Vector2.zero;
            canMove = false;
        }
    }
// Countdown that counts down from three to GO !, then the Player can Move 
    private IEnumerator StartCountdown()
    {
        int count = 3;

        while (count > 0)
        {
            countdownText.text = count.ToString();
            yield return new WaitForSeconds(1f);
            count--;
        }
// when the Go! dissapears then the player can Move
        countdownText.text = "Go!";
        yield return new WaitForSeconds(1f);
        countdownText.text = "";
        canMove = true;
    }
}
