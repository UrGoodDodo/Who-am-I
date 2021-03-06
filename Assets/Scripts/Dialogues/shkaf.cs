using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shkaf : MonoBehaviour
{
    public Player player;
    public DialogueManager dm;
    public QuestGiver qg;
    public GameObject panel;

    public Sprite hudistay;
    public GameObject PlayerHudi;
    public GameObject oldPlayer;

    public Text wear;

    public bool isWeared = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && !isWeared && panel.active)
        {
            isWeared = true;
            player.mainQuest.numericGoal += 1;
            wear.color = new Color(128 / 255.0f, 128 / 255.0f, 128 / 255.0f);
            if (player.mainQuest.numericGoal == 2)
                qg.OpenExtraQuestWindow(0);
            panel.SetActive(false);

            PlayerHudi.SetActive(true);
            player.GetComponent<Move>().player = PlayerHudi;
            player.GetComponent<Move>().stay = hudistay;
            oldPlayer.SetActive(false);

            dm.skin = 3;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)	//?????????? ??? ???????????? ??????? ?????????? ?? ???????
    {
        if (!isWeared)
            panel.SetActive(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        panel.SetActive(false);
    }
}
