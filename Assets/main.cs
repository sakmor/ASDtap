using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    GameObject restartBtn;
    GameObject player;
    GameObject aImage;
    GameObject sImage;
    GameObject dImage;
    GameObject countdownText;
    GameObject Canvas;
    GameObject Jackie;
    public int gameTimeLength;
    int score;
    int answer;
    public float startTime;
    bool isGameOver;
    // Use this for initialization
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        isGameOver = false;                     //預設遊戲沒有結束
        gameTimeLength = 15;                    //預設遊戲長度為15秒
        startTime = Time.time;                  //計時用
        score = 0;                              //從0分開始遊戲
        player = GameObject.Find("player");
        aImage = GameObject.Find("aImage");
        sImage = GameObject.Find("sImage");
        dImage = GameObject.Find("dImage");
        Jackie = GameObject.Find("Jackie");
        countdownText = GameObject.Find("countdownText");
        restartBtn = GameObject.Find("restartBtn");

        Jackie.SetActive(false);                //隱藏踏錯圖示
        restartBtn.SetActive(false);            //隱藏重玩按鈕
        changeMap();                            //切換第一張關卡
    }

    // Update is called once per frame
    void Update()
    {
        control();
        countdown();
    }

    //切換地圖
    void changeMap()
    {
        //1、2、3，隨機跑一個結果作為可走得地方
        answer = (int)Random.Range(1, 4);

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

    //玩家的輸入
    void control()
    {
        if (isGameOver == false)
        {
            if (Input.GetKeyUp("a"))
            {
                Canvas.GetComponent<Animator>().Play("aboom");
                dected(1);
            }
            if (Input.GetKeyUp("s"))
            {
                Canvas.GetComponent<Animator>().Play("sboom");
                dected(2);
            }
            if (Input.GetKeyUp("d"))
            {
                Canvas.GetComponent<Animator>().Play("dboom");
                dected(3);
            }
        }
    }

    //判斷玩家的輸入
    void dected(int n)
    {
        //如果輸入正確
        if (n == answer)
        {
            //播放走路動作
            player.GetComponent<Animator>().Play("walk");
            //加分
            score++;
            //把分數顯示到遊戲畫面
            GameObject.Find("score").GetComponent<UnityEngine.UI.Text>().text = score.ToString("F0");
            //換下一關
            changeMap();
        }
        //如果輸入錯誤
        else
        {
            //開啟踏錯圖示
            Jackie.SetActive(true);
            //遊戲結束
            gameOver();
        }
    }

    //倒數計時用
    void countdown()
    {
        if (isGameOver == false)
        {
            float timeGO = gameTimeLength - (Time.time - startTime);
            countdownText.GetComponent<UnityEngine.UI.Text>().text = timeGO.ToString("F0");

            if (timeGO <= 0)
            {
                gameOver();
            }
        }


    }

    //遊戲結束
    void gameOver()
    {
        isGameOver = true;
        countdownText.GetComponent<UnityEngine.UI.Text>().text = "GameOver";
        restartBtn.SetActive(true);
    }

    //重啟遊戲
    public void restart()
    {
        Jackie.SetActive(false);                //隱藏踏錯圖示
        changeMap();
        isGameOver = false;
        startTime = Time.time;
        score = 0;
        restartBtn.SetActive(false);

    }


}
