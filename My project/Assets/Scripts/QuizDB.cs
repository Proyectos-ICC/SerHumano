using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq; // Asegúrate de tener esta directiva

public class QuizDB : MonoBehaviour
{
    [SerializeField] private List<Question> m_questionList = null;
    private List<Question> m_backup;

    private void Awake()
    {
        m_backup = m_questionList.ToList(); // Crea una copia de la lista original
    }

    public void ShuffleQuestions()
    {
        System.Random random = new System.Random();
        int n = m_questionList.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            Question value = m_questionList[k];
            m_questionList[k] = m_questionList[n];
            m_questionList[n] = value;
        }
    }

    public Question GetRandom(bool remove = true)
    {
        if (m_questionList.Count == 0)
        {
            int index = UnityEngine.Random.Range(0, m_backup.Count);

            if (!remove)
                return m_backup[index];

            Question randomQuestion = m_backup[index];
            m_questionList.Remove(randomQuestion);

            return randomQuestion;
        }
        else
        {
            int index = UnityEngine.Random.Range(0, m_questionList.Count);

            if (!remove)
                return m_questionList[index];

            Question randomQuestion = m_questionList[index];
            m_questionList.RemoveAt(index);

            return randomQuestion;
        }
    }

    private void RestoreBackup()
    {
        m_questionList = m_backup.ToList(); // Restaura la lista original desde la copia
    }
}
