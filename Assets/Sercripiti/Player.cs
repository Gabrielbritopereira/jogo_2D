using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //Vai resconhecer o mpvimento Horizontal

        rb.linearVelocity =new Vector2(moveHorizontal * speed, rb.linearVelocity.y); //Vai aplicar a velocida

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);// 
        }


    }
}
