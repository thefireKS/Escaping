using UnityEngine;

public class Exit : MonoBehaviour
{
    private Transform card;
    private SpriteRenderer StateManager;
    [SerializeField]
    private Sprite Eye, Inter;
    public bool CardInInventory = false;
    void Start()
    {
        var hands = GameObject.FindWithTag("Player").transform.Find("Hands");
        card = hands.Find("Card");
        StateManager = GetComponent<SpriteRenderer>();
    }
    private void OnEnable() => CardInteraction.cardInInventory += ActivateInventorySlot;

    private void OnDisable() => CardInteraction.cardInInventory -= ActivateInventorySlot;
    private void ActivateInventorySlot()
    {
        CardInInventory = true;
    }
    public System.Collections.IEnumerator Banish(SpriteRenderer Target)
    {
        float delta = 0.1f;
        while (Target.color.a > 0)
        {
            yield return new WaitForSeconds(1f);

            Color newColor = Target.color;
            newColor.a -= delta;
            Target.color = newColor;
            Target.transform.position = new Vector3(transform.position.x, Target.transform.position.y, Target.transform.position.z);
        }
    }
    public void TryOpen()
    {
        if (!card.gameObject.activeSelf) return;
       
        StartCoroutine(Open());
    }
    public System.Collections.IEnumerator Open()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<Interaction>().StateActivation("Opening");
        yield return StartCoroutine(Banish(GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>()));

        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
    public void Switcher()
    {
        if (CardInInventory) StateManager.sprite= Inter;
        else StateManager.sprite= Eye;
    }

}
