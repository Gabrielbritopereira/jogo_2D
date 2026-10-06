using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Player1 : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    public float distanciaDash = 5f;       // Distância total do dash
    public float duracaoDash = 0.2f;       // Tempo que o dash leva para completar
    public float tempoRecarga = 1f;        // Tempo de espera para usar de novo

    private bool estaEmDash = false;
    private bool podeFazerDash = true;

    private bool isGrounded = false;

    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //Vai resconhecer o mpvimento Horizontal

        rb.linearVelocity =new Vector2(moveHorizontal * speed, rb.linearVelocity.y); //Vai aplicar a velocida

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded )
        {
            rb.AddForce(new Vector2(0f, 7f), ForceMode2D.Impulse);// Vai aplicar o pulo
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            {
                // Se já estiver em dash, ignora os inputs de movimento normais
                if (estaEmDash) return;

                // Detecta o clique/botão (Shift Esquerdo como exemplo)
                if (Input.GetKeyDown(KeyCode.LeftShift) && podeFazerDash)
                {
                    // Pega a direção do movimento atual baseada no input (ex: WASD)
                    Vector3 direcao = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

                    // Se o jogador estiver parado, faz o dash para a frente do personagem
                    if (direcao == Vector3.zero)
                    {
                        direcao = transform.forward;
                    }

                    StartCoroutine(ExecutarDash(direcao));
                }
            }

            IEnumerator ExecutarDash(Vector3 direcao)
            {
                estaEmDash = true;
                podeFazerDash = false;

                Vector3 posicaoInicial = transform.position;
                Vector3 posicaoFinal = transform.position + direcao * distanciaDash;
                float tempoPassado = 0f;

                // Move o personagem suavemente frame a frame até o destino
                while (tempoPassado < duracaoDash)
                {
                    tempoPassado += Time.deltaTime;
                    float porcentagem = tempoPassado / duracaoDash;

                    // Interpola a posição linearmente entre o início e o fim
                    transform.position = Vector3.Lerp(posicaoInicial, posicaoFinal, porcentagem);

                    yield return null; // Espera o próximo frame
                }

                // Garante que o jogador termine exatamente na posição final
                transform.position = posicaoFinal;
                estaEmDash = false;

                // Espera o tempo de recarga (cooldown) antes de permitir outro dash
                yield return new WaitForSeconds(tempoRecarga);
                podeFazerDash = true;
            }
        }


     
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded =true;
        }

        if (collision.gameObject.CompareTag("Dano"))
        {
            SceneManager.LoadScene(0);
        }
    }
}


