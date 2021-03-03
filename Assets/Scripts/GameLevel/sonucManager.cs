using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sonucManager : MonoBehaviour
{
    public void OyunaYenidenBasla()
    {
        SceneManager.LoadScene("GameLevel");
    }

    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("MenuLevel");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
