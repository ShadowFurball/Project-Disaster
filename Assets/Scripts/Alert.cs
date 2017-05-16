using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Alert : MonoBehaviour
{
    public delegate void OnComplete(Alert alert);
    public OnComplete onComplete;
}
