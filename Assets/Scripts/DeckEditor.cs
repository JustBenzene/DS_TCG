using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DeckEditor : MonoBehaviour
{
    [SerializeField] GameObject numberOnScreen;
    [SerializeField] GameObject nameField;
    [SerializeField] GameObject middle;

    [SerializeField] GameObject overlays;
    [SerializeField] GameObject saveScreen;
    [SerializeField] GameObject chooseCharacter;

    [SerializeField] GameObject chosen;
    [SerializeField] GameObject chooseCharacterButton;
    [SerializeField] GameObject chosenSmall;
    [SerializeField] GameObject chosenText;
    [SerializeField] Sprite[] characterSprites;
    string[] characterNames = new string[] { "  Knight", " Assassin", " Sorcerer", "  Herald", "" };

    [SerializeField] GameObject[] chosenCardPoolColor;
    [SerializeField] GameObject[] chosenCardPoolText;

    [SerializeField] GameObject[] lines;
    float cardSize;
    [SerializeField] GameObject[] cards;
    int maxCards = 28;

    [SerializeField] Sprite[] cardTextures;
    int[,] allCards = new int[,] { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                                 , { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                                 , { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                                 , { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                                 , { 2, 3, 3, 3, 2, 2, 2, 2, 3, 2, 2, 2, 2, 2, 2, 2, 8, 4, 4, 8, 4, 4, 8, 4, 4, 8, 4, 4 } 
    };
    
    int number = GameManager.deckNumber;

    int[] deckCharacter = new int[] { 0, 1, 2, 3, 4 };
    int chosenDecknumber = 4;
    int chosenCharacter = 4;

    [SerializeField] GameObject cardPrefab;

    private void Start()
    {
        numberOnScreen.GetComponent<TextMeshProUGUI>().SetText(number.ToString());

        float temp = 568f + (GameManager.aspectRatio - 1.334545f) * 797f * 1.004405f;
        middle.GetComponent<RectTransform>().sizeDelta = new Vector2(800, temp);
        temp = 1f + (GameManager.aspectRatio - 1.334545f) * 0.2f * 1.004405f;
        overlays.GetComponent<RectTransform>().localScale = new Vector3(temp, temp, temp);
        temp = 650f + (GameManager.aspectRatio - 1.334545f) * 450f * 1.004405f;
        overlays.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, temp);

        int cardsInRow = 0;
        int rows;
        do
        {
            cardsInRow++;
            temp = middle.GetComponent<RectTransform>().sizeDelta.y / ((800 / cardsInRow) * 1.354497f);
            rows = Mathf.FloorToInt(temp);
            temp = rows * cardsInRow;
        }
        while (temp < maxCards);
        while ((rows - 1) * cardsInRow >= maxCards)
        {
            rows--;
        }
        for (int line = 0; line < 10; line++)
        {

            lines[line].GetComponent<RectTransform>().sizeDelta = new Vector2(800, middle.GetComponent<RectTransform>().sizeDelta.y / rows);
            if (line >= rows)
            {
                lines[line].SetActive(false);
            }
        }
        lines[0].SetActive(true);

        if (PlayerPrefs.GetString("Deck" + GameManager.deckNumber.ToString() + "Empty") == "n")
        {
            for (int deck = 0; deck < 4; deck++)
            {
                deckCharacter[deck] = int.Parse(PlayerPrefs.GetString("Deck" + GameManager.deckNumber.ToString() + "characters")[deck].ToString());
            }
        }

        cardSize = (800f / cardsInRow) * 1.25f;
        for (int line = 0; line < rows; line++)
        {
            for (int card = 0; card < cardsInRow; card++)
            {
                if ((card + 1) + line * cardsInRow < maxCards + 1)
                {
                    cards[card + line * cardsInRow] = Instantiate(cardPrefab, lines[line].transform, false);
                    cards[card + line * cardsInRow].GetComponent<Card>().deckEditor = this;
                    cards[card + line * cardsInRow].GetComponent<Card>().cardNumber = card + line * cardsInRow;
                    cards[card + line * cardsInRow].GetComponent<RectTransform>().sizeDelta = new Vector2(cardSize * 0.738281f, cardSize);
                    cards[card + line * cardsInRow].GetComponent<RectTransform>().anchoredPosition = new Vector2(card * (800f / cardsInRow) + (400f / cardsInRow), 0);
                }
            }
        }

        SetUpCards(4);
    }

    public void OnClickDontSafe()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickSave()
    {
        PlayerPrefs.SetString("Deck" + number.ToString() + "Empty", "n");
        PlayerPrefs.SetString("Deck" + number.ToString() + "Name", nameField.GetComponent<TMP_InputField>().text);
        PlayerPrefs.SetString("Deck" + number.ToString() + "characters", deckCharacter[0].ToString() + deckCharacter[1].ToString() + deckCharacter[2].ToString() + deckCharacter[3].ToString());
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickDone()
    {
        nameField.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("Deck" + number.ToString() + "Name");
        saveScreen.SetActive(true);
    }

    public void OnClickBack()
    {
        saveScreen.SetActive(false);
    }

    public void OnClickCharacter()
    {
        chosen.GetComponent<Image>().sprite = characterSprites[chosenCharacter];
        chooseCharacter.SetActive(true);
    }

    public void OnClickChosen()
    {
        for (int character = 0; character < 4; character++)
        {
            if (deckCharacter[character] == chosenCharacter)
            {
                deckCharacter[character] = deckCharacter[chosenDecknumber];
            }
        }
        deckCharacter[chosenDecknumber] = chosenCharacter;
        chooseCharacter.SetActive(false);
    }

    public void OnClickKnight()
    {
        CharacterChosen(0);
    }

    public void OnClickAssassin()
    {
        CharacterChosen(1);
    }

    public void OnClickSorcerer()
    {
        CharacterChosen(2);
    }

    public void OnClickHerald()
    {
        CharacterChosen(3);
    }

    void CharacterChosen(int pickcharacter)
    {
        chosen.GetComponent<Image>().sprite = characterSprites[pickcharacter];
        chosenSmall.GetComponent<Image>().sprite = characterSprites[pickcharacter];
        chosenText.GetComponent<TMP_Text>().text = characterNames[pickcharacter];
        chosenCharacter = pickcharacter;
    }

    public void OnClickAllCards()
    {
        Deck(4);
        SetUpCards(4);
    }

    public void OnClickDeck1()
    {
        Deck(0);
        SetUpCards(0);
    }

    public void OnClickDeck2()
    {
        Deck(1);
        SetUpCards(1);
    }

    public void OnClickDeck3()
    {
        Deck(2);
        SetUpCards(2);
    }

    public void OnClickDeck4()
    {
        Deck(3);
        SetUpCards(3);
    }

    void Deck(int deckNumber)
    {
        for (int deck = 0; deck < 5; deck++)
        {
            if (deck == deckNumber)
            {
                chosenCardPoolColor[deck].GetComponent<Image>().color = new Color32(0, 0, 0, 255);
                chosenCardPoolText[deck].GetComponent<TMP_Text>().color = new Color32(255, 255, 255, 255);
                chosenSmall.GetComponent<Image>().sprite = characterSprites[deckCharacter[deck]];
                chosenText.GetComponent<TMP_Text>().text = characterNames[deckCharacter[deck]];
                chosenCharacter = deckCharacter[deck];
                chosenDecknumber = deck;
            }
            else
            {
                chosenCardPoolColor[deck].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                chosenCardPoolText[deck].GetComponent<TMP_Text>().color = new Color32(50, 50, 50, 255);
            }
        }
        if (deckNumber == 4)
        {
            chooseCharacterButton.GetComponent<Button>().interactable = false;
            chosenSmall.SetActive(false);
        }
        else
        {
            chooseCharacterButton.GetComponent<Button>().interactable = true;
            chosenSmall.SetActive(true);
        }
    }

    void SetUpCards(int tab)
    {
        int counter = 0;
        for (int card = 0; card < maxCards; card++)
        {
            if (tab < 4)
            {
                for (int quantity = allCards[tab, card]; quantity > 0; quantity--)
                {
                    cards[counter].SetActive(true);
                    cards[counter].GetComponent<Image>().sprite = cardTextures[card];
                    cards[counter].GetComponent<Card>().cardType = card;
                    counter++;
                }
            }
            else if (allCards[tab, card] > 0)
            {
                cards[counter].SetActive(true);
                cards[counter].GetComponent<Image>().sprite = cardTextures[card];
                cards[counter].GetComponent<Card>().cardType = card;
                counter++;
            }
        }
        while (counter < 28)
        {
            cards[counter].SetActive(false);
            counter++;
        }
    }

    public void OnClickCard(int cardNumber, int cardType)
    {
        Debug.Log(cardNumber);
        Debug.Log(cardType);
    }
}
