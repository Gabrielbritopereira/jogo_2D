using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneManager.LoadScene("Fasi1");
    }

    // Update is called once per frame
    void Update()
    {
        Application.Quit();
    }
}
