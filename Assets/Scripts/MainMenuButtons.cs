using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] GameObject mainMenuButtons;
    [SerializeField] GameObject deckEditorButtons;

    public void OnClickNewGame()
    {
        Debug.Log("Clicked on New Game");
    }

    public void OnClickLoadGame()
    {
        Debug.Log("Clicked on Load Game");
    }

    public void OnClickDecks()
    {
        Debug.Log("Clicked on Decks");

        mainMenuButtons.gameObject.SetActive(false);
        deckEditorButtons.gameObject.SetActive(true);
    }

    public void OnClickOptions()
    {
        Debug.Log("Clicked on Options");
    }

    public void OnClickNewDeck()
    {
        Debug.Log("Clicked on New Deck");

        SceneManager.LoadScene("DeckEditor");
    }

    public void OnClickEditDeck()
    {
        Debug.Log("Clicked on Edit Deck");
    }

    public void OnClickBack()
    {
        Debug.Log("Clicked on Back");

        mainMenuButtons.gameObject.SetActive(true);
        deckEditorButtons.gameObject.SetActive(false);
    }
}
