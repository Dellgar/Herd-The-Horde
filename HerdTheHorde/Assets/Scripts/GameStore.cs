using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStore : MonoBehaviour {

	private PlayerProgress pprogScript;
    private AudioSource audioSource;
    public AudioClip[] audioStore;

	[Header("Objects")]
	private Text pstatus;
	public GameObject gameStorePanel;
    public GameObject guiPanel;
    public GameObject shepherdsDogIcon;
    public GameObject timeBaahmbIcon;
    public GameObject decoySheepIcon;
    public GameObject dollyingIcon;
    public GameObject colourChangeIcon;

	[Header("Currency")]
	private int coinAmount;
    public Text coinsOwnedTxtObj;
    private int currencyhelper;

    [Header("Prices")]
	[SerializeField] private int shepherdsDogPrice;
	[SerializeField] private int timeBaahmbPrice;
	[SerializeField] private int decoySheepPrice;
	[SerializeField] private int dollyingPrice;
	[SerializeField] private int colourChangePrice;

	private void Awake()
	{
		pprogScript = GameObject.Find("_player").GetComponent<PlayerProgress>();
        pstatus = GameObject.Find("pstatus").GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }

	private void Start()
    {
        if (gameStorePanel == null) GameObject.Find("GameStore");

        pprogScript.playerCurrency = pprogScript.playerScore / 10;
        pstatus.text = pprogScript.levelProgress.ToString() + " / 5";
    }

    IEnumerator SetCurrencyTxt()
    {
        coinsOwnedTxtObj.text = "" + pprogScript.playerCurrency.ToString();
        yield return null;
    }

    public void OpenGameStore()
    {
        gameStorePanel.SetActive(true);
        guiPanel.SetActive(false);
        audioSource.PlayOneShot(audioStore[1]);
        StartCoroutine("SetCurrencyTxt");
        StartCoroutine("CoinChecker");
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
			pprogScript.playerCurrency = pprogScript.playerCurrency - shepherdsDogPrice;
            Debug.Log("Coins" + pprogScript.playerCurrency + "  and Price was " + shepherdsDogPrice);
        }
        if (btn.name == "Time Baahmb")
        {
			pprogScript.playerCurrency = pprogScript.playerCurrency - timeBaahmbPrice;
            Debug.Log("Coins" + pprogScript.playerCurrency + "  and Price was " + timeBaahmbPrice);

        }
        if (btn.name == "Decoy Sheep")
        {
			pprogScript.playerCurrency = pprogScript.playerCurrency - decoySheepPrice;
            Debug.Log("Coins" + pprogScript.playerCurrency + "  and Price was " + decoySheepPrice);

        }
        if (btn.name == "Dollying")
        {
			pprogScript.playerCurrency = pprogScript.playerCurrency - dollyingPrice;
            Debug.Log("Coins" + pprogScript.playerCurrency + "  and Price was " + dollyingPrice);

        }
        if (btn.name == "Colour Change")
        {
			pprogScript.playerCurrency = pprogScript.playerCurrency - colourChangePrice;
            Debug.Log("Coins" + pprogScript.playerCurrency + "  and Price was " + colourChangePrice);

        }

        StartCoroutine("SetCurrencyTxt");
        StartCoroutine("CoinChecker");
    }

    IEnumerator CoinChecker()
    {
        yield return new WaitForEndOfFrame();
        if (pprogScript.playerCurrency <= 0)
        {
            shepherdsDogIcon.GetComponent<Button>().interactable = false;
            timeBaahmbIcon.GetComponent<Button>().interactable = false;
            decoySheepIcon.GetComponent<Button>().interactable = false;
            dollyingIcon.GetComponent<Button>().interactable = false;
            colourChangeIcon.GetComponent<Button>().interactable = false;
            yield return null;
        }
        if (pprogScript.playerCurrency >= 1 && pprogScript.playerCurrency <= 49)
        {
            shepherdsDogIcon.GetComponent<Button>().interactable = false;
            timeBaahmbIcon.GetComponent<Button>().interactable = false;
            decoySheepIcon.GetComponent<Button>().interactable = false;
            dollyingIcon.GetComponent<Button>().interactable = false;
            colourChangeIcon.GetComponent<Button>().interactable = false;
            yield return null;
        }
        else if (pprogScript.playerCurrency >= 50 && pprogScript.playerCurrency <= 99)
        {
            shepherdsDogIcon.GetComponent<Button>().interactable = false;
            timeBaahmbIcon.GetComponent<Button>().interactable = false;
            decoySheepIcon.GetComponent<Button>().interactable = false;
            dollyingIcon.GetComponent<Button>().interactable = false;
            colourChangeIcon.GetComponent<Button>().interactable = true;
            yield return null;
        }

        else if (pprogScript.playerCurrency >= 100 && pprogScript.playerCurrency <= 149)
        {
            shepherdsDogIcon.GetComponent<Button>().interactable = false;
            timeBaahmbIcon.GetComponent<Button>().interactable = false;
            decoySheepIcon.GetComponent<Button>().interactable = false;
            dollyingIcon.GetComponent<Button>().interactable = true;
            colourChangeIcon.GetComponent<Button>().interactable = true;
            yield return null;
        }

        else if (pprogScript.playerCurrency >= 150 && pprogScript.playerCurrency <= 999)
        {
            shepherdsDogIcon.GetComponent<Button>().interactable = false;
            timeBaahmbIcon.GetComponent<Button>().interactable = false;
            decoySheepIcon.GetComponent<Button>().interactable = true;
            dollyingIcon.GetComponent<Button>().interactable = true;
            colourChangeIcon.GetComponent<Button>().interactable = true;
            yield return null;
        }

        else if (pprogScript.playerCurrency >= 1000 && pprogScript.playerCurrency <= 1999)
        {
            shepherdsDogIcon.GetComponent<Button>().interactable = true;
            timeBaahmbIcon.GetComponent<Button>().interactable = false;
            decoySheepIcon.GetComponent<Button>().interactable = true;
            dollyingIcon.GetComponent<Button>().interactable = true;
            colourChangeIcon.GetComponent<Button>().interactable = true;
            yield return null;
        }

        else if (pprogScript.playerCurrency >= 2000)
        {
            shepherdsDogIcon.GetComponent<Button>().interactable = true;
            timeBaahmbIcon.GetComponent<Button>().interactable = true;
            decoySheepIcon.GetComponent<Button>().interactable = true;
            dollyingIcon.GetComponent<Button>().interactable = true;
            colourChangeIcon.GetComponent<Button>().interactable = true;
            yield return null;
        }
        yield return null;
    }
    	
}
