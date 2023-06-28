using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePassthrough : MonoBehaviour
{
    public Material newSkyboxMaterial;
    public GameObject Enviroment;
    bool skyboxEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            skyboxEnabled = !skyboxEnabled;
            if (skyboxEnabled)
            {
                RenderSettings.skybox = newSkyboxMaterial;
                Enviroment.SetActive(true);
            }
            else
            {
                RenderSettings.skybox = null;
                Enviroment.SetActive(false);
            }
        }
    }
}
