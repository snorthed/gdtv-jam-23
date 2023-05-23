using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SliderDisplay : MonoBehaviour
    {
        public enum TextDisplayMode
        {
            SingleValue,
            Percentage,
            OutOf,
        }
        [SerializeField] private TMP_Text _sliderValueText;
        [SerializeField] private Slider _slider;
        [SerializeField] private TextDisplayMode displayMode;


        [field:SerializeField] public float MaxValue { get; set; }

        public void Awake()
        {
            if(_slider != null) _slider.maxValue = MaxValue;
        }

        public void SetToMax()
        {
            SetValues(0f,MaxValue);
        }

        public void SetValues(float amountChanged, float newValue)
		{
			if (_slider != null) _slider.value = newValue;

			switch (displayMode)
            {
                case TextDisplayMode.SingleValue:
                {
                    _sliderValueText.text = newValue.ToString("##0");
                    break;
                }
                case TextDisplayMode.Percentage:
                {
                    var percentageValue = (newValue / MaxValue) * 100f;
                    _sliderValueText.text = newValue.ToString("#00%");
                    break;
                }
                case TextDisplayMode.OutOf:
                {
                    _sliderValueText.text = $"{newValue:#00} / {MaxValue:#00}";
                    break;
                }
                default: throw new ArgumentOutOfRangeException();
            }
		}
    }
}
