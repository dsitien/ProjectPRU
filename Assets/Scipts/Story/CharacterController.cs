using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Giả sử chúng ta sử dụng phím mũi tên để di chuyển
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.Play("Run");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.Play("Run");
        }
        else
        {
            animator.Play("Idle");
        }
    }
}