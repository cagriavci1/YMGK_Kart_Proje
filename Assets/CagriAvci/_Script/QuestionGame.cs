using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuestionGame : MonoBehaviour
{
    public TMP_Text questionText;
    public TMP_InputField answerInput;
    public TMP_Text logText;

    private List<Question> questionPool = new List<Question>();
    private int currentQuestionIndex = 0;

    public GameObject dogruLog,yanlisLog;
    private void Start()
    {
        dogruLog.SetActive(false);
        yanlisLog.SetActive(false);
        // Soru havuzunu olu�turun
        CreateQuestionPool();

        // �lk soruyu g�sterin
        DisplayQuestion();
    }

    private void CreateQuestionPool()
    {
        // Soru havuzuna sorular� ekleyin
        questionPool.Add(new Question("Soru 1: 2 Ekim �ar�amba g�n�nden 2 hafta sonra hangi g�nd�r?", "16 Ekim"));
        questionPool.Add(new Question("Soru 2: 6 Ekim Pazar g�n�nden 6 g�n sonra hangi g�nd�r?", "12 Ekim"));
        questionPool.Add(new Question("Soru 3: Ekim ay�n�n 3. Per�embesinden 8 g�n sonra hangi g�nd�r?", "25 Ekim"));
        questionPool.Add(new Question("Soru 4: Ekim ay�n�n son g�n�nden 3 hafta �ncesi hangi g�nd�r?", "10 Ekim"));
        questionPool.Add(new Question("Soru 5: 12 Ekim Cumartesi g�n�nden 2 hafta sonra hangi g�nd�r?", "26 Ekim"));
    }

    private void DisplayQuestion()
    {
        // Mevcut soruyu g�sterin
        questionText.text = questionPool[currentQuestionIndex].question;
    }

    public void CheckAnswer()
    {
        // Kullan�c�n�n cevab�n� kontrol edin
        string userAnswer = answerInput.text;
        string correctAnswer = questionPool[currentQuestionIndex].answer;

        if (userAnswer == correctAnswer)
        {
            // Do�ru cevapland�, bir sonraki soruya ge�in
            LogMessage("Do�ru cevap!");
            Invoke("DogruLog",.2f);

            currentQuestionIndex++;

            if (currentQuestionIndex < questionPool.Count)
            {
                DisplayQuestion();
            }
            else
            {
                // Oyun bitti
                LogMessage("Oyun bitti!");
                SceneManager.LoadScene("Scene-3");
            }
        }
        else
        {
            // Yanl�� cevapland�, ayn� soruyu tekrar sorun
            LogMessage("Yanl�� cevap! Tekrar deneyin.");
            Invoke("YanlisLog",.2f);
        }

        // Giri� alan�n� temizleyin
        answerInput.text = "";
    }

    private void LogMessage(string message)
    {
        // Log mesaj�n� g�nl��e kaydedin
        logText.text += message + "\n";
    }
    void DogruLog()
    {
        dogruLog.SetActive(true);
        yanlisLog.SetActive(false);
        float sayac = 0;
        sayac += Time.deltaTime;
        if (sayac>5)
        {
            CancelInvoke("DogruLog");
        }
    }
    void YanlisLog() 
    {
        yanlisLog.SetActive(true);
        dogruLog.SetActive(false);
        float sayac = 0;
        sayac += Time.deltaTime;
        if (sayac > 5)
        {
            CancelInvoke("DogruLog");
        }
    }
}

public class Question
{
    public string question;
    public string answer;

    public Question(string question, string answer)
    {
        this.question = question;
        this.answer = answer;
    }
}