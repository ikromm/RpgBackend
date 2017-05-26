using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class DynamicCanvasScaler : CanvasScaler {

    protected override void Start()
    {
        base.Start();

        AdjustSettings();
    }

    protected override void Update()
    {
        AdjustSettings();
        
        base.Update();
    }

    private void AdjustSettings()
    {
        float baseAspectRatio = referenceResolution.x / referenceResolution.y;
        float currentAspectRatio = (float)Screen.width / Screen.height;

        this.matchWidthOrHeight = baseAspectRatio < currentAspectRatio ? 1 : 0;
    }
}
