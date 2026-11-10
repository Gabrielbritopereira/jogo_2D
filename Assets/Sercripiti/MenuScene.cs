using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScene : MonoBehaviour
{
    public GameObject painelPause;
    public GameObject panelGameOver;

    bool pausardo = false;
    bool jogoAcabou = false;




    void Start()
    {
        painelPause.SetActive(false);
        panelGameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input .GetKeyUp (KeyCode.Escape))
        {
            if(pausardo)
            {
                Continuar();
            }else
            {
                Pausar();
            }
        }
    }
    public void Pausar()
    {
        if(jogoAcabou ==false )
        {
            pausardo =true;
            painelPause.SetActive(true);
            Time.timeScale = 0f;
        }




    }
    public void Continuar()
    {
        pausardo =false;
        painelPause.SetActive(false);
        Time.timeScale = 1f;
    }
    public void MostrarGameOver()
    {
        jogoAcabou=true;
        panelGameOver.SetActive(true);
        Time.timeScale =0f;
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    

}
