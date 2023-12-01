using UnityEditor;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    public float speed;
    private float horizontalMove;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("isDie");
        }
                
    }
}
