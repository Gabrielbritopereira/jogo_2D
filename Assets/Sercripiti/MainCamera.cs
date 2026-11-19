using UnityEngine;

public class MainCamera: MonoBehaviour
{
    public Transform alvo;
    public Vector3 distancia = new Vector3(0f, 0f, -10f);
    public bool movimentoSuave = true;
    public float velocidada = 5f;




    private void LateUpdate()
    {
        Vector3 posicaoDesejada = alvo.position + distancia;


        if (movimentoSuave) 
        {
            transform.position= Vector3.Lerp(transform.position, posicaoDesejada, velocidada*Time.deltaTime);
        }
        else
        {
            transform.position= posicaoDesejada;
        }
    }

}
