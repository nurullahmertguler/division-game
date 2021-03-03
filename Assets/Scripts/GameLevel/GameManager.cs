using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject karePrefab;
    private GameObject[] karelerDizisi = new GameObject[28];
    private GameObject gecerliKare;
    public GameObject sonucPaneli;

    public Sprite[] kareSprites; 

    public Transform karelerPaneli;
    public Transform soruPaneli;
    public Transform puanPaneli;

    public AudioSource seskaynagi;
    public AudioClip butonsesi;

    public Text soruText;

    List<int> bolumDegerleriListesi = new List<int>();

    int bolunenSayi, bolenSayi,kacinciSoru,butonDegeri;
    int dogruSonuc;
    int kalanHak = 3;

    bool butonaBasilsinMi;

    string zorlukderecesi;

    KalanHaklarManager kalanHaklarManager;
    puanManager PuanManager;

    private void Awake()
    {
        kalanHaklarManager = Object.FindObjectOfType<KalanHaklarManager>();
        PuanManager = Object.FindObjectOfType<puanManager>();

        seskaynagi = GetComponent<AudioSource>();

        sonucPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;

        kalanHaklarManager.KalanHaklariKontrolEt(kalanHak);
    }

    // Start is called before the first frame update
    void Start()
    {
        butonaBasilsinMi = false;
        soruPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;
        KareleriOlustur();
        
    }

    public void KareleriOlustur()
    {
        for (int i = 0; i < 28; i++)
        {
            GameObject kare = Instantiate(karePrefab, karelerPaneli);
            kare.transform.GetChild(1).GetComponent<Image>().sprite = kareSprites[Random.Range( 0, kareSprites.Length)];
            kare.transform.GetComponent<Button>().onClick.AddListener(() => ButonaBasildi());
            karelerDizisi[i] = kare;
        }
        BolumDegerleriniTexteYazdir();

        StartCoroutine(DoFadeRoutine());

        Invoke("SoruPaneliniAc", 1.90f);

    }

    private void ButonaBasildi()
    {
        if (butonaBasilsinMi)
        {
            seskaynagi.PlayOneShot(butonsesi);

            butonDegeri = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);
            gecerliKare = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            SonucuKontrolEt();
        }   
    }

    private void SonucuKontrolEt()
    {
        if (butonDegeri == dogruSonuc)
        {
            gecerliKare.transform.GetChild(1).GetComponent<Image>().enabled = true;
            gecerliKare.transform.GetChild(0).GetComponent<Text>().text = "";
            gecerliKare.transform.GetComponent<Button>().interactable = false;
            PuanManager.puaniArttir(zorlukderecesi);

            bolumDegerleriListesi.RemoveAt(kacinciSoru);

            if (bolumDegerleriListesi.Count>0)
            {
                SoruPaneliniAc();
            }
            else
            {
                oyunbitti();
            }

            
        }
        else
        {
            kalanHak--;
            kalanHaklarManager.KalanHaklariKontrolEt(kalanHak);
        }
        if (kalanHak <= 0)
        {
            oyunbitti();
        }
    }

    private void oyunbitti()
    {
        butonaBasilsinMi = false;
        sonucPaneli.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
    }

    IEnumerator DoFadeRoutine()
    {
        foreach (var kare in karelerDizisi)
        {
            kare.GetComponent<CanvasGroup>().DOFade(1, 0.8f);
            yield return new WaitForSeconds(0.07f);
        }
    }

    void BolumDegerleriniTexteYazdir()
    {
        foreach (var kare in karelerDizisi)
        {
            int rasgeleDeger = Random.Range(1, 13);
            bolumDegerleriListesi.Add(rasgeleDeger);
            kare.transform.GetChild(0).GetComponent<Text>().text = rasgeleDeger.ToString();
        }
        
       
    }

    void SoruPaneliniAc()
    {
        SoruyuSor();

        soruPaneli.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);

        puanPaneli.GetComponent<CanvasGroup>().DOFade(1, 0.4f).SetEase(Ease.OutBack);

    }
    void SoruyuSor()
    {
        bolenSayi = Random.Range(2, 11);

        kacinciSoru = Random.Range(0, bolumDegerleriListesi.Count);

        dogruSonuc = bolumDegerleriListesi[kacinciSoru];
        bolunenSayi = bolenSayi * dogruSonuc;

        if (bolunenSayi<=30)
        {
            zorlukderecesi = "kolay";
        }
        else if (bolunenSayi>30 && bolunenSayi <=80)
        {
            zorlukderecesi = "orta";
        }
        else
        {
            zorlukderecesi = "zor";
        }

        soruText.text = bolunenSayi.ToString() + " : " + bolenSayi.ToString();

        butonaBasilsinMi = true;
    }
}
