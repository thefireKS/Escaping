using System;
using UnityEngine;

public class CoffeeCode : MonoBehaviour
{
    [SerializeField] private GameObject cup;
    [SerializeField] private GameObject falsecup;
    [SerializeField] private GameObject coffeeStream;
    [SerializeField] private float cupDelay;
    [Space(5)]
    private InteractionUI selfStatemanager;
    private InteractionUI cupStatemanager;
    private InteractionUI falsecupStatemanager;
    private InteractionUI streamStatemanager;
    private const string TrueCode = "5738";
    private string currentCode = "";

    private float cupTimer = 0f;
    private bool shouldCount;

    public static Action machineIsBroken;
    public UnityEngine.Events.UnityEvent machineIsBrokening;
    private void Awake()
    {
        selfStatemanager = GetComponent<InteractionUI>();
        cupStatemanager = cup.GetComponent<InteractionUI>();
        streamStatemanager = coffeeStream.GetComponent<InteractionUI>();
        falsecupStatemanager = falsecup.GetComponent<InteractionUI>();
    }
    public void AddNumberToCode(int num)
    {
        currentCode += num.ToString();

        if (currentCode.Length > 4)
        {
            currentCode = "";
            currentCode += num.ToString();
        }

        cupTimer = 0f;
        shouldCount = true;

        Debug.Log(currentCode);
    }

    public void BreakMachine()
    {
        cup.SetActive(false);
        falsecup.SetActive(true);
        falsecupStatemanager.StateActivation("Throw");
        if (currentCode != TrueCode)
        {
            selfStatemanager.StateActivation("Warning");
            streamStatemanager.StateActivation("Null");
            currentCode = "";
            return;
        }
        selfStatemanager.StateActivation("Error");
        machineIsBroken?.Invoke();
        machineIsBrokening?.Invoke();
        coffeeStream.transform.localScale *= 2;
        streamStatemanager.ForceStateActivation("EndlessPour");
        Destroy(this);
    }
    private void dropCup()
    {
        falsecup.SetActive(false);
        cup.SetActive(true);
        cupStatemanager.StateActivation("Init");
        StartCoroutine(Delay());

    }
    public System.Collections.IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        streamStatemanager.StateActivation("Pour");
        shouldCount = false;
    }
    private void Update()
    {
        if (!shouldCount) return;
        cupTimer += Time.deltaTime;
        if (cupTimer > cupDelay)
            dropCup();
    }
}