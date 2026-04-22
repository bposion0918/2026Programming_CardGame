using UnityEngine;
using TMPro;


public class Card : MonoBehaviour
{
    public TextMeshProUGUI card;
    private int cardNum;
    public float rotateSpeed;
    public bool isClick = false;
    public Quaternion flipRotation = Quaternion.Euler(0, 180.0f, 0);
    public Quaternion originRotation = Quaternion.Euler(0, 0, 0);


    void Start()
    {
    }

    void Update()
    {
        if (isClick)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, flipRotation, rotateSpeed *  Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originRotation, rotateSpeed * Time.deltaTime);
        }
    }

    public void Clickcard()
    {
        isClick = !isClick;
    }

    public void SetCardNum(int newNum)
    {
        card = GetComponentInChildren<TextMeshProUGUI>();
        cardNum = newNum;

        card.text = cardNum.ToString();
    }
}
