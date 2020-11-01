using System;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

namespace Views.UI
{
    public class ColorChoiceView : View
    {
        public event Action<Color> OnColorChosen;
        [SerializeField] private Color[] _colors;
        [SerializeField] private Button _colorButtonPrefab;

        protected override void Awake()
        {
            base.Awake();
            foreach (var color in _colors)
            {
                var button = Instantiate(_colorButtonPrefab, transform);
                button.image.color = color;
                button.onClick.AddListener(() => OnColorChosen?.Invoke(color));
            }
        }
    }
}