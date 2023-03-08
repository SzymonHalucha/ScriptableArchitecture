using System.IO;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace SH.ScriptableArchitecture.Editor
{
    public class GeneratorWindow : EditorWindow
    {
        private SerializedObject serializedData;

        [MenuItem("Tools/Scriptable Architecture Generator")]
        private static void OpenWindow()
        {
            GeneratorWindow window = GetWindow<GeneratorWindow>();
            window.titleContent = new GUIContent("Scriptable Architecture Generator");
            window.minSize = new Vector2(300f, 300f);
            window.Show();
        }

        private void CreateGUI()
        {
            string[] paths = AssetDatabase.FindAssets("t:SH.ScriptableArchitecture.Editor.GeneratorWindowData");
            GeneratorWindowData data = AssetDatabase.LoadAssetAtPath<GeneratorWindowData>(AssetDatabase.GUIDToAssetPath(paths[0]));
            serializedData = new SerializedObject(data);

            rootVisualElement.Add(CreateTitleLabel());
            rootVisualElement.Add(CreateObjectField());
            rootVisualElement.Add(CreateDataPathTextField());
            rootVisualElement.Add(CreateScriptPathTextField());
            rootVisualElement.Add(CreateNamespaceTextField());
            rootVisualElement.Add(CreateContextMenuPathTextField());
            rootVisualElement.Add(CreateSpacerField());
            rootVisualElement.Add(CreateGenerateVariableButtonField());
            rootVisualElement.Add(CreateGenerateEventButtonField());
            rootVisualElement.Add(CreateGenerateListenerButtonField());
            rootVisualElement.Add(CreateResetButtonField());
        }

        private VisualElement CreateTitleLabel()
        {
            Label label = new Label("Scriptable Architecture Generator");
            float padding = 8f;
            label.style.paddingTop = padding;
            label.style.paddingBottom = padding;
            label.style.paddingLeft = padding;
            label.style.paddingRight = padding;
            label.style.unityTextAlign = TextAnchor.MiddleCenter;
            label.style.fontSize = 20f;
            return label;
        }

        private ObjectField CreateObjectField()
        {
            ObjectField objectField = new ObjectField();
            objectField.value = serializedData.FindProperty("SelectedObject").objectReferenceValue;
            objectField.BindProperty(serializedData.FindProperty("SelectedObject"));
            objectField.objectType = typeof(Object);
            objectField.allowSceneObjects = false;
            objectField.label = "Selected Object";
            return objectField;
        }

        private VisualElement CreateDataPathTextField()
        {
            TextField textField = new TextField();
            textField.value = serializedData.FindProperty("DataPath").stringValue;
            textField.BindProperty(serializedData.FindProperty("DataPath"));
            textField.label = "Path for Data";
            return textField;
        }

        private VisualElement CreateScriptPathTextField()
        {
            TextField textField = new TextField();
            textField.value = serializedData.FindProperty("ScriptPath").stringValue;
            textField.BindProperty(serializedData.FindProperty("ScriptPath"));
            textField.label = "Path for Script";
            return textField;
        }

        private VisualElement CreateNamespaceTextField()
        {
            TextField textField = new TextField();
            textField.value = serializedData.FindProperty("Namespace").stringValue;
            textField.BindProperty(serializedData.FindProperty("Namespace"));
            textField.label = "Namespace";
            return textField;
        }

        private VisualElement CreateContextMenuPathTextField()
        {
            TextField textField = new TextField();
            textField.value = serializedData.FindProperty("ContextMenuPath").stringValue;
            textField.BindProperty(serializedData.FindProperty("ContextMenuPath"));
            textField.label = "Context Menu Path";
            return textField;
        }

        private VisualElement CreateSpacerField()
        {
            VisualElement spacer = new VisualElement();
            spacer.style.height = 8f;
            return spacer;
        }

        private VisualElement CreateGenerateVariableButtonField()
        {
            Button button = new Button();
            button.clicked += OnCreateVariableButtonClicked;
            button.text = "Generate Variable";
            return button;
        }

        private VisualElement CreateGenerateEventButtonField()
        {
            Button button = new Button();
            button.clicked += OnCreateEventButtonClicked;
            button.text = "Generate Event";
            return button;
        }

        private VisualElement CreateGenerateListenerButtonField()
        {
            Button button = new Button();
            button.clicked += OnCreateListenerButtonClicked;
            button.text = "Generate Listener";
            return button;
        }

        private VisualElement CreateResetButtonField()
        {
            Button button = new Button();
            button.clicked += OnResetButtonClicked;
            button.text = "Reset";
            return button;
        }

        private void OnResetButtonClicked()
        {
            serializedData.FindProperty("SelectedObject").objectReferenceValue = null;
            serializedData.FindProperty("DataPath").stringValue = "Data/Architecture";
            serializedData.FindProperty("ScriptPath").stringValue = "Scripts/Architecture";
            serializedData.FindProperty("Namespace").stringValue = "Scripts.Architecture";
            serializedData.FindProperty("ContextMenuPath").stringValue = "Architecture";
            serializedData.ApplyModifiedProperties();
        }

        private (string ScriptPath, string DataPath, string ObjectName) GetPaths()
        {
            string scriptPath = $"{Application.dataPath}/{serializedData.FindProperty("ScriptPath").stringValue}";
            string dataPath = $"{Application.dataPath}/{serializedData.FindProperty("DataPath").stringValue}";
            string objectName = serializedData.FindProperty("SelectedObject").objectReferenceValue.name;
            return (scriptPath, dataPath, objectName);
        }

        private string FormatTemplate(string template, string objectName)
        {
            template = template.Replace("%NAMESPACE%", serializedData.FindProperty("Namespace").stringValue);
            template = template.Replace("%CONTEXTMENU%", serializedData.FindProperty("ContextMenuPath").stringValue);
            template = template.Replace("%NAME%", objectName);
            return template;
        }

        private void OnCreateVariableButtonClicked()
        {
            var paths = GetPaths();
            string template = serializedData.FindProperty("VariableTemplateScript").stringValue;
            template = FormatTemplate(template, paths.ObjectName);

            if (!Directory.Exists(Path.GetDirectoryName($"{paths.ScriptPath}")))
                Directory.CreateDirectory($"{paths.ScriptPath}");

            if (!Directory.Exists(Path.GetDirectoryName($"{paths.ScriptPath}/Variables/")))
                Directory.CreateDirectory($"{paths.ScriptPath}/Variables/");

            if (!File.Exists($"{paths.ScriptPath}/Variables/{paths.ObjectName}Variable.cs"))
                File.Create($"{paths.ScriptPath}/Variables/{paths.ObjectName}Variable.cs").Close();

            File.WriteAllText($"{paths.ScriptPath}/Variables/{paths.ObjectName}Variable.cs", template);
            AssetDatabase.Refresh();
        }

        private void OnCreateEventButtonClicked()
        {
            var paths = GetPaths();
            string template = serializedData.FindProperty("EventTemplateScript").stringValue;
            template = FormatTemplate(template, paths.ObjectName);

            if (!Directory.Exists(Path.GetDirectoryName($"{paths.ScriptPath}")))
                Directory.CreateDirectory($"{paths.ScriptPath}");

            if (!Directory.Exists(Path.GetDirectoryName($"{paths.ScriptPath}/Events/")))
                Directory.CreateDirectory($"{paths.ScriptPath}/Events/");

            if (!File.Exists($"{paths.ScriptPath}/Events/{paths.ObjectName}Event.cs"))
                File.Create($"{paths.ScriptPath}/Events/{paths.ObjectName}Event.cs").Close();

            File.WriteAllText($"{paths.ScriptPath}/Events/{paths.ObjectName}Event.cs", template);
            AssetDatabase.Refresh();
        }

        private void OnCreateListenerButtonClicked()
        {
            var paths = GetPaths();
            string template = serializedData.FindProperty("ListenerTemplateScript").stringValue;
            template = FormatTemplate(template, paths.ObjectName);

            if (!Directory.Exists(Path.GetDirectoryName($"{paths.ScriptPath}")))
                Directory.CreateDirectory($"{paths.ScriptPath}");

            if (!Directory.Exists(Path.GetDirectoryName($"{paths.ScriptPath}/Listeners/")))
                Directory.CreateDirectory($"{paths.ScriptPath}/Listeners/");

            if (!File.Exists($"{paths.ScriptPath}/Listeners/{paths.ObjectName}Listener.cs"))
                File.Create($"{paths.ScriptPath}/Listeners/{paths.ObjectName}Listener.cs").Close();

            File.WriteAllText($"{paths.ScriptPath}/Listeners/{paths.ObjectName}Listener.cs", template);
            AssetDatabase.Refresh();
        }
    }
}