using UnityEngine.Events;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D), typeof(AnimGif))]
public class Interaction : MonoBehaviour
{
    public enum Tags
    {
        None = 0,
        Transition = 1,
        ColliderEnter = 2,
        ColliderExit = 3,
        OnClick = 4,
        Unchangeable = 5
    }
    [System.Serializable]
    public struct State
    {
        public string KeyName;
        public Tags Tag;
        public string NextState;
        public Sprite[] Animation;
        public UnityEvent m_WhenStateActivated;
    }
    [SerializeField] private bool syncNeed = true;
    [SerializeField] private State[] States;
    [SerializeField] private State currentState;
    private bool inProcess = false;
    [SerializeField] private float delayBetweenStates = 0;
    private float delay = 0;
    private AnimGif GIFAnimator;

    private void Awake()
    {
        GIFAnimator = GetComponent<AnimGif>();
        gameObject.layer = 10;
        StartCoroutine(Sync());
        if(currentState.KeyName != null) StateActivation(currentState);

    }
    private void Update()
    {
        if (delayBetweenStates == 0) return;
        delay += Time.deltaTime;
    }
    public IEnumerator Sync()
    {
        yield return new WaitForSeconds(0.04f);
        if (transform.parent.localScale.x < 0 && syncNeed)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
    public void StateActivation(string nameTarget)
    {
        foreach (State current in States)
        {
            if (nameTarget.Equals(current.KeyName))
            {
                StateActivation(current);
            }
        }
    }
    public void StateActivation(State Target)
    {
        //Debug.Log(Target.KeyName + " - activation");
        if (inProcess || currentState.Tag == Tags.Unchangeable) return;
        inProcess = true;
        currentState = Target;
        Target.m_WhenStateActivated.Invoke();
        StartCoroutine(StateActivationAfterAnimation(Target));
    }

    private IEnumerator StateActivationAfterAnimation(State Target)
    {
        if (currentState.Tag == Tags.Unchangeable) GIFAnimator.loop = true;
        yield return StartCoroutine(GIFAnimator.PlayAnimation(Target.Animation));
        inProcess = false;
        if (Target.NextState != null)
        {
            foreach (State current in States)
            {
                if (Target.NextState.Equals(current.KeyName))
                {
                    StateActivation(current);
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (delay < delayBetweenStates && delayBetweenStates != 0) return;
        if (collision.CompareTag("Player"))
        {
            foreach (State current in States)
            {
                
                if (current.Tag == Tags.ColliderEnter) StateActivation(current);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (delay < delayBetweenStates && delayBetweenStates != 0) return;
        if (collision.CompareTag("Player"))
        {
            foreach (State current in States)
            {
                if (current.Tag == Tags.ColliderExit) StateActivation(current);
            }
        }
    }
    private void OnMouseDown()
    {
        if (delay < delayBetweenStates && delayBetweenStates != 0) return;
        foreach (State current in States)
        {
            if (current.Tag == Tags.OnClick) StateActivation(current);
        }
    }
    public void OnMouseDownCustom()
    {
        foreach (State current in States)
        {
            if (current.Tag == Tags.OnClick) StateActivation(current);
        }
    }
}