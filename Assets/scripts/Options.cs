using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class Options : MonoBehaviour
{
    [SerializeField] Slider vol; 
    public AudioMixer mixer;
   

    public Toggle fullScreenTog; 

    private int selectedRes; 

    public TMP_Text resolutionLabel; 

    public List<ResItem> resolutions = new List<ResItem>(); 


    // Start is called before the first frame update
    void Start()
    {
        
         vol.onValueChanged.AddListener(SetLevel); 

         fullScreenTog.isOn =  Screen.fullScreen; 

        bool foundRes = false; 

        for(int i = 0;  i < resolutions.Count; i++) {
            if(Screen.width == resolutions[i].horizontal && Screen.height ==  resolutions[i].vertical){
                foundRes = true; 

                selectedRes = i; 

                updateRes(); 
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void SetLevel (float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }

    public void ResLeft() {

        
         selectedRes--; 

        if(selectedRes < 0) {
            selectedRes = 0; 
        }
       

        updateRes(); 
    }

    public void ResRight() {
        selectedRes++; 

        if(selectedRes > resolutions.Count - 1) {
            selectedRes = resolutions.Count - 1; 
        }

        updateRes(); 
    }

    public void updateRes() {
        Debug.Log(selectedRes); 
        resolutionLabel.text = resolutions[selectedRes].horizontal.ToString() + "x" + resolutions[selectedRes].vertical.ToString();  
    }
 
    public void applyGraphics(){
       // Screen.fullScreen = fullScreenTog.isOn; 

        Screen.SetResolution(resolutions[selectedRes].horizontal, resolutions[selectedRes].vertical, fullScreenTog.isOn); 
        
    }

}

[System.Serializable]

public class ResItem {
    public int horizontal; 
    public int vertical; 
}
