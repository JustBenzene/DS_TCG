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
    [SerializeField] GameObject chosen2;
    [SerializeField] Sprite[] characterSprites;

    [SerializeField] GameObject[] lines;

    int number;

    private void Start()
    {
        float temp = 718f + (GameManager.aspectRatio - 1.334545f) * 797f * 1.004405f;
        middle.GetComponent<RectTransform>().sizeDelta = new Vector2(800, temp);

        number = GameManager.deckNumber;
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
        chooseCharacter.SetActive(true);
    }

    public void OnClickChosen()
    {
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

    void characterChosen(int character)
    {
        chosen.GetComponent<Image>().sprite = characterSprites[character];
        chosen2.GetComponent<Image>().sprite = characterSprites[character];
    }
}
