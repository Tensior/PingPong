using System;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

namespace Views.UI
{
    public class UIView : View
    {
        public event Action OnChooseBallColor;
        [SerializeField] private Button _chooseBallColor;
        [SerializeField] private ColorChoiceView _colorChoice;

        protected override void Awake()
        {
            base.Awake();
            
            _chooseBallColor.onClick.AddListener(() =>
            {
                OnChooseBallColor?.Invoke();
                _colorChoice.gameObject.SetActive(true);
                _chooseBallColor.interactable = false;
            });
            
            _colorChoice.OnColorChosen += color =>
            {
                _colorChoice.gameObject.SetActive(false);
                _chooseBallColor.interactable = true;
            };
        }
    }
}