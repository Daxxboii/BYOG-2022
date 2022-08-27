using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MyBox;

public class AnimatedAsset : MonoBehaviour
{
    public enum AssetType { Boulder}

    public AssetType Type;

    [Foldout("Boulder",true)]
    [SerializeField,MinMaxSlider(-5f,0f)] private Vector2 UpDownDeviation;
    [SerializeField,MinMaxSlider(0f, 3f)] private Vector2 TimeTaken;

    private void Start()
    {
        float position = transform.position.y;
        position -= Random.Range(UpDownDeviation.x, UpDownDeviation.y);
        if (Type == AssetType.Boulder) gameObject.transform.DOMoveY(position, Random.Range(TimeTaken.x, TimeTaken.y)).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InSine);
    }
}
