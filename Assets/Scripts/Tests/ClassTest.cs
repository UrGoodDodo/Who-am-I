using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassTest : MonoBehaviour
{
    public bool[] finishedTest;
    
    TextAsset[] Test;
    public TextAsset[] biologyTest;
    public TextAsset[] mathTest;
    public TextAsset[] historyTest;

    int rightAnswer;
    int testID;
    int qstCount;

    public GameObject TestWindow;
    public Text subjectText;
    public Text themeText;
    public Text questionText;
    public Text[] answersText;
    public Button[] answersButton;

    public GameObject dm;
    public GameObject qg;

    public int rightAnswers;
    private void Start()
    {
        finishedTest = new bool[3] { false,false,false };
    }

    public void ShowTest(int testID)
    {    
        TestWindow.SetActive(true);

        qstCount = 0;
        this.testID = testID;

        switch (testID) 
        {
            case 0:
                Test = biologyTest;
                break;
            case 1:
                Test = mathTest;
                break;
            case 2:
                Test = historyTest;
                break;
        }

        string curQst = Test[qstCount].text;
        var parse = curQst.Split('/');

        subjectText.text = parse[0];
        themeText.text = parse[1];
        questionText.text = parse[2];

        var parseQst = parse[3].Split(';');
        for (int i = 0; i < 3; i++)
        {
            answersText[i].text = parseQst[i];
        }

        rightAnswer = int.Parse(parse[4]);

        if (testID == 0)
            StartCoroutine(dm.GetComponent<DialogueManager>().StartDialogWithTimer(9,3f));
        if (testID == 1)
            StartCoroutine(dm.GetComponent<DialogueManager>().StartDialogWithTimer(14, 3f));

        StartCoroutine(ShowRightQuestion());
    }

    public void ShowNextQuestion(int answr)
    {
        if (answr == rightAnswer) ++rightAnswers;

        StopCoroutine(ShowRightQuestion());
        answersButton[rightAnswer].GetComponent<Graphic>().color = Color.white;
        ++qstCount;
        if (qstCount == 5)
            CloseTestWindow();

        string curQst = Test[qstCount].text;
        var parse = curQst.Split('/');        
        
        questionText.text = parse[0];

        var parseQst = parse[1].Split(';');
        for (int i = 0; i < 3; i++)
        {
            answersText[i].text = parseQst[i];
        }

        rightAnswer = int.Parse(parse[2]);
        StartCoroutine(ShowRightQuestion());        
    }

    IEnumerator ShowRightQuestion()
    {
        yield return new WaitForSeconds(10f);
        answersButton[rightAnswer].GetComponent<Graphic>().color = Color.green;
    }

    void CloseTestWindow()
    {
        StopCoroutine(ShowRightQuestion());
        if (testID == 0)
            dm.GetComponent<DialogueManager>().StartDialogue(10);
        else if (testID == 1)
            qg.GetComponent<QuestGiver>().OpenQuestWindow(2);
        else
            dm.GetComponent<DialogueManager>().StartDialogue(16);
        TestWindow.SetActive(false);
    }
}
