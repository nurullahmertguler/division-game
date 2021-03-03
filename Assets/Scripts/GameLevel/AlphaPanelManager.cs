using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AlphaPanelManager : MonoBehaviour
{

    public GameObject AlphaPanel;

    // Start is called before the first frame update
    void Start()
    {
        AlphaPanel.GetComponent<CanvasGroup>().DOFade(0, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
