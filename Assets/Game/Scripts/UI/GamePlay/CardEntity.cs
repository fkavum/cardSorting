using CardSorting.GamePlay;
using CardSorting.Scriptable;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CardSorting.UI.Gameplay
{
    public class CardEntity : MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler,IDropHandler, IPointerUpHandler,IPointerEnterHandler
    {
        public GameObject backSide;
        public GameObject frontSide;
        public Image frontImage;
        public Image backImage;

        
        [HideInInspector]public CardEntityHolder holder;
        [HideInInspector]public CardConfig cardConfig;
        public Card card;

        private RectTransform _rectTransform;
        private Canvas _canvas;
        private CanvasGroup _canvasGroup;
        private void Start()
        {
            
            _rectTransform = GetComponent<RectTransform>();
            _canvas = GetComponentInParent<Canvas>();
            _canvasGroup = GetComponent<CanvasGroup>();
            if (_canvasGroup == null)
                _canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if(!holder) return;
            _canvasGroup.blocksRaycasts = false;
            holder.PickCard(this);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if(!holder) return;
            Vector2 delta = eventData.delta;
            if (!IsInSafeArea())
            {
                delta.y = 0f;
                delta.x = 0f;
            }
            _rectTransform.anchoredPosition += delta / _canvas.scaleFactor;
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            if(!holder) return;
            _canvasGroup.blocksRaycasts = true;
            
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            if(!holder) return;
            holder.PickCard(this);
            Debug.Log($"You pressed {cardConfig.cardType.ToString()} - {cardConfig.cardNumber}");
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            if(!holder) return;
            holder.pickedCard = null;
            holder.FixPlacement();
            _rectTransform.DOScale(2f, .1f);
        }
        public void OnDrop(PointerEventData eventData)
        {
            if(!holder) return;
            if (eventData.pointerDrag != null)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = _rectTransform.anchoredPosition;
            }
        }


        public void OnPointerEnter(PointerEventData eventData)
        {
            if(!holder) return;
            holder.HoverOver(this);
        }

        public bool IsInSafeArea()
        {
            float pointerHeight = Input.mousePosition.y / Screen.height;
            if (pointerHeight > .4f)
            {
                return false;
            }
            return true;
        }
    }
}