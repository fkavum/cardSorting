using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class LoadingAnimationScreen : MonoBehaviour
{
    [SerializeField] private Image _topImage;
    [SerializeField] private Image _bottomImage;
    [SerializeField] private bool isClosedAtStart = false;
    public float animationTime = 1f;
    [HideInInspector] public bool isAnimating = false;
    private void Start()
    {
        if (isClosedAtStart)
        {
            _topImage.fillAmount = .51f;
            _bottomImage.fillAmount = .51f;
            _topImage.gameObject.SetActive(true);
            _bottomImage.gameObject.SetActive(true);
            
            Open();
        }
        else
        {
            _topImage.fillAmount = 0;
            _bottomImage.fillAmount = 0;
            _topImage.gameObject.SetActive(false);
            _bottomImage.gameObject.SetActive(false);
        }
    }

    public void Close()
    {
        _topImage.gameObject.SetActive(true);
        _bottomImage.gameObject.SetActive(true);
        isAnimating = true;
        DOTween.To(()=> _topImage.fillAmount, x => _topImage.fillAmount = x, 0.51f, animationTime).SetEase(Ease.Linear);
        DOTween.To(()=> _bottomImage.fillAmount, x => _bottomImage.fillAmount = x, 0.51f, animationTime).OnComplete( ()=>
        {
            isAnimating = false;
        }).SetEase(Ease.Linear);
    }
    
    public void Open()
    {
        _topImage.gameObject.SetActive(true);
        _bottomImage.gameObject.SetActive(true);
        
        isAnimating = true;
        DOTween.To(()=> _topImage.fillAmount, x => _topImage.fillAmount = x, 0, animationTime).SetEase(Ease.Linear);
        DOTween.To(()=> _bottomImage.fillAmount, x => _bottomImage.fillAmount = x, 0, animationTime).OnComplete( ()=>
        {
            isAnimating = false;
            _topImage.gameObject.SetActive(false);
            _bottomImage.gameObject.SetActive(false);
        }).SetEase(Ease.Linear);
    }
    
}
