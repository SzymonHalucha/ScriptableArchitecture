using UnityEngine;
using UnityEngine.Events;
using SH.ScriptableArchitecture.Events;

namespace SH.ScriptableArchitecture.Listeners
{
    public class ScriptableEventListener : MonoBehaviour
    {
        [SerializeField] private ScriptableEvent scriptableEvent;
        [SerializeField] private UnityEvent onEvent;

        private void OnEnable()
        {
            scriptableEvent.AddListener(OnEventInvoked);
        }

        private void OnDisable()
        {
            scriptableEvent.RemoveListener(OnEventInvoked);
        }

        public void OnEventInvoked()
        {
            onEvent.Invoke();
        }
    }
}
