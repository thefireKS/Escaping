using System;
using TMPro;
using UnityEngine;

public class CoffeeCode : MonoBehaviour
{
    [SerializeField] private GameObject cup;
    [SerializeField] private GameObject coffeeStream;
    [SerializeField] private GameObject wrongCoffeeStream;
    [SerializeField] private float cupDelay;
    [Space(5)]
    [SerializeField] private TMP_Text message;

    private const string TrueCode = "5738";
    private string currentCode = "";

    private float cupTimer = 0f;
    private bool shouldCount;
    
    public static Action machineIsBroken;
    
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
        cup.gameObject.SetActive(false);
        coffeeStream.SetActive(false);
        message.text = "Слишком горячий!";
        if (currentCode != TrueCode) return;
        wrongCoffeeStream.SetActive(true);
        message.text = "Ошибка!";
        machineIsBroken?.Invoke();
        Destroy(this);
    }

    private void dropCup()
    {
        cup.SetActive(true);
        coffeeStream.SetActive(true);
        shouldCount = false;
    }

    private void Update()
    {
        if(!shouldCount) return;
        cupTimer += Time.deltaTime;
        if(cupTimer > cupDelay)
            dropCup();
    }
}
