using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;

    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //Vai resconhecer o mpvimento Horizontal

        rb.linearVelocity =new Vector2(moveHorizontal * speed, rb.linearVelocity.y); //Vai aplicar a velocida

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded )
        {
            rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);// 
        }

       
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision .gameObject .CompareTag ("Ground"))
        {
            isGrounded =true;
        }

    }
     void OnCollisionExit2D(Collision2D collision)
    {
       if(collision.gameObject .CompareTag ("Ground"))
        {
            isGrounded =false;
        }
    }
}
