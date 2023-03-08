using UnityEngine;
using UnityEngine.Events;
using SH.ScriptableArchitecture.Events;

namespace SH.ScriptableArchitecture.Listeners
{
    public abstract class ScriptableEventType1Listener<T> : MonoBehaviour
    {
        [SerializeField] private ScriptableEventType1<T> scriptableEvent;
        [SerializeField] private UnityEvent<T> onEvent;

        private void OnEnable()
        {
            scriptableEvent.AddListener(OnEventInvoked);
        }

        private void OnDisable()
        {
            scriptableEvent.RemoveListener(OnEventInvoked);
        }

        public void OnEventInvoked(T argument)
        {
            onEvent.Invoke(argument);
        }
    }
}
