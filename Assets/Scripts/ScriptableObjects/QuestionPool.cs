using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class QuestionPool : ScriptableObject
{
    [Header("Questions List")]
    public List<Question> questionPool;
}
