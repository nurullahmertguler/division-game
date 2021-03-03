using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puanManager : MonoBehaviour
{

    private int toplamPuan;
    private int puanArtisi;

    public Text puanText;

    // Start is called before the first frame update
    void Start()
    {
        puanText.text = toplamPuan.ToString();
    }

    public void puaniArttir(string zorlukSeviyesi)
    {
        switch(zorlukSeviyesi)
        {
            case "kolay":
                puanArtisi = 5;
                break;

            case "orta":
                puanArtisi = 10;
                break;

            case "zor":
                puanArtisi = 15;
                break;
        }
        toplamPuan += puanArtisi;

        puanText.text = toplamPuan.ToString();
    }
}
