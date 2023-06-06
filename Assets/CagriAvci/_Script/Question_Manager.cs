using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Question_Manager : MonoBehaviour
{
    public string[] sorular;
    public int[] cevaplar;

    // soru havuzu listesi olacak
    // cevap havuzu listesi olacak
    // soru s�re havuzu listesi olacak
    // do�ru ve yanl�� cevap puan� etkileyecek
    // puan sistemi olacak
    // puan harcama ile joker sat�n alacak
    // joker i�levi soruda 2 ��k eleyecek
    // 
    public TextMeshProUGUI Question_Number;
    public TextMeshProUGUI Question_Text;

    public int questionNumber = 0;

    public TextMeshProUGUI A_button;
    public TextMeshProUGUI B_button;
    public TextMeshProUGUI C_button;
    public TextMeshProUGUI D_button;

    public int indexCount;

    void Start()
    {
        sorular = new string[5];
        sorular[0] = "G�rselde yer alan YE��L KURBA�ALAR'�n say�s� ka�t�r?";
        sorular[1] = "G�rselde yer alan KIRMIZI KURBA�ALAR'�n say�s� ka�t�r?";
        sorular[2] = "G�rselde yer alan KIRMIZI ���EKLER'in say�s� ka�t�r?";
        sorular[3] = "G�rselde yer alan TURUNCU ���EKLER'in say�s� ka�t�r?";
        sorular[4] = "G�rselde yer alan BEYAZ ���EKLER'in say�s� ka�t�r?";

        cevaplar = new int[5];
        cevaplar[0] = 5;
        cevaplar[1] = 7;
        cevaplar[2] = 11;
        cevaplar[3] = 12;
        cevaplar[4] = 9;


        SoruGetir(questionNumber);
    }

    void Update()
    {
        if (questionNumber==5)
        {
            SceneManager.LoadScene(2);
        }
    }
    
    public void IndexGonder(int index)
    {
        if (indexCount == index)
            DogruCevap();
        else
            Yanl�sCevap();
    }

    private void Yanl�sCevap()
    {
        Debug.Log("Yanl��");
        SoruGetir(questionNumber);
    }

    private void DogruCevap()
    {
        Debug.Log("Dogru");
        indexCount = 0;
        if (questionNumber < 5)
            questionNumber++;
        else
            Debug.Log("Oyun Bitti");//Game Finish

        SoruGetir(questionNumber);
    }

    public void SoruGetir(int questionNo)
    {
        Question_Text.text = sorular[questionNo];
        Question_Number.text = (questionNo + 1).ToString();

        int dogruIndex = Random.RandomRange(0, 4);

        switch (dogruIndex)
        {
            case 0:
                A_button.text = cevaplar[questionNo].ToString();
                B_button.text = RandomGenerator(6, 30);
                C_button.text = RandomGenerator(10, 30);
                D_button.text = RandomGenerator(19, 30);
                break;
            case 1:
                A_button.text = RandomGenerator(18,30);
                B_button.text = cevaplar[questionNo].ToString();
                C_button.text = RandomGenerator(10, 30);
                D_button.text = RandomGenerator(15, 30);
                break;
            case 2:
                A_button.text = RandomGenerator(18, 30);
                B_button.text = RandomGenerator(13, 30);
                C_button.text = cevaplar[questionNo].ToString();
                D_button.text = RandomGenerator(19, 30);
                break;
            case 3:
                A_button.text = RandomGenerator(18, 30);
                B_button.text = RandomGenerator(19, 30);
                C_button.text = RandomGenerator(17, 30);
                D_button.text = cevaplar[questionNo].ToString();
                break;
            default:
                break;
        }

        indexCount = dogruIndex;

    }
    string RandomGenerator(int min, int max)
    {
        int sayi= Random.RandomRange(min, max);
        string returnedString = sayi.ToString();

        return returnedString;
    }
    
    void Next_Button()
    {
        // soru cevap ekran� ac�lacak
        // b�r oncek� kart ekran� objeler� kapanacak
        // timer geri say�m� ba�layacak
    }
    void Prev_Button()
    {
        // kart ekran� objeler� ac�lacak
        // soru cevap ekran� kapanacak
        // timer geri say�m� s�f�rlanacak
        // son kal�nan soru tutulup devam edilmesi sa�lanacak
    }
}
