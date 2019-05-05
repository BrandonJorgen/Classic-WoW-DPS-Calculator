using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Formulas : MonoBehaviour
{
    public string MinDamage, MaxDamage, WeaponSpeed, MinExtra, MaxExtra, Strength, AttackPower;
    private float minDamage, maxDamage, weaponSpeed, minExtra, maxExtra, strength, attackPower, result;
    public bool FlatWeaponDPS, FlatPlusExtraDPS;

    private void Update()
    {
        //Update Input field values
        MinDamage = GameObject.Find("MinDamageInput").GetComponent<TMP_InputField>().text;
        MaxDamage = GameObject.Find("MaxDamageInput").GetComponent<TMP_InputField>().text;
        WeaponSpeed = GameObject.Find("WeaponSpeedInput").GetComponent<TMP_InputField>().text;
        Strength = GameObject.Find("StrengthInput").GetComponent<TMP_InputField>().text;
        AttackPower = GameObject.Find("AttackPowerInput").GetComponent<TMP_InputField>().text;
        MinExtra = GameObject.Find("MinExtraDamageInput").GetComponent<TMP_InputField>().text;
        MaxExtra = GameObject.Find("MaxExtraDamageInput").GetComponent<TMP_InputField>().text;
        
        //Update Bool values
        FlatWeaponDPS = GameObject.Find("FlatWeaponDPSBool").GetComponent<Toggle>().isOn;
        FlatPlusExtraDPS = GameObject.Find("FlatPlusExtraDamageDPSBool").GetComponent<Toggle>().isOn;
    }

    public void Calculate()
    {
        //Converting strings to int
        float.TryParse(MinDamage, out minDamage);
        float.TryParse(MaxDamage, out maxDamage);
        float.TryParse(WeaponSpeed, out weaponSpeed);
        float.TryParse(Strength, out strength);
        float.TryParse(AttackPower, out attackPower);
        float.TryParse(MinExtra, out minExtra);
        float.TryParse(MaxExtra, out maxExtra);
        
        //Converting Strength to Attack Power
        attackPower += (strength * 2);
        
        //Depending on what bools are checked, clicking this button will do the appropriate formula
        //
        if (FlatWeaponDPS)
        {
           result = ((minDamage + maxDamage) / 2) / weaponSpeed;
        }

        if (FlatPlusExtraDPS)
        {
            result = ((minDamage + maxDamage + minExtra + maxExtra) / 2) / weaponSpeed;
        }
        
        Debug.Log(result);
    }
}