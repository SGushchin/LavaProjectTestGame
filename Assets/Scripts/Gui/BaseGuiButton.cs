using UnityEngine;
using UnityEngine.UI;

namespace LavaGame
{
    public abstract class BaseGuiButton : MonoBehaviour
    {
        [Header("Debug private fields")]
        [SerializeField] protected Button _guiButton;
        [SerializeField] protected bool _guiButtonIsNull;


        protected virtual void Awake() =>
            _guiButtonIsNull = !TryGetComponent(out _guiButton);


        protected virtual void OnEnable() =>
            _guiButton.onClick.AddListener(ButtonClickHandler);


        protected virtual void OnDisable() =>
            _guiButton.onClick.RemoveListener(ButtonClickHandler);

        protected abstract void ButtonClickHandler();
    }
}