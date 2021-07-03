using UnityEngine;

public interface IClickable 
{
    bool IsClickable { get; set; }
    void Click();
}
