using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Formulas : MonoBehaviour
{
    public string MinDamage, MaxDamage, WeaponSpeed, MinExtra, MaxExtra, Strength, AttackPower;
    public GameObject MainHandDPS, OffHandDPS;
    private float minDamage, maxDamage, weaponSpeed, minExtra, maxExtra, strength, attackPower, resultMainHand, resultOffHand;
    public bool FlatPlusExtraDPS;

    //TODO Enchantments
    //TODO Clear Function
    
    private void Update()
    {
        //Update Input field values
        MinDamage = GameObject.Find("MainHandMinDamageInput").GetComponent<TMP_InputField>().text;
        MaxDamage = GameObject.Find("MainHandMaxDamageInput").GetComponent<TMP_InputField>().text;
        WeaponSpeed = GameObject.Find("MainHandWeaponSpeedInput").GetComponent<TMP_InputField>().text;
        Strength = GameObject.Find("MainHandStrengthInput").GetComponent<TMP_InputField>().text;
        AttackPower = GameObject.Find("MainHandAttackPowerInput").GetComponent<TMP_InputField>().text;
        MinExtra = GameObject.Find("MainHandMinExtraDamageInput").GetComponent<TMP_InputField>().text;
        MaxExtra = GameObject.Find("MainHandMaxExtraDamageInput").GetComponent<TMP_InputField>().text;
        MainHandDPS = GameObject.Find("MainHandDPS");
        OffHandDPS = GameObject.Find("OffHandDPS");
        
        //Update Bool values
        FlatPlusExtraDPS = GameObject.Find("MainHandExtraDamageDPSBool").GetComponent<Toggle>().isOn;
        
        //Hitting Enter while in an input field Calculates
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Calculate();
        }
    }

    public void Calculate()
    {
        //Converting strings to floats
        float.TryParse(MinDamage, out minDamage);
        float.TryParse(MaxDamage, out maxDamage);
        float.TryParse(WeaponSpeed, out weaponSpeed);
        float.TryParse(Strength, out strength);
        float.TryParse(AttackPower, out attackPower);
        float.TryParse(MinExtra, out minExtra);
        float.TryParse(MaxExtra, out maxExtra);
        
        //Converting Strength to Attack Power
        attackPower += (strength * 2);
        
        //Enchantment Code
        
        //Weapon Has Extra Damage
        if (FlatPlusExtraDPS)
        {
            resultMainHand = (((minDamage + maxDamage + minExtra + maxExtra) / 2) / weaponSpeed) + (attackPower / 14);
            resultOffHand = ((((minDamage + maxDamage + minExtra + maxExtra) / 2) / weaponSpeed) + (attackPower / 14)) / 2;
        }
        else
        {
            resultMainHand = (((minDamage + maxDamage) / 2) / weaponSpeed) + (attackPower / 14);
            resultOffHand = ((((minDamage + maxDamage) / 2) / weaponSpeed) + (attackPower / 14)) / 2;
        }

        MainHandDPS.GetComponent<TextMeshProUGUI>().text = resultMainHand.ToString("#.00") + " DPS";
        OffHandDPS.GetComponent<TextMeshProUGUI>().text = resultOffHand.ToString("#.00") + " DPS";
        
        Debug.Log("Main Hand Result: " + resultMainHand);
        Debug.Log("Off Hand Result: " + resultOffHand);
    }

    public void ClearAll()
    {
        //Sets all UI Text Inputs to 0 or null
    }
}