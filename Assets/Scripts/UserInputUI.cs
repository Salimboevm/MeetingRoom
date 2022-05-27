using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserInputUI : MonoBehaviour
{
    LinksContainer _linksContainer;
    [SerializeField]
    private TMP_InputField _colourChangingInput;
   

    private void Start()
    {
        _linksContainer = LinksContainer.Instance;
        _colourChangingInput.onEndEdit.AddListener(ChangeColour);
    }
    private void ChangeColour(string s)
    {
        _linksContainer.ColourApply.ChangeMaterialColour(_colourChangingInput.text);
    }
    public void SliderScaleChange(Slider slider)
    {
        _linksContainer.LengthChanger.SliderObjectScaler(slider);
        
    }
    public void Save()
    {
        _linksContainer.ObjectData.SaveAllData();
    }
    public void LoadData()
    {
        _linksContainer.ObjectData.LoadData();
    }
}
