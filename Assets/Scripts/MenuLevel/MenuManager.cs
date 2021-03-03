using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject startBtn, exitBtn;


    // Start is called before the first frame update
    void Start()
    {
        FadeOut();
    }

    void FadeOut()
    {
        startBtn.GetComponent<CanvasGroup>().DOFade(1, 0.8f);
        exitBtn.GetComponent<CanvasGroup>().DOFade(1, 0.8f).SetDelay(0.5f);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameLevel");
    }
}
