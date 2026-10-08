using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    InputAction moveAction;
    Vector2 moveVector;
    Rigidbody2D rb;
    bool isMove = true;
    [SerializeField] float moveSpeed = 5f;
    AudioManager audioManager;
    [SerializeField] CircleCollider2D tyreCollider;
    void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    
    }

    // Update is called once per frame
    void Update()
    { 
        if(isMove)
        {
            PlayerControl();
        }
    }
    public void DisableControls()
    {
        isMove = false;
    }
    public void EnableControls()
    {
        isMove = true;
    }
    void PlayerControl()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        if (moveVector.x > 0)
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        }
        if(!tyreCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (moveVector.x < 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x * 0.9f * Time.deltaTime, rb.linearVelocity.y);
        }
    }
    
}
