using UnityEditor;
using UnityEditorInternal;
using UnityEngine;


//Attributes
namespace Editor
{
    [CustomEditor(typeof(Questions))]
    [CanEditMultipleObjects]
    [System.Serializable]
    internal class QuestionDataDrawer : UnityEditor.Editor
    {
        private Questions QuestionsInstance => target as Questions;
        private ReorderableList _questionsList;


        private void OnEnable()
        {
            InitializeReordableList(ref _questionsList, "questionsList", "Question List");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            _questionsList.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }

        private void InitializeReordableList( ref ReorderableList list, string propertyName, string listLabel)
        {
            list = new ReorderableList(serializedObject, serializedObject.FindProperty(propertyName), true, true, true,
                true);

            list.onAddCallback = reordableList => QuestionsInstance.AddQuestion();
            list.drawHeaderCallback = (Rect rect) =>
            {
                EditorGUI.LabelField(rect, listLabel);
            };
            var l = list;
            list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                var element = l.serializedProperty.GetArrayElementAtIndex(index);
                rect.y += 2;

                EditorGUI.PropertyField(new Rect(rect.x, rect.y, 300, EditorGUIUtility.singleLineHeight),
                    element.FindPropertyRelative("question"), GUIContent.none);
                EditorGUI.PropertyField(new Rect(rect.x + 310, rect.y, 300, EditorGUIUtility.singleLineHeight),
                    element.FindPropertyRelative("isTrue"), GUIContent.none);
            };


        }
    }
}
