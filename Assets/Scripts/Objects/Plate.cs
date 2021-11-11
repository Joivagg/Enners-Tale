using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plate : MonoBehaviour
{
    [Header("Question Info")]
    [Space]
    [SerializeField]
    private GameObject questionGenerator;
    [SerializeField]
    [Range(1, 20)]
    private int questionNumber;
    private Question formatQuestion;
    [Space]

    [Header("Door Info")]
    [Space]
    [SerializeField]
    private BoolValue storedValue;
    private bool isPlateActive;
    [SerializeField]
    private Sprite plateActivated;
    [SerializeField]
    private SpriteRenderer plateImage;
    [SerializeField]
    private Door targetDoor;
    [Space]

    [Header("UI Elements")]
    [Space]
    [SerializeField]
    private GameObject uiPanel;
    [SerializeField]
    private GameObject questionPanel;
    [SerializeField]
    private GameObject retryPanel;
    private bool isQuestionPanelActive;
    [Space]

    [Header("Option Buttons")]
    [Space]
    [SerializeField]
    private Button optionOne;
    private bool isOptionOne;
    [SerializeField]
    private Button optionTwo;
    private bool isOptionTwo;
    [SerializeField]
    private Button optionThree;
    private bool isOptionThree;
    [SerializeField]
    private Button optionFour;
    private bool isOptionFour;

    [Header("Text Fields")]
    [Space]
    [SerializeField]
    private Text questionText;
    [SerializeField]
    private Text option1Text;
    [SerializeField]
    private Text option2Text;
    [SerializeField]
    private Text option3Text;
    [SerializeField]
    private Text option4Text;
    [Space]

    [Header("Player Health")]
    [Space]
    [SerializeField]
    private FloatValue currentHealth;
    public Signals playerHealthSignal;
    [SerializeField]
    private GameObject heartsManager;
    [SerializeField]
    private GameObject player;
    [Space]

    [Header("Canvas")]
    [Space]
    [SerializeField]
    private GameObject container;
    [Space]

    [Header("SoundConfig")]
    [Space]
    [SerializeField]
    private AudioClip rightSound;
    [SerializeField]
    private AudioClip wrongSound;
    private AudioSource sourceSound;

    public void InitPlates()
    {
        formatQuestion = Instantiate(questionGenerator.GetComponent<QuestionGenerator>().dungeonQuestions[questionNumber - 1]);
        plateImage = GetComponent<SpriteRenderer>();
        sourceSound = GetComponent<AudioSource>();
        isPlateActive = storedValue.RuntimeValue;
        if (isPlateActive)
        {
            ActivatePlate();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enner") && !other.isTrigger)
        {
            optionOne.GetComponent<Image>().color = new Color32(127, 127, 127, 255);
            optionOne.onClick.RemoveAllListeners();
            optionTwo.GetComponent<Image>().color = new Color32(127, 127, 127, 255);
            optionTwo.onClick.RemoveAllListeners();
            optionThree.GetComponent<Image>().color = new Color32(127, 127, 127, 255);
            optionThree.onClick.RemoveAllListeners();
            optionFour.GetComponent<Image>().color = new Color32(127, 127, 127, 255);
            optionFour.onClick.RemoveAllListeners();
            questionText.text = formatQuestion.question;
            option1Text.text = formatQuestion.option1;
            if (formatQuestion.selectCorrect == Options.optionOne)
            {
                optionOne.onClick.AddListener(Open);
                isOptionOne = true;
            }
            else
            {
                optionOne.onClick.AddListener(WrongAnswer);
                optionOne.onClick.AddListener(BadAnswerOne);
                isOptionOne = false;
            }
            optionOne.onClick.AddListener(ChangePanel);
            option2Text.text = formatQuestion.option2;
            if (formatQuestion.selectCorrect == Options.optionTwo)
            {
                optionTwo.onClick.AddListener(Open);
                isOptionTwo = true;
            }
            else
            {
                optionTwo.onClick.AddListener(WrongAnswer);
                optionTwo.onClick.AddListener(BadAnswerTwo);
                isOptionTwo = false;
            }
            optionTwo.onClick.AddListener(ChangePanel);
            option3Text.text = formatQuestion.option3;
            if (formatQuestion.selectCorrect == Options.optionThree)
            {
                optionThree.onClick.AddListener(Open);
                isOptionThree = true;
            }
            else
            {
                optionThree.onClick.AddListener(WrongAnswer);
                optionThree.onClick.AddListener(BadAnswerThree);
                isOptionThree = false;
            }
            optionThree.onClick.AddListener(ChangePanel);
            option4Text.text = formatQuestion.option4;
            if (formatQuestion.selectCorrect == Options.optionFour)
            {
                optionFour.onClick.AddListener(Open);
                isOptionFour = true;
            }
            else
            {
                optionFour.onClick.AddListener(WrongAnswer);
                optionFour.onClick.AddListener(BadAnswerFour);
                isOptionFour = false;
            }
            optionFour.onClick.AddListener(ChangePanel);
            ChangePanel();
        }
    }

    public void ActivatePlate()
    {
        isPlateActive = false;
        storedValue.RuntimeValue = isPlateActive;
        targetDoor.Open();
        plateImage.sprite = plateActivated;
    }

    private void Open()
    {
        targetDoor.GetComponent<Door>().doorSprite.enabled = false;
        targetDoor.GetComponent<Door>().physicsCollider.enabled = false;
        targetDoor.gameObject.SetActive(false);
        GetComponent<BoxCollider2D>().enabled = false;
        isPlateActive = false;
        storedValue.RuntimeValue = isPlateActive;
        plateImage.sprite = plateActivated;
        sourceSound.clip = rightSound;
        sourceSound.Play();
        if (isOptionOne)
        {
            optionOne.GetComponent<Image>().color = new Color32(0, 127, 0, 255);
        }
        if (isOptionTwo)
        {
            optionTwo.GetComponent<Image>().color = new Color32(0, 127, 0, 255);
        }
        if (isOptionThree)
        {
            optionThree.GetComponent<Image>().color = new Color32(0, 127, 0, 255);
        }
        if (isOptionFour)
        {
            optionFour.GetComponent<Image>().color = new Color32(0, 127, 0, 255);
        }
    }

    private void WrongAnswer()
    {
        currentHealth.RuntimeValue -= 1;
        heartsManager.GetComponent<HeartManager>().UpdateHearts();
        sourceSound.clip = wrongSound;
        sourceSound.Play();
        if (currentHealth.RuntimeValue == 0)
        {
            player.SetActive(false);
            retryPanel.SetActive(true);
        }
    }

    private void BadAnswerOne()
    {
        optionOne.GetComponent<Image>().color = new Color32(127, 0, 0, 255);
    }

    private void BadAnswerTwo()
    {
        optionTwo.GetComponent<Image>().color = new Color32(127, 0, 0, 255);
    }

    private void BadAnswerThree()
    {
        optionThree.GetComponent<Image>().color = new Color32(127, 0, 0, 255);
    }

    private void BadAnswerFour()
    {
        optionFour.GetComponent<Image>().color = new Color32(127, 0, 0, 255);
    }

    private void ChangePanel()
    {
        isQuestionPanelActive = !isQuestionPanelActive;
        if (isQuestionPanelActive)
        {
            questionPanel.SetActive(true);
            uiPanel.SetActive(false);
            container.GetComponent<PauseMenu>().enabled = false;
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 0.1f;
            StartCoroutine(WaitCO(0.3f));
        }
    }

    private IEnumerator WaitCO(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        questionPanel.SetActive(false);
        container.GetComponent<PauseMenu>().enabled = true;
        uiPanel.SetActive(true);
        Time.timeScale = 1f;
    }
}
