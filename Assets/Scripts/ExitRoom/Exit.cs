using UnityEngine;

public class Exit : MonoBehaviour
{
    private Transform card;

    private bool isNextToTheDoor;
    void Start()
    {
        var hands = GameObject.FindWithTag("Player").transform.Find("Hands");
        card = hands.Find("Card");
    }
    
    private void Update()
    {
        if(!isNextToTheDoor) return;
        if(!card.gameObject.activeSelf) return;
        
        if(!Input.GetKey(KeyCode.E)) return;
        Debug.Log("Victory!");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.CompareTag("Player")) return;
        isNextToTheDoor = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isNextToTheDoor = false;
    }
}
