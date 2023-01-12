using UnityEngine;
using System.Collections;

public class playerControllerScript : MonoBehaviour {


	//movement
	public float maxSpeed;
	public bool facingRight = true;
	public bool canMove = true;

	Rigidbody2D myRB;
	Animator myAnim;

	public SpriteRenderer[] charRenderer;
	public SpriteRenderer rightArm;
	public SpriteRenderer leftArm;

	public SpriteRenderer rightLeg;
	public SpriteRenderer leftLeg;

	//for jumping 
	bool grounded = false;
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;

	public ZoneDeathController zDC;

	[HideInInspector]
	public bool canSpikeNar = false;
	bool spikeNarComplete = false;

	[HideInInspector]
	public bool canElevNar = false;
	bool elevNarComplete = false;

    [HideInInspector]
	public bool canExNar = false;
	bool exNarComplete = false;

	[HideInInspector]
	public bool canDesNar = false;
	bool desComplete = false;

	[HideInInspector]
	public bool canPorNar = false;
	bool porComplete = false;

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpikeNar"))
        {
			if (!spikeNarComplete)
            {
				spikeNarComplete = true;
				canSpikeNar = true;
            }
        }

		if (collision.gameObject.CompareTag("ElevNar"))
		{
			if (!elevNarComplete)
			{
				elevNarComplete = true;
				canElevNar = true;
			}
		}

		if (collision.gameObject.CompareTag("ExNar"))
		{
			if (!exNarComplete)
			{
				exNarComplete = true;
				canExNar = true;
			}
		}

		if (collision.gameObject.CompareTag("DesNar"))
		{
			if (!desComplete)
			{
				desComplete = true;
				canDesNar = true;
			}
		}


		if (collision.gameObject.CompareTag("PorNar"))
		{
			if (!porComplete)
			{
				porComplete = true;
				canPorNar = true;
			}
		}
	}

    // Use this for initialization
    void Start () {
		myRB = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator>();
	}
	

	void Update(){

		if(canMove && grounded && Input.GetAxis("Jump")>0){
			myAnim.SetBool("isGrounded", false);
			myRB.velocity = new Vector2(myRB.velocity.x, 0f);
			myRB.AddForce(new Vector2(0,jumpHeight), ForceMode2D.Impulse);
			grounded=false;
		}

		//check if grounded
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
		myAnim.SetBool("isGrounded",grounded);

		//jumping code
		myAnim.SetFloat ("verticalVelocity", myRB.velocity.y);


		//running code
		float move = Input.GetAxis("Horizontal");

		if(canMove){
			if(move>0 && !facingRight) Flip ();
			else if (move < 0 && facingRight) Flip ();
	

			myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);
			myAnim.SetFloat ("moveVelocity", Mathf.Abs(move));
		}else{
			myRB.velocity = new Vector2(0, myRB.velocity.y);
			myAnim.SetFloat ("moveVelocity", 0);
		}
	}



	void Flip(){

			facingRight = !facingRight;

			foreach (SpriteRenderer value in charRenderer)
			{
				value.flipX = !value.flipX;
			}

			if (facingRight)
			{
				rightArm.sortingOrder = 100;
				leftArm.sortingOrder = 90;

				rightLeg.sortingOrder = 100;
				leftLeg.sortingOrder = 90;
			}
			else
			{
				rightArm.sortingOrder = 90;
				leftArm.sortingOrder = 100;

				rightLeg.sortingOrder = 90;
				leftLeg.sortingOrder = 100;
			}

	}

	public void toggleCanMoveTrue(){
		canMove = true;
	}

	public void toggleCanMoveFalse(){
		canMove = false;
	}

	public void increaseSpeed(){
		maxSpeed *= 2;
	}


	public void increaseSpeedFixed()
	{
		maxSpeed += 4;
	}

}
