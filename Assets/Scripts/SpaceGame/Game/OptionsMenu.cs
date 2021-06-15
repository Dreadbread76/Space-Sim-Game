using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class OptionsMenu : MonoBehaviour
{

    #region SetResolution
    public Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    

    private void Start()
    {
        //Get monitor resolution
        resolutions = Screen.resolutions;
        //empty drop down
        resolutionDropdown.ClearOptions();

        //Create a list of string
        List<string> options = new List<string>();
        //Current Resolution Index
        int currentResolutionIndex = 0;
        //loop through and create option for the list
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);

    }
    #endregion
}
