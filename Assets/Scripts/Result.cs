using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
 public Questions questions;

 public GameObject correctSprite;
 public GameObject incorrectSprite;
 public Scores scores;

 public Button trueButton;
 public Button falseButton;

 public UnityEvent onNextQuestion;

 private void Start()
 {
  correctSprite.SetActive(false);
  incorrectSprite.SetActive(false);

 }

 public void ShowResults(bool answer)
 {
  correctSprite.SetActive(questions.questionsList[questions.currentQuestion].isTrue == answer);
  incorrectSprite.SetActive(questions.questionsList[questions.currentQuestion].isTrue != answer);

  if (questions.questionsList[questions.currentQuestion].isTrue == answer)
   scores.AddScore();
  else
   scores.DeductScore();

  trueButton.interactable = false;
  falseButton.interactable = false;

  StartCoroutine(ShowResult());
 }

 IEnumerator ShowResult()
 {
  yield return new WaitForSeconds(1.0f);

  correctSprite.SetActive(false);
  incorrectSprite.SetActive(false);

  trueButton.interactable = true;
  falseButton.interactable = true;

  onNextQuestion.Invoke();
 }
}
