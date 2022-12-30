using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public DeckEditor deckEditor;
    public int cardNumber;
    public int cardType;

    public void OnClick()
    {
        deckEditor.OnClickCard(cardNumber, cardType);
    }
}
