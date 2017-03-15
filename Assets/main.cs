using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    GameObject player;
    GameObject aImage;
    GameObject sImage;
    GameObject dImage;
    int score;
    int answer;
    float countdownTime;
    // Use this for initialization
    void Start()
    {
        countdownTime = Time.time;
        score = 0;
        player = GameObject.Find("player");
        aImage = GameObject.Find("aImage");
        sImage = GameObject.Find("sImage");
        dImage = GameObject.Find("dImage");
        changeMap();
    }

    // Update is called once per frame
    void Update()
    {
        control();
        countdown();
    }
    void countdown()
    {
        if (Time.time - countdownTime > 1)
        {
            countdownTime = Time.time;


        }

    }
    void control()
    {
        if (Input.GetKeyUp("a"))
        {
            player.GetComponent<Animator>().Play("walk");
            dected(1);
        }
        if (Input.GetKeyUp("s"))
        {
            player.GetComponent<Animator>().Play("walk");
            dected(2);
        }
        if (Input.GetKeyUp("d"))
        {
            player.GetComponent<Animator>().Play("walk");
            dected(3);
        }
    }
    void dected(int n)
    {

        if (n != answer)
        {
            //dead
            GameObject.Find("score").GetComponent<UnityEngine.UI.Text>().text = "GameOver";
            score = 0;
            changeMap();

        }
        else
        {
            score++;
            GameObject.Find("score").GetComponent<UnityEngine.UI.Text>().text = score.ToString("F0");
            changeMap();
        }

    }
    void changeMap()
    {
        //1、2、3，隨機跑一個結果作為可走得地方
        answer = (int)Random.Range(1, 4);
        Debug.Log(answer);
        //依據answer的結果，改變畫面的圖片
        switch (answer)
        {
            case 1:
                aImage.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("ok");
                sImage.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("ng");
                dImage.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("ng");
                break;
            case 2:
                aImage.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("ng");
                sImage.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("ok");
                dImage.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("ng");
                break;
            case 3:
                aImage.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("ng");
                sImage.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("ng");
                dImage.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("ok");

                break;
        }

    }
}
