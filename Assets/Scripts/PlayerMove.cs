using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour {
	[SerializeField] private float m_MaxSpeed = 10f; 											//Our Speed is RAMMMMMING SPEED
	[SerializeField] private float m_JumpForce = 400f;											//You jump this high when I tell you too
	[SerializeField] private bool m_AirControl = false;											//Can we make the swish swish in the air well we move ourselves //Our movement in air enabler
	[SerializeField] private LayerMask m_WhatIsGround;											//What is ground? baby, don't stomp me.

	private bool m_Grounded;																	//Our we down to earth?
	private Rigidbody2D m_Rigidbody2D;															//What ridgidbody our we
	private bool m_FacingRight = true;															//What if we are facing left? keep track of that
	private float k_GroundedRadius = 2f;														//Look How far?
	private Animator m_Anim; 																	//The strings that play me like a fiddle
	private Transform m_GroundCheck;															//Where should ground be?
	private Vector3 lastCheckPioint;
	public InventoryAndEffects myInventoryAndEffects;

	private void Awake()
	{
		m_Anim = GetComponent<Animator>();														//The puppet master, write his name down
		m_Rigidbody2D = GetComponent<Rigidbody2D>();											//What Ridgid our we? Ok write that down
		m_GroundCheck = transform.Find("GroundCheck");											//We cheack for ground somewhere and we write this down too.
		lastCheckPioint = transform.position;
		myInventoryAndEffects = GetComponent<InventoryAndEffects> ();

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Danger") {
			transform.position = lastCheckPioint;
			GameObject[] myGameObj = GameObject.FindGameObjectsWithTag ("RedDrool");
			for (int i = 0; i < myGameObj.Length; i++) {
				myGameObj [i].GetComponent<Pickup> ().ResetMe ();								//FIX_ME replace this with A brodcast message and readers
			}
			myInventoryAndEffects.redDrool = 0;
		}
		if (other.tag == "RedDrool") {
			myInventoryAndEffects.redDrool++;
			other.gameObject.GetComponent<Pickup> ().HideMe ();
		}
			
	}

	void Update () {
		if (myInventoryAndEffects.redDrool != 0 && !m_Grounded && !m_Anim.GetBool("Ground") && Input.GetButtonDown("Jump")) {
			jump ();
			myInventoryAndEffects.redDrool--;
		}
		if (m_Grounded && m_Anim.GetBool("Ground") && Input.GetButtonDown ("Jump")) {
			jump ();
		}
	}

	void FixedUpdate () {
		m_Grounded = false;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
				m_Grounded = true;
		}
		m_Anim.SetBool("Ground", m_Grounded);
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		Move (h);
		m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
	}

	void jump () {
			m_Grounded = false;
			m_Anim.SetBool("Ground", false);
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
	}

	void Move (float h) {
		if (m_Grounded || m_AirControl) {														//Can we move in air our we on the ground?
			m_Anim.SetFloat("Speed", Mathf.Abs(h));												//Set us to run that fast
			m_Rigidbody2D.velocity = new Vector2(h*m_MaxSpeed, m_Rigidbody2D.velocity.y);		//Set the ridgidbody 2d velocity to max speed and value of h axis

			if (h > 0 && !m_FacingRight)														//Our going Right but facing left
			{
				Flip();																			//Fix that and Flip us
			}
			else if (h < 0 && m_FacingRight)													//Our going Left but facing Right
			{
				Flip();																			//Fix that and Flip us
			}

		}
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
