using System.Collections;
using System.Collections.Generic;
using CardSorting.UI.Gameplay;
using CardSorting.Utils;
using UnityEngine;
using DG.Tweening;
public class CardEntityHolder : MonoBehaviour
{
    public RectTransform startPoint;
    public RectTransform endPoint;
    public RectTransform controlPoint;

    public CubicBezier bezier;
    
    public List<CardEntity> cardEntities;
    [HideInInspector]public TableEntity tableEntity;


    public void Initialize(List<CardEntity> cardEntities)
    {
        this.cardEntities = cardEntities;
        bezier = new CubicBezier(startPoint.anchoredPosition, endPoint.anchoredPosition, controlPoint.anchoredPosition);
        for (int i = 0; i < cardEntities.Count; i++)
        {
            CardEntity cardEntity = cardEntities[i];
            RectTransform cardEntityRect = cardEntity.GetComponent<RectTransform>();
            Vector2 newPos = bezier.Solve(i / (float) (cardEntities.Count -1));
            float angle = bezier.SolveTangent(i / (float) (cardEntities.Count -1));
            
            cardEntityRect.SetParent(transform);
            cardEntityRect.DOLocalMove(newPos, 2).SetDelay(i * 0.2f);
            cardEntityRect.DOLocalRotate(new Vector3(0, 85, 0), 1).OnComplete(
                () =>
                {
                    cardEntity.backSide.SetActive(false);
                    cardEntity.frontSide.SetActive(true);
                    cardEntityRect.DOLocalRotate(new Vector3(0, 0, angle), 1);
                }
            ).SetDelay(i * 0.2f);;
        }
    }
    

}
