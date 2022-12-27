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
    [SerializeField] GameObject chosenSmall;
    [SerializeField] GameObject chosenText;
    [SerializeField] Sprite[] characterSprites;
    string[] characterNames = new string[] { "  Knight", " Assassin", " Sorcerer", "  Herald" };

    [SerializeField] GameObject[] chosenCardPoolColor;
    [SerializeField] GameObject[] chosenCardPoolText;
    [SerializeField] GameObject[] chosenDeck;

    [SerializeField] GameObject[] lines;

    int number = GameManager.deckNumber;

    int[] deckCharacter = new int[] { 0, 1, 2, 3, 0 };
    int chosenDecknumber = 4;
    int chosenCharacter = 0;

    private void Start()
    {
        float temp = 568f + (GameManager.aspectRatio - 1.334545f) * 797f * 1.004405f;
        middle.GetComponent<RectTransform>().sizeDelta = new Vector2(800, temp);

        numberOnScreen.GetComponent<TextMeshProUGUI>().SetText(number.ToString());

        temp = 1f + (GameManager.aspectRatio - 1.334545f) * 0.2f * 1.004405f;
        overlays.GetComponent<RectTransform>().localScale = new Vector3(temp, temp, temp);
        temp = 650f + (GameManager.aspectRatio - 1.334545f) * 450f * 1.004405f;
        overlays.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, temp, 0);

        int cardsInRow = 0;
        int rows;
        do
        {
            cardsInRow++;
            temp = middle.GetComponent<RectTransform>().sizeDelta.y / ((800 / cardsInRow) * 1.4f);
            rows = Mathf.FloorToInt(temp);
            temp = rows * cardsInRow;
        }
        while (temp < 28);

        for (int line = 0; line < 10; line++)
        {

            lines[line].GetComponent<RectTransform>().sizeDelta = new Vector2(800, middle.GetComponent<RectTransform>().sizeDelta.y / rows);
            if (line >= rows)
            {
                lines[line].SetActive(false);
            }
        }
        lines[0].SetActive(true);
    }

    public void OnClickDontSafe()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickSave()
    {
        PlayerPrefs.SetString("Deck" + number.ToString() + "Empty", "n");
        PlayerPrefs.SetString("Deck" + number.ToString() + "Name", nameField.GetComponent<TMP_InputField>().text);
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
        if (chosenDecknumber == 4)
        {
            int temp = 0;
            for (int character = 0; character < 4; character++)
            {
                if (deckCharacter[character] == deckCharacter[4])
                {
                    temp = character;
                }
            }
            for (int character = 0; character < 4; character++)
            {
                if (deckCharacter[character] == chosenCharacter)
                {
                    deckCharacter[character] = deckCharacter[chosenDecknumber];
                }
            }
            deckCharacter[temp] = chosenCharacter;
            deckCharacter[4] = chosenCharacter;
        }
        else
        {
            for (int character = 0; character < 4; character++)
            {
                if (deckCharacter[character] == chosenCharacter)
                {
                    deckCharacter[character] = deckCharacter[chosenDecknumber];
                }
            }
            if (deckCharacter[chosenDecknumber] == deckCharacter[4])
            {
                deckCharacter[4] = chosenCharacter;
            }
            deckCharacter[chosenDecknumber] = chosenCharacter;
        }
        chooseCharacter.SetActive(false);
    }

    public void OnClickKnight()
    {
        characterChosen(0);
    }

    public void OnClickAssassin()
    {
        characterChosen(1);
    }

    public void OnClickSorcerer()
    {
        characterChosen(2);
    }

    public void OnClickHerald()
    {
        characterChosen(3);
    }

    void characterChosen(int pickcharacter)
    {
        chosen.GetComponent<Image>().sprite = characterSprites[pickcharacter];
        chosenSmall.GetComponent<Image>().sprite = characterSprites[pickcharacter];
        chosenText.GetComponent<TMP_Text>().text = characterNames[pickcharacter];
        chosenCharacter = pickcharacter;
    }

    public void OnClickAllCards()
    {
        Deck(4);
    }

    public void OnClickDeck1()
    {
        Deck(0);
    }

    public void OnClickDeck2()
    {
        Deck(1);
    }

    public void OnClickDeck3()
    {
        Deck(2);
    }

    public void OnClickDeck4()
    {
        Deck(3);
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
    }

    public void OnClickSelect1()
    {
        Select(0);
    }

    public void OnClickSelect2()
    {
        Select(1);
    }

    public void OnClickSelect3()
    {
        Select(2);
    }

    public void OnClickSelect4()
    {
        Select(3);
    }

    void Select(int deckNumber)
    {
        for (int deck = 0; deck < 4; deck++)
        {
            if (deck == deckNumber)
            {
                chosenDeck[deck].GetComponent<Image>().color = new Color32(100, 100, 100, 255);
                deckCharacter[4] = deckCharacter[deck];
                if (chosenDecknumber == 4)
                {
                    chosenSmall.GetComponent<Image>().sprite = characterSprites[deckCharacter[deck]];
                    chosenText.GetComponent<TMP_Text>().text = characterNames[deckCharacter[deck]];
                    chosenCharacter = deckCharacter[deck];
                }
            }
            else
            {
                chosenDeck[deck].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
        }
    }
}
