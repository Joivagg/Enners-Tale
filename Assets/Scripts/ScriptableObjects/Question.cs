using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Options
{
    optionOne,
    optionTwo,
    optionThree,
    optionFour
}

[CreateAssetMenu]
public class Question : ScriptableObject
{
    [Header("Question Details")]
    public string question;
    public string option1;
    public string option2;
    public string option3;
    public string option4;
    public Options selectCorrect;

    public void DataQuestion(string question, string option1, string option2, string option3, string option4, Options selectCorrect)
    {
        this.question = question;
        this.option1 = option1;
        this.option2 = option2;
        this.option3 = option3;
        this.option4 = option4;
        this.selectCorrect = selectCorrect;
    }

    public static Question CreateInstance(string question, string option1, string option2, string option3, string option4, Options selectCorrect)
    {
        var data = ScriptableObject.CreateInstance<Question>();
        data.DataQuestion(question, option1, option2, option3, option4, selectCorrect);
        return data;
    }
}