using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Image), typeof(BoxCollider2D), typeof(AnimGifUI))]
public class InteractionUI : MonoBehaviour
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
    [SerializeField] private State[] States;
    [SerializeField] private State currentState;
    private bool inProcess = false;
    private AnimGifUI GIFAnimator;

    private void Awake()
    {
        GIFAnimator = GetComponent<AnimGifUI>();
        
        if(currentState.KeyName != null) StateActivation(currentState);

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
        foreach (State current in States)
        {
            if (current.Tag == Tags.OnClick) StateActivation(current);
        }
    }
}