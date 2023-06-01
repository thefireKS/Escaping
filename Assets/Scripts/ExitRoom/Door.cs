using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform door;
    private Transform key;
    [SerializeField] private UnityEngine.Events.UnityEvent m_WhenOpened;

    private bool isNextToTheDoor;
    void Start()
    {
        var hands = GameObject.FindWithTag("Player").transform.Find("Hands");
        key = hands.Find("Key");
    }

    public void CheckKey()
    {
        if(!key.gameObject.activeSelf) return;
        StartCoroutine(Delay());
        m_WhenOpened.Invoke();
        Destroy(this);
    }
    public System.Collections.IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.04f);
    }
}
