using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassTest : MonoBehaviour
{    
    public TextAsset[] Test;

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

    private void Start()
    {
        ShowTest(0);
    }

    public void ShowTest(int testID)
    {    
        TestWindow.SetActive(true);

        qstCount = 0;
        this.testID = testID;        

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

        StartCoroutine(ShowRightQuestion());
    }

    public void ShowNextQuestion()
    {
        StopCoroutine(ShowRightQuestion());
        answersButton[rightAnswer].GetComponent<Graphic>().color = Color.white;
        ++qstCount; 

        string curQst = Test[qstCount].text;
        var parse = curQst.Split('/');        
        
        questionText.text = parse[0];

        var parseQst = parse[1].Split(';');
        for (int i = 0; i < 3; i++)
        {
            answersText[i].text = parseQst[i];
        }

        rightAnswer = int.Parse(parse[2]);
        if (qstCount < 4)
            StartCoroutine(ShowRightQuestion());
        else
            CloseTestWindow();
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
        TestWindow.SetActive(false);
    }
}
