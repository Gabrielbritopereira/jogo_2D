using UnityEngine;

using UnityEngine;

public class Inimigo : MonoBehaviour
{
    // ESSAS SÃO AS DUAS VARIÁVEIS PÚBLICAS QUE VÃO APARECER NA UNITY:
    public Transform pontoA;
    public Transform pontoB;

    public float velocidade = 2f;
    private Transform alvoAtual;

    void Start()
    {
        // Começa andando em direção ao Ponto A
        if (pontoA != null)
        {
            alvoAtual = pontoA;
        }
    }

    void Update()
    {
        // Segurança: se você esquecer de colocar os pontos na Unity, o código não quebra
        if (pontoA == null || pontoB == null) return;

        // Move o inimigo em direção ao alvo atual
        transform.position = Vector2.MoveTowards(transform.position, alvoAtual.position, velocidade * Time.deltaTime);

        // Verifica se o inimigo chegou muito perto do alvo atual
        if (Vector2.Distance(transform.position, alvoAtual.position) < 0.1f)
        {
            // Alterna o alvo e vira o visual do inimigo
            if (alvoAtual == pontoA)
            {
                alvoAtual = pontoB;
                VirarInimigo(true); // Vira para o Ponto B
            }
            else
            {
                alvoAtual = pontoA;
                VirarInimigo(false); // Vira para o Ponto A
            }
        }
    }

    void VirarInimigo(bool paraEsquerda)
    {
        Vector3 escala = transform.localScale;

        // Ajusta a escala X para o sprite olhar para o lado certo
        if (paraEsquerda)
        {
            escala.x = -Mathf.Abs(escala.x);
        }
        else
        {
            escala.x = Mathf.Abs(escala.x);
        }

        transform.localScale = escala;
    }
}

