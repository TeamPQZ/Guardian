using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private bool IsJumping;
    
    public float Speed;
    public float MaxVertSpeed;

    public float JumpForce;
    public int JumpsLeft;

    public Rigidbody2D rb;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        JumpsLeft = 1;
        IsJumping = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal"),0) * Speed * Time.deltaTime);
        if(Input.GetAxis("Vertical") > 0 && JumpsLeft > 0)
        {
            JumpsLeft--;
            IsJumping = true;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rb.AddForce(new Vector2(0, Input.GetAxis("Vertical")) * Speed * Time.deltaTime);
        }
        else
        {
            return;
        }
	}

    void FixedUpdate()
    {
        if (IsJumping == true)
        {
            rb.AddForce(Vector2.up * JumpForce * Time.deltaTime);
            IsJumping = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        JumpsLeft = 1;
    }
}
