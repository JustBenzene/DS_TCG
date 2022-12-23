using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenuButtons;
    [SerializeField] GameObject deckEditorButtons;

    [SerializeField] GameObject buttons;
    [SerializeField] GameObject title;

    [SerializeField] GameObject deleteDeck1;
    [SerializeField] GameObject deleteDeck2;
    [SerializeField] GameObject deleteDeck3;

    [SerializeField] GameObject[] buttonList1;
    [SerializeField] GameObject[] buttonList2;
    [SerializeField] GameObject[] buttonList3;
    [SerializeField] GameObject[] buttonList4;
    [SerializeField] GameObject[] deleteButtons;

    [SerializeField] GameObject areYouSure;

    private void Start()
    {
        float temp = 875 + (0.75f - GameManager.aspectRatio) * 1700f;
        title.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, temp);

        temp = 650 + (0.75f - GameManager.aspectRatio) * 1400f;
        buttons.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, temp);
        
        float temp1 = 3 + (0.75f - GameManager.aspectRatio) * 2.5f;
        float temp2 = 130 + (0.75f - GameManager.aspectRatio) * 100f;
        float temp3 = 300 + (0.75f - GameManager.aspectRatio) * 180f;
        foreach (GameObject button in buttonList1)
        {
            button.GetComponent<RectTransform>().localScale = new Vector3(temp1, temp1);
        }
        foreach (GameObject button in buttonList2)
        {
            button.GetComponent<RectTransform>().localScale = new Vector3(temp1, temp1);
            button.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -temp2);
        }
        foreach (GameObject button in buttonList3)
        {
            button.GetComponent<RectTransform>().localScale = new Vector3(temp1, temp1);
            button.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -temp2 * 2);
        }
        foreach (GameObject button in buttonList4)
        {
            button.GetComponent<RectTransform>().localScale = new Vector3(temp1, temp1);
            button.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -temp2 * 3);
        }
        foreach (GameObject button in deleteButtons)
        {
            button.GetComponent<RectTransform>().anchoredPosition = new Vector2(temp3, button.GetComponent<RectTransform>().anchoredPosition.y);
        }
        
        if (GameManager.lastMenuPage == 1)
        {
            SetUpDeckEditor();
        }
    }

    public void OnClickNewGame()
    {
        
    }

    public void OnClickLoadGame()
    {
        
    }

    public void OnClickOptions()
    {
        
    }

    public void OnClickDeckEditor()
    {
        SetUpDeckEditor();
    }

    public void OnClickBack()
    {
        deckEditorButtons.SetActive(false);
        mainMenuButtons.SetActive(true);
    }

    public void OnClickDeck1()
    {
        OpenDeck(1);
    }

    public void OnClickDeck2()
    {
        OpenDeck(2);
    }

    public void OnClickDeck3()
    {
        OpenDeck(3);
    }

    public void OnClickDelete1()
    {
        DeleteDeck(1);
    }

    public void OnClickDelete2()
    {
        DeleteDeck(2);
    }

    public void OnClickDelete3()
    {
        DeleteDeck(3);
    }

    public void OnClickYes()
    {
        PlayerPrefs.SetString("Deck" + GameManager.deckNumber.ToString() + "Empty", "True");

        SetUpDeckEditor();

        areYouSure.SetActive(false);
        deckEditorButtons.SetActive(true);
    }

    public void OnClickNo()
    {
        areYouSure.SetActive(false);
        deckEditorButtons.SetActive(true);
    }

    public void SetUpDeckEditor()
    {
        mainMenuButtons.SetActive(false);

        GameObject[] list = new GameObject[] { deleteDeck1, deleteDeck2, deleteDeck3 };
        for (int temp = 0; temp <= 2; temp++)
        {
            if (PlayerPrefs.GetString("Deck" + (temp + 1).ToString() + "Empty") == "False")
            {
                list[temp].GetComponent<Button>().interactable = true;
            }
            else
            {
                list[temp].GetComponent<Button>().interactable = false;
            }
        }

        deckEditorButtons.SetActive(true);
    }

    public void DeleteDeck(int number)
    {
        GameManager.deckNumber = number;

        deckEditorButtons.SetActive(false);
        areYouSure.SetActive(true);
    }

    public void OpenDeck(int number)
    {
        GameManager.deckNumber = number;
        GameManager.lastMenuPage = 1;
        SceneManager.LoadScene("DeckEditor");
    }
}
