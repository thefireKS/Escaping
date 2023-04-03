using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform door;
    private Transform key;

    private bool isNextToTheDoor;
    void Start()
    {
        var hands = GameObject.FindWithTag("Player").transform.Find("Hands");
        key = hands.Find("Key");
    }

    private void Update()
    {
        if(!isNextToTheDoor) return;
        if(!key.gameObject.activeSelf) return;
        
        if(!Input.GetKey(KeyCode.E)) return;
        door.gameObject.SetActive(false);
        Destroy(this);
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
