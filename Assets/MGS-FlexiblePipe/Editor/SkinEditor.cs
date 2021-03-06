﻿/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SkinEditor.cs
 *  Description  :  Editor for Skin component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/20/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using Mogoson.EditorExtension;
using UnityEditor;
using UnityEngine;

namespace Mogoson.SkinnedMesh
{
    [CustomEditor(typeof(Skin), true)]
    public class SkinEditor : GenericEditor
    {
        #region Field and Property
        protected Skin Target { get { return target as Skin; } }
        #endregion

        #region Protected Method
        protected virtual void OnEnable()
        {
            if (!Application.isPlaying)
            {
                Target.RebuildInEditor();
                Undo.undoRedoPerformed = () => { Target.RebuildInEditor(); };
            }
        }

        protected virtual void OnDisable()
        {
            EditorUtility.UnloadUnusedAssetsImmediate(true);
            Undo.undoRedoPerformed = null;
        }
        #endregion

        #region Public Method
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            DrawDefaultInspector();
            if (EditorGUI.EndChangeCheck())
                Target.RebuildInEditor();
        }
        #endregion
    }
}