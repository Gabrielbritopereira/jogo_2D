using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Fasi1");
    }

    // Update is called once per frame
   public void QuitGame ()
    {
        Application.Quit();
    }
}
