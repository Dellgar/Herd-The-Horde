using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStore : MonoBehaviour {

    public GameObject gameStore;
    public GameObject guiPanel;
    public GameObject shepherdsDogIcon;
    public GameObject timeBaahmbIcon;
    public GameObject decoySheepIcon;
    public GameObject dollyingIcon;
    public GameObject colourChangeIcon;
    //public int[] powerUpPrices = new int[] { 50, 100, 150, 1000, 2000 };

    public int coinAmount;
    public int coinCost;
    public Text coinsOwned;

    [Header("Prices")]
    public int shepherdsDogPrice;
    public int timeBaahmbPrice;
    public int decoySheepPrice;
    public int dollyingPrice;
    public int colourChangePrice;



    private void Start()
    {
        if (gameStore == null) GameObject.Find("GameStore");
        coinAmount = 5000;
        
    }

    void Update()
    {
        coinsOwned.text = "COINS: " + coinAmount.ToString();

        coinChecker();

    }

    public void OpenGameStore()
    {
        gameStore.SetActive(true);
        guiPanel.SetActive(false);
    }

    public void CloseGameStore()
    {
        gameStore.SetActive(false);
        guiPanel.SetActive(true);
    }

    public void BuyPowerUps(Button btn)
    {
        Debug.Log(btn.name);

        if (btn.name == "Shepherds Dog")
        {
            coinAmount = coinAmount - shepherdsDogPrice;
        }
        if (btn.name == "Time Baahmb")
        {
            coinAmount = coinAmount - timeBaahmbPrice;
        }
        if (btn.name == "Decoy Sheep")
        {
            coinAmount = coinAmount - decoySheepPrice;
        }
        if (btn.name == "Dollying")
        {
           coinAmount = coinAmount - dollyingPrice;
        }
        if (btn.name == "Colour Change")
        {
            coinAmount = coinAmount - colourChangePrice;
        }
    }

    public void coinChecker()
    {
        if (coinAmount <= 0) coinAmount = 0;

        if (coinAmount <= 49)
        {
            shepherdsDogIcon.SetActive(false);
            timeBaahmbIcon.SetActive(false);
            decoySheepIcon.SetActive(false);
            dollyingIcon.SetActive(false);
            colourChangeIcon.SetActive(false);
        }
        else if (coinAmount <= 99)
        {
            shepherdsDogIcon.SetActive(false);
            timeBaahmbIcon.SetActive(false);
            decoySheepIcon.SetActive(false);
            dollyingIcon.SetActive(false);
            colourChangeIcon.SetActive(true);
        }

        else if (coinAmount <= 149)
        {
            shepherdsDogIcon.SetActive(false);
            timeBaahmbIcon.SetActive(false);
            decoySheepIcon.SetActive(false);
            dollyingIcon.SetActive(true);
            colourChangeIcon.SetActive(true);
        }

        else if (coinAmount <= 999)
        {
            shepherdsDogIcon.SetActive(false);
            timeBaahmbIcon.SetActive(false);
            decoySheepIcon.SetActive(true);
            dollyingIcon.SetActive(true);
            colourChangeIcon.SetActive(true);
        }

        else if (coinAmount <= 1999)
        {
            shepherdsDogIcon.SetActive(true);
            timeBaahmbIcon.SetActive(false);
            decoySheepIcon.SetActive(true);
            dollyingIcon.SetActive(true);
            colourChangeIcon.SetActive(true);
        }

        else if (coinAmount >= 2000)
        {
            shepherdsDogIcon.SetActive(true);
            timeBaahmbIcon.SetActive(true);
            decoySheepIcon.SetActive(true);
            dollyingIcon.SetActive(true);
            colourChangeIcon.SetActive(true);
        }
        else return;
    }
}
