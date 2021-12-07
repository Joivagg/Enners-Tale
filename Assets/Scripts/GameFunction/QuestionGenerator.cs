using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionGenerator : MonoBehaviour
{
    [Header("Question Pool")]
    [Space]
    [SerializeField]
    private List<Question> defaultQuestionList = new List<Question>();
    private List<Question> localQuestionList = new List<Question>();
    [Space]

    [Header("Questions Number")]
    [Space]
    [SerializeField]
    [Range(0, 20)]
    private int questionsAmount;
    private List<Question> selectedQuestions = new List<Question>();
    [Space]

    [Header("Selected Questions")]
    [Space]
    [SerializeField]
    public List<Question> dungeonQuestions = new List<Question>();
    [Space]

    [Header("Plates")]
    [Space]
    [SerializeField]
    private Plate[] listPlates;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enner") && !other.isTrigger)
        {
            foreach(Question i in defaultQuestionList)
            {
                localQuestionList.Add(Instantiate(i));
            }
            QuestionRandomizer();
            SelectQuestions();
            dungeonQuestions.Clear();
            for (int i = 0; i < selectedQuestions.Count; i++)
            {
                string[] optionsList = new string[4]{selectedQuestions[i].option1,
                                                     selectedQuestions[i].option2,
                                                     selectedQuestions[i].option3,
                                                     selectedQuestions[i].option4};
                for (int j = 0; j < optionsList.Length; j++)
                {
                    string passString = optionsList[j];
                    int randomIndex = Random.Range(0, optionsList.Length);
                    optionsList[j] = optionsList[randomIndex];
                    optionsList[randomIndex] = passString;
                }
                Options rightAnswer = Options.optionOne;
                if(selectedQuestions[i].option1.Equals(optionsList[0]))
                {
                    rightAnswer = Options.optionOne;
                }
                if (selectedQuestions[i].option1.Equals(optionsList[1]))
                {
                    rightAnswer = Options.optionTwo;
                }
                if (selectedQuestions[i].option1.Equals(optionsList[2]))
                {
                    rightAnswer = Options.optionThree;
                }
                if (selectedQuestions[i].option1.Equals(optionsList[3]))
                {
                    rightAnswer = Options.optionFour;
                }
                Question formatQuestion = Question.CreateInstance(selectedQuestions[i].question,
                                                                  optionsList[0],
                                                                  optionsList[1],
                                                                  optionsList[2],
                                                                  optionsList[3],
                                                                  rightAnswer);
                dungeonQuestions.Add(formatQuestion);
            }
            
            for (int i = 0; i < listPlates.Length; i++)
            {
                listPlates[i].InitPlates();
            }
            gameObject.SetActive(false);
        }
    }

    private void QuestionRandomizer()
    {
        for (int oldPosition = 0; oldPosition < localQuestionList.Count; oldPosition++)
        {
            Question targetQuestion = Instantiate(localQuestionList[oldPosition]);
            int newPosition = Random.Range(0, localQuestionList.Count);
            localQuestionList[oldPosition] = localQuestionList[newPosition];
            localQuestionList[newPosition] = targetQuestion;
        }
    }

    private void SelectQuestions()
    {
        int questionsLeftToSelect = questionsAmount;
        for (int questionsLeftToCheck = localQuestionList.Count; questionsLeftToCheck > 0; questionsLeftToCheck--)
        {
            float chanceSelection = (float)questionsLeftToSelect / (float)questionsLeftToCheck;
            if (Random.value <= chanceSelection)
            {
                questionsLeftToSelect--;
                selectedQuestions.Add(Instantiate(localQuestionList[questionsLeftToCheck - 1]));
                if (questionsLeftToSelect == 0)
                {
                    break;
                }
            }
        }
    }
}
