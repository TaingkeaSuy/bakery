using UnityEngine;
using UnityEngine.InputSystem;

public class playermovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        UpdateAnimation();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Run()
    {
        myRigidbody.linearVelocity = new Vector2(moveInput.x * 5f, myRigidbody.linearVelocity.y);
    }

    void UpdateAnimation()
    {
        bool isWalking = Mathf.Abs(moveInput.x) > 0.01f;
        myAnimator.SetBool("isWalking", isWalking);

        // Flip the player left or right
        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // face right
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // face left
        }
    }
}
