using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    public float jumpSpeed = 8f;
    Rigidbody2D rig;
    float run;
    private void Awake()
    {
        rig= GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        run = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            
        }
        if (Input.GetButton("Jump") && isTouchingGround)
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpSpeed);
        }
    }
    private void FixedUpdate()
    {
        
            rig.velocity  = new Vector2(rig.velocity.x * 0.95f,rig.velocity.y);
        
        rig.AddForce(new Vector2(run * 250 * 25,0));
    }
}
