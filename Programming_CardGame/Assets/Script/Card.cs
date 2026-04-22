using UnityEngine;
using TMPro;


public class Card : MonoBehaviour
{
    public TextMeshProUGUI card;
    private string cardNum;

    void Start()
    {
        card = GetComponent<TextMeshProUGUI>();
        cardNum = Random.Range(0, 10).ToString();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0.0f, 20.0f, 0.0f) * Time.deltaTime);
    }
}
