using UnityEngine;
using UnityEngine.UI;

public class IconSlider : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite[] _sprite;
    [SerializeField] private Slider _slider;
    void Start()
    {
        _slider = GetComponent<Slider>();
    }

    void Update()
    {
        if(_slider.value == 0)
        {
            _image.sprite = _sprite[1];
        }
        else
        {
            _image.sprite = _sprite[0];
        }
    }
}
