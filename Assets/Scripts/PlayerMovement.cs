using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public float kecepatan = 5f;
    private Vector2 arahGerak;
    private Rigidbody2D rigidbody;
    InputAction moveAction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (moveAction != null)
        {
            Vector2 moveValue = moveAction.ReadValue<Vector2>();
            arahGerak = moveValue.normalized;
            rigidbody.linearVelocity = arahGerak * kecepatan;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            GameManager gameManager = FindAnyObjectByType<GameManager>();
            if (gameManager!=null)
            {
                gameManager.AmbilCoin();
            }
            Destroy(other.gameObject);
        }
    }
}
