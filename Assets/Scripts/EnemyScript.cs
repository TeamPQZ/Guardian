using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    public Rigidbody2D rb;
    public BoxCollider2D bc;
    private Vector2 Target;
    private GameObject GreenObject;
    public float Speed;
    private Vector2 HitSpot;
    private Vector2 DeadDirection;


	// Use this for initialization
	void Start () {
        GreenObject = GameObject.FindGameObjectWithTag("Target");
        Target = new Vector2(GreenObject.transform.position.x, GreenObject.transform.position.y);
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        rb.gravityScale = 0;
        rb.AddForce(new Vector2(Target.x - transform.position.x, Target.y - transform.position.y) * Speed);
	}

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            HitSpot = new Vector2(other.transform.position.x, other.transform.position.y);
            DeadDirection = other.rigidbody.velocity;
            Dead();
        }
        else
        {
            return;
        }
    }

    public void Dead()
    {
        GreenObject.GetComponent<GreenScript>().Points++;
        bc.enabled = false;
        rb.gravityScale = 1;
        rb.AddForce(DeadDirection * Speed);
        StartCoroutine(Deader());
    }

    public IEnumerator Deader()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
