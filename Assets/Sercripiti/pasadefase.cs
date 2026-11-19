using UnityEngine;
using UnityEngine.SceneManagement;
public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Portal"))
        {
            SceneManager.LoadScene("pântano");
        }
    }

}
