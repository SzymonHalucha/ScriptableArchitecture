using UnityEngine;

namespace SH.ScriptableArchitecture.Editor
{
    public class GeneratorWindowData : ScriptableObject
    {
        [HideInInspector] public Object SelectedObject = null;
        [HideInInspector] public string DataPath = "Data/Architecture";
        [HideInInspector] public string ScriptPath = "Scripts/Architecture";
        [HideInInspector] public string Namespace = "Scripts.Architecture";
        [HideInInspector] public string ContextMenuPath = "Architecture";

        [HideInInspector]
        public string VariableTemplateScript =
@"using UnityEngine;
using SH.ScriptableArchitecture.Variables;

namespace %NAMESPACE%.Variables
{
    [CreateAssetMenu(menuName = ""%CONTEXTMENU%/Variables/%NAME%"", fileName = ""New %NAME% Variable"")]
    public class %NAME%Variable : BaseVariable<%NAME%>
    {
        
    }
}";

        [HideInInspector]
        public string EventTemplateScript =
@"using UnityEngine;
using SH.ScriptableArchitecture.Events;

namespace %NAMESPACE%.Events
{
    [CreateAssetMenu(menuName = ""%CONTEXTMENU%/Events/%NAME%"", fileName = ""New %NAME% Scriptable Event"")]
    public class %NAME%ScriptableEvent : ScriptableEventType1<%NAME%>
    {

    }
}";

        [HideInInspector]
        public string ListenerTemplateScript =
@"using SH.ScriptableArchitecture.Listeners;

namespace %NAMESPACE%.Listeners
{
    public class %NAME%ScriptableEventListener : ScriptableEventType1Listener<%NAME%>
    {

    }
}";
    }
}