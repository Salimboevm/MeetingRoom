using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    [SerializeField]
    private Material _originalMaterial;
    
    [SerializeField]
    private Color _defaultColour;
    public Action<string> Save;
    public void ChangeMaterialColour(string inputValue)
    {
        if (inputValue.Length.Equals(6))
            ApplyUpdatedMaterialColour(inputValue);
        else
            ApplyDefaultColour();
        Save(GetStringFromColour());
    }

    #region  Change Material Colour and Convert String to Hex
    private void ApplyUpdatedMaterialColour(string hexInput)
    {
        _originalMaterial.color = GetColorFromString(hexInput);
    }

    private Color GetColorFromString(string hexString)
    {
        float red = HexToFloatNormalized(hexString.Substring(0, 2));
        float green = HexToFloatNormalized(hexString.Substring(2, 2));
        float blue = HexToFloatNormalized(hexString.Substring(4, 2));

        return new Color(red, green, blue);
    }
    private float HexToFloatNormalized(string hex)
    {
        return HexToDec(hex) / 255f;
    }
    private int HexToDec(string hex)
    {
        int dec = Convert.ToInt32(hex, 16);
        return dec;
    }
    #endregion
    #region Colour to hex
    private string DecToHex(int value)
    {
        return value.ToString("X2");
    }
    private string FloatNormalizedToHex(float value)
    {
        return DecToHex(Mathf.RoundToInt(value * 255f));
    }
    public string GetStringFromColour()
    {
        string red = FloatNormalizedToHex(_originalMaterial.color.r);
        string green = FloatNormalizedToHex(_originalMaterial.color.g);
        string blue = FloatNormalizedToHex(_originalMaterial.color.b);
        return red + green + blue;
    }
    #endregion
    private void ApplyDefaultColour()
    {
        _originalMaterial.color = _defaultColour;
    }
}
