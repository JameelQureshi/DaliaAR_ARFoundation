using System;
using System.Text;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARFoundation.Samples
{
    /// <summary>
    /// Change the prefab for the first image in library at runtime.
    /// </summary>
    [RequireComponent(typeof(ARTrackedImageManager))]
    public class DynamicPrefab : MonoBehaviour
    {
        GameObject m_OriginalPrefab;

        [SerializeField]
        GameObject m_AlternativePrefab;

        public GameObject alternativePrefab
        {
            get => m_AlternativePrefab;
            set => m_AlternativePrefab = value;
        }

        enum State
        {
            OriginalPrefab,
            ChangeToOriginalPrefab,
            AlternativePrefab,
            ChangeToAlternativePrefab,
            Error
        }

        State m_State;

        string m_ErrorMessage = "";

        

        void SetError(string errorMessage)
        {
            m_State = State.Error;
            m_ErrorMessage = $"Error: {errorMessage}";
        }

        void Update()
        {
            switch (m_State)
            {
                case State.ChangeToAlternativePrefab:
                {
                    if (!alternativePrefab)
                    {
                        SetError("No alternative prefab is given.");
                        break;
                    }

                    var manager = GetComponent<PrefabImagePairManager>();
                    if (!manager)
                    {
                        SetError($"No {nameof(PrefabImagePairManager)} available.");
                        break;
                    }

                    var library = manager.imageLibrary;
                    if (!library)
                    {
                        SetError($"No image library available.");
                        break;
                    }

                    if (!m_OriginalPrefab)
                        m_OriginalPrefab = manager.GetPrefabForReferenceImage(library[0]);

                    manager.SetPrefabForReferenceImage(library[0], alternativePrefab);
                    m_State = State.AlternativePrefab;
                    break;
                }

                case State.ChangeToOriginalPrefab:
                {
                    if (!m_OriginalPrefab)
                    {
                        SetError("No original prefab is given.");
                        break;
                    }

                    var manager = GetComponent<PrefabImagePairManager>();
                    if (!manager)
                    {
                        SetError($"No {nameof(PrefabImagePairManager)} available.");
                        break;
                    }

                    var library = manager.imageLibrary;
                    if (!library)
                    {
                        SetError($"No image library available.");
                        break;
                    }

                    manager.SetPrefabForReferenceImage(library[0], m_OriginalPrefab);
                    m_State = State.OriginalPrefab;
                    break;
                }
            }
        }
    }
}
