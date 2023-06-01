using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AnimGifUI : MonoBehaviour
{
    public Sprite[] frame;
    public float framePerSecond = 15f;
    public bool loop = false;
    private bool ended = true;
    private Image render = null;
    private float startTime;

    void Awake()
    {
        render = GetComponent<Image>();
        startTime = Time.time;
    }

    public IEnumerator PlayAnimation(Sprite[] GIF)
    {
        frame = GIF;
        startTime = Time.time;
        ended = false;
        yield return new WaitForSeconds(GIF.Length / framePerSecond);
        if (loop)
        {
            StartCoroutine(PlayAnimation(GIF));
        }
        else
        {
            ended = true;
        }
    }

    void Update()
    {

        if (ended || frame.Length == 0) return;
        float index = (Time.time - startTime) * framePerSecond;
        index = Mathf.Clamp(index, 0, frame.Length - 1);
        if (index == 0 && ended) { ended = true; }
        if (render != null)
        {
            render.sprite = frame[Mathf.FloorToInt(index)];
        }
    }
}
