using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gallery : MonoBehaviour
{
    private Image gallerySelection;

    [Header("Sheep")]
    public Sprite sheep;
    public Sprite sheepTon;
    public Sprite initialSheep;
    public Sprite confusheep;
    public Sprite rainbaah;
    public Sprite invisibaah;
    public Sprite sheepmon;
    public Sprite rebaahl;
    public Sprite sheepjutsu;
    public Sprite freezer;
    public Sprite foolWool;

    [Header("Wolf")]
    public Sprite wolf;

    [Header("Power-ups")]
    public Sprite timeBaahmb;
    public Sprite shepherdsDog;
    public Sprite decoySheep;
    public Sprite dollying;
    public Sprite colourChange;

    void Start()
    {
        gallerySelection = GetComponent<Image>();
    }

    public void ChosenSprite(Button btn)
    {
        if (btn.name == "Sheep")
        {
            gallerySelection.sprite = sheep;
        }
        if (btn.name == "SheepTon")
        {
            gallerySelection.sprite = sheepTon;
        }
        if (btn.name == "Initial Sheep")
        {
            gallerySelection.sprite = initialSheep;
        }
        if (btn.name == "Confusheep")
        {
            gallerySelection.sprite = confusheep;
        }
        if (btn.name == "Rainbaah")
        {
            gallerySelection.sprite = rainbaah;
        }
        if (btn.name == "Invisibaah")
        {
            gallerySelection.sprite = invisibaah;
        }
        if (btn.name == "Sheepmon")
        {
            gallerySelection.sprite = sheepmon;
        }
        if (btn.name == "Rebaahl")
        {
            gallerySelection.sprite = rebaahl;
        }
        if (btn.name == "Sheepjutsu")
        {
            gallerySelection.sprite = sheepjutsu;
        }
        if (btn.name == "Freezer")
        {
            gallerySelection.sprite = freezer;
        }
        if (btn.name == "Fool Wool")
        {
            gallerySelection.sprite = foolWool;
        }
        if (btn.name == "Wolf")
        {
            gallerySelection.sprite = wolf;
        }
        if (btn.name == "Time Baahmb")
        {
            gallerySelection.sprite = timeBaahmb;
        }
        if (btn.name == "Shepherds Dog")
        {
            gallerySelection.sprite = shepherdsDog;
        }
        if (btn.name == "Decoy Sheep")
        {
            gallerySelection.sprite = decoySheep;
        }
        if (btn.name == "Dollying")
        {
            gallerySelection.sprite = dollying;
        }
        if (btn.name == "Colour Change")
        {
            gallerySelection.sprite = colourChange;
        }
    }
}
