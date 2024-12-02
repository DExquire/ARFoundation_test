using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimController : MonoBehaviour
{
    public Button animButton;
    public Animator modelAnimator;

    public void SetButtonBehaviour()
    {
        if(modelAnimator != null)
        {
            animButton.onClick.RemoveListener(SwitchAnim);
            animButton.onClick.AddListener(SwitchAnim);
        }
    }

    public void SwitchAnim()
    {
        if (modelAnimator.GetBool("fly"))
        {
            modelAnimator.SetBool("fly", false);
        }
        else
        {
            modelAnimator.SetBool("fly", true);
        }
    }
}
