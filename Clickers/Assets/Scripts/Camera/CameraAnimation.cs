using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    [SerializeField] private List<SimpleTweenAnimation> animations = new List<SimpleTweenAnimation>();

    private void Start()
    {
        if(animations.Count > 0)
        {
            foreach (var a in animations)
            {
                a.Animate();
            }
        }
    }
}
