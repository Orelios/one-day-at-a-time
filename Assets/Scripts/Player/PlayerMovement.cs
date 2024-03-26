using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Singleton<PlayerMovement>
{
    [SerializeField] private float speed;
    [SerializeField] private float groundDistance;

    [SerializeField] private LayerMask groundLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;
    public Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>();
    }
    void Update()
    {
        CheckGroundHeight(); 
        MovePlayer();
        EnsurePlayerNotBelowGround();
    }
    private void CheckGroundHeight()
    {
        RaycastHit hit;
        Vector3 castPosition = transform.position;
        castPosition.y += 1;

        if (Physics.Raycast(castPosition, -transform.up, out hit, Mathf.Infinity, groundLayer))
        {
            if (hit.collider != null)
            {
                Vector3 movePosition = transform.position;
                movePosition.y = hit.point.y + groundDistance;
                transform.position = movePosition;
            }
        }
    }
    private void MovePlayer()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 movedirection = new Vector3(x, 0, y);
        gameObject.GetComponent<Rigidbody>().velocity = movedirection.normalized * speed;
        if(x !=0 && x < 0)
        {
            sr.flipX = true;
        }
        else if (x != 0 && x > 0)
        {
            sr.flipX = false;
        }
        animator.SetFloat("xVelocity", rb.velocity.magnitude);
        if (movedirection != Vector3.zero)
        {
            gameObject.transform.forward = movedirection;
            gameObject.transform.GetChild(0).transform.rotation = Quaternion.Euler(0f, 0f, 0f); 
        }
    }

    private void EnsurePlayerNotBelowGround()
    {
        if (transform.position.y < groundDistance + 0.1f)
        {
            transform.position = new Vector3(transform.position.x, groundDistance + 0.1f, transform.position.z);
        }
    }
}
