using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    //Canvas canvasPausa;
    void Start()
    {
        //canvasPausa = GetComponent<Canvas>();
    }
    void Update()
    {
        //if (Input.GetKeyDown(Escape))
        //{
        //    //canva
        //}
    }
    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Play()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); Para cuando tienes varios niveles
        SceneManager.LoadScene(1);

    }
    public void Continue() 
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
