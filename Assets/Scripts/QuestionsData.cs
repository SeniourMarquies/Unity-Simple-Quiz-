using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionsData : MonoBehaviour
{
    public Questions questions;
    [SerializeField] private Text _questionText;

    private void Start()
    {
        AskQuestions();

    }

    public void AskQuestions()
    {
        if (CountValidQuestions() == 0)
        {
            _questionText.text = string.Empty;
            ClearQuestions();
            SceneManager.LoadScene("Main");
            return;

        }

        var randomIndex = 0;
        do
        {
            randomIndex = UnityEngine.Random.Range(0, questions.questionsList.Count);
        } while (questions.questionsList[randomIndex].questioned);

        questions.currentQuestion = randomIndex;
        questions.questionsList[questions.currentQuestion].questioned = true;
        _questionText.text = questions.questionsList[questions.currentQuestion].question;
    }

    private void ClearQuestions()
    {
        foreach (var question in questions.questionsList)
            question.questioned = false;

    }

    private int CountValidQuestions()
    {
        var validQuestions = 0;

        foreach (var question in questions.questionsList)
        {
            if (question.questioned == false)
                validQuestions++;
            Debug.Log("Questions Left" + validQuestions);


        }
        return validQuestions;

    }
}
