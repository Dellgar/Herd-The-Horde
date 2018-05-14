using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStore : MonoBehaviour {

	private PlayerProgress pprogScript;

	[Header("Objects")]
	private Text pstatus;
	public GameObject gameStorePanel;
    public GameObject guiPanel;
    public GameObject shepherdsDogIcon;
    public GameObject timeBaahmbIcon;
    public GameObject decoySheepIcon;
    public GameObject dollyingIcon;
    public GameObject colourChangeIcon;
	//public int[] powerUpPrices = new int[] { 50, 100, 150, 1000, 2000 };

	[Header("Currency")]
	private int coinAmount;
    public Text coinsOwnedTxtObj;

    [Header("Prices")]
	[SerializeField] private int shepherdsDogPrice;
	[SerializeField] private int timeBaahmbPrice;
	[SerializeField] private int decoySheepPrice;
	[SerializeField] private int dollyingPrice;
	[SerializeField] private int colourChangePrice;

	private void Awake()
	{
		pprogScript = GameObject.Find("_player").GetComponent<PlayerProgress>();
	}

	private void Start()
    {
        if (gameStorePanel == null) GameObject.Find("GameStore");
        coinAmount = pprogScript.playerCurrency;
        
    }

    void Update()
    {
		if (pprogScript == null) pprogScript = GameObject.Find("_player").GetComponent<PlayerProgress>();
		if (pstatus == null) pstatus = GameObject.Find("pstatus").GetComponent<Text>();

		pstatus.text = "Score: [" + pprogScript.playerScore.ToString() + "] Currency: [" + pprogScript.playerCurrency.ToString() +"]";

		coinAmount = pprogScript.playerCurrency;

		coinsOwnedTxtObj.text = "COINS: " + coinAmount.ToString();

        CoinChecker();

		

    }


    public void OpenGameStore()
    {
        gameStorePanel.SetActive(true);
        guiPanel.SetActive(false);
    }

    public void CloseGameStore()
    {
        gameStorePanel.SetActive(false);
        guiPanel.SetActive(true);
    }

    public void BuyPowerUps(Button btn)
    {
        Debug.Log("Bought a " + btn.name);

        if (btn.name == "Shepherds Dog")
        {
            coinAmount = coinAmount - shepherdsDogPrice;
			pprogScript.playerCurrency = coinAmount;
        }
        if (btn.name == "Time Baahmb")
        {
            coinAmount = coinAmount - timeBaahmbPrice;
			pprogScript.playerCurrency = coinAmount;
		}
		if (btn.name == "Decoy Sheep")
        {
            coinAmount = coinAmount - decoySheepPrice;
			pprogScript.playerCurrency = coinAmount;
		}
		if (btn.name == "Dollying")
        {
            coinAmount = coinAmount - dollyingPrice;
			pprogScript.playerCurrency = coinAmount;
		}
		if (btn.name == "Colour Change")
        {
            coinAmount = coinAmount - colourChangePrice;
			pprogScript.playerCurrency = coinAmount;
		}
	}

    public void CoinChecker()
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
