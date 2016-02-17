using UnityEngine;
using System.Collections;

/**

Class used to control player
Author: Jonathan Lacombe

*/
public class Player : MonoBehaviour {

    public float m_MaxSpeed = 5f;
    public float m_Acceleration = 50f;
    public float m_JumpPower = 375f;

    private Rigidbody2D m_Rb2d;
    private Animator m_Anim;
    private float m_Speed;
    private bool m_IsGrounded;
    private float m_Horizontal;
    private bool m_ShouldJump;

    private Vector2 m_StartPos;

	//Initialization
	void Start()
    {
        m_Rb2d = GetComponent<Rigidbody2D>();
        m_Anim = GetComponent<Animator>();
        m_StartPos = transform.position;
	}
	
	//Handles input
	void Update()
    {
        m_Horizontal = Input.GetAxis("Horizontal");
        m_ShouldJump = Input.GetButton("Jump");

        //Restart
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = m_StartPos;
        }

        m_Anim.SetBool("Grounded", m_IsGrounded);
        m_Anim.SetFloat("Speed", Mathf.Abs(m_Speed));

        if (m_Horizontal>0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        } else if (m_Horizontal<0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

	}

    //Handles rigidbody movement
    void FixedUpdate()
    {
        if (m_ShouldJump && m_IsGrounded)
        {
            m_Rb2d.AddForce(new Vector2(0, m_JumpPower));
        }

        //m_Rb2d.AddForce(Vector2.right * (m_Acceleration * m_Horizontal));
        m_Rb2d.velocity = new Vector2(m_MaxSpeed*m_Horizontal,m_Rb2d.velocity.y);

        if (m_Rb2d.velocity.x > m_MaxSpeed)
        {
            m_Rb2d.velocity = new Vector2(m_MaxSpeed,m_Rb2d.velocity.y);
        } else if (m_Rb2d.velocity.x < -m_MaxSpeed)
        {
            m_Rb2d.velocity = new Vector2(-m_MaxSpeed, m_Rb2d.velocity.y);
        }

        m_Speed = m_Rb2d.velocity.x;
    }

    //Used by PlayerFeet
    public void SetGrounded(bool grounded)
    {
        m_IsGrounded = grounded;
    }

}
