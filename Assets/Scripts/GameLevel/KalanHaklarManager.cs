using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalanHaklarManager : MonoBehaviour
{

    public GameObject kalp1, kalp2, kalp3;
   

    public void KalanHaklariKontrolEt(int kalanhak)
    {
        switch(kalanhak)
        {
            case 3:
                kalp1.SetActive(true);
                kalp2.SetActive(true);
                kalp3.SetActive(true);
                break;

            case 2:
                kalp1.SetActive(true);
                kalp2.SetActive(true);
                kalp3.SetActive(false);
                break;

            case 1:
                kalp1.SetActive(true);
                kalp2.SetActive(false);
                kalp3.SetActive(false);
                break;
            case 0:
                kalp1.SetActive(false);
                kalp2.SetActive(false);
                kalp3.SetActive(false);
                break;
        }
    }
}
