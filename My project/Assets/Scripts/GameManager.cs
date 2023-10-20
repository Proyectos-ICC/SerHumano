using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    private int correctAnswers = 0;
    private bool areButtonsEnabled = true;


    static int startingLives = 3;
    static int currentLives;

    public Text livesText;

    [SerializeField] private AudioClip m_correctSound = null;
    [SerializeField] private AudioClip m_incorrectSound = null;
    [SerializeField] private Color m_correctColor = Color.black;
    [SerializeField] private Color m_incorrectColor = Color.black; 
    [SerializeField] private float m_waitTime = 0.1f; 
    private QuizDB m_quizDB = null;
    private QuizUI m_quizUI = null;
    private AudioSource m_audioSource = null;

    private void Start()
{
    
    currentLives = startingLives;
    UpdateLivesText();
    m_quizDB = FindObjectOfType<QuizDB>();
    m_quizUI = FindObjectOfType<QuizUI>();

    // Asigna el componente AudioSource
    m_audioSource = GetComponent<AudioSource>();

    m_quizDB.ShuffleQuestions();
    NextQuestion();
}

    private void UpdateLivesText()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentLives;
        }
    }

   private void NextQuestion()
{
    areButtonsEnabled = true;
    m_quizUI.Construct(m_quizDB.GetRandom(), GiveAnswer);
}


   private void GiveAnswer(OptionButton optionButton)
{
    if (areButtonsEnabled)
    {
        StartCoroutine(GiveAnswerRoutine(optionButton));

        if (optionButton.Option.correct)
        {
            correctAnswers++;
            if (correctAnswers >= 3)
            {
                LoadScene3();
            }
        }

        // Desactiva los botones después de responder
        areButtonsEnabled = false;
    }
}

    private IEnumerator GiveAnswerRoutine(OptionButton optionButton) 
    {
        if (m_audioSource.isPlaying)
            m_audioSource.Stop();

        m_audioSource.clip = optionButton.Option.correct ? m_correctSound : m_incorrectSound;
        optionButton.SetColor(optionButton.Option.correct ? m_correctColor : m_incorrectColor);

        m_audioSource.Play();
        yield return new WaitForSecondsRealtime(m_waitTime);

        if(optionButton.Option.correct)
            NextQuestion();
        else
            
            currentLives=currentLives-1;
            if(currentLives==0)
            
            GameOver();


         NextQuestion();
    }

    public void GameOver()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            SceneManager.LoadScene(1);
            currentLives = currentLives - 1;
            Debug.Log(currentLives);
        }
       
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            currentLives = currentLives - 1;
            SceneManager.LoadScene(2);
            Debug.Log(currentLives);
        }

        if (SceneManager.GetActiveScene().buildIndex == 11)
        {
            currentLives = currentLives - 1;
            SceneManager.LoadScene(9);
            Debug.Log(currentLives);
        }
    }

    public void GainLife(int amount)
    {
        currentLives += amount;
        UpdateLivesText();
    }

    private void LoadScene3()
    {
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            SceneManager.LoadScene(6); 

        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(4);

        }
        if (SceneManager.GetActiveScene().buildIndex == 11)
        {
            SceneManager.LoadScene(12);

        }

    }
}
