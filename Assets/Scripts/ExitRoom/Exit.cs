using UnityEngine;

public class Exit : MonoBehaviour
{
    private Transform card;

    void Start()
    {
        var hands = GameObject.FindWithTag("Player").transform.Find("Hands");
        card = hands.Find("Card");
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
}
