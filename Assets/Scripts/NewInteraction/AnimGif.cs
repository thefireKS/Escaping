using UnityEngine;
using System.Collections;

public class AnimGif : MonoBehaviour
{
    public Sprite[] frame;
    public float framePerSecond = 15f;
    public bool loop = false;
    private bool ended = true;
    [SerializeField] private SpriteRenderer render = null;
    private float startTime;

    void Awake()
    {
        if(render == null) render = GetComponent<SpriteRenderer>();
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
