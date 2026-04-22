using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CardGame : MonoBehaviour
{
    public List<Card> cards;
    public List<Sprite> sprites;

    private Card firstCard = null;
    private Card secondCard = null;
    private bool isChecking = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartGame();

    }

    private void StartGame()
    {
        List<int> randomPairNum = GeneratePairNum(cards.Count);

        int loopCount = Mathf.Min(cards.Count, randomPairNum.Count);

        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].SetCardNum(randomPairNum[i]);
        }
        if (cards.Count > randomPairNum.Count)
        {

        }
    }

    private void CheckCard()
    {
        isChecking = true;

        if(firstCard.cardNum == secondCard.cardNum)
        {

            firstCard.isMatched = true;
            secondCard.isMatched = true;

            firstCard.ChangeColor(Color.yellow);
            secondCard.ChangeColor(Color.yellow);

            firstCard = null;
            secondCard = null;

            isChecking = false;
        }
        else
        {
            Invoke("HideCard", 2.0f);
        }
    }
    private void HideCard()
    {
        firstCard.isFront = false;
        secondCard.isFront = false;

        isChecking = false;

        firstCard = null;
        secondCard= null;
    }

    public void OnClickCard(Card Card)
    {
        if (isChecking)
        {
            return;
        }
        if (firstCard == null)
        {
            firstCard = Card;
            firstCard.Flip(true);
        }
        else
        {
            secondCard = Card;
            secondCard.Flip(true);
        }

        if(firstCard != null && secondCard != null)
        {
            CheckCard();
        }
    }

    // Update is called once per frame
    private List<int> GeneratePairNum(int cardCount)
    {
        int pairCount = cardCount / 2;
        List<int> newCardNum = new List<int>();

        for(int i = 0; i < pairCount; i++)
        {
            newCardNum.Add(i);
            newCardNum.Add(i);
        }


        // [0] [0] [1] [1] [2] [2] [3] [3] [4] [4]

        for(int i = newCardNum.Count -1; i > 0; i--)
        {
            int rnd = Random.Range(0, i + 1);
            int temp = newCardNum[i];
            newCardNum[i] = newCardNum[rnd];
            newCardNum[rnd] = temp;

        }

        return newCardNum;
    }
}
