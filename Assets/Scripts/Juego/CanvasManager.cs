using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public void Play()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); Para cuando tienes varios niveles
        SceneManager.LoadScene(1);

    }
    public void Exit()
    {
        Application.Quit();
    }
}
