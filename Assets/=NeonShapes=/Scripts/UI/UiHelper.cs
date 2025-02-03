using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

namespace NeonShapes
{
    public static class UiHelper
    {
        //==================================================
        public static bool PointedOnUiObject(this Vector3 pointer)
        {
            return IsPointerOverUIElement(GetEventSystemRaycastResults(pointer));
        }
        //==================================================
        private static bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaycastResults)
        {
            foreach (var curRaycastResult in eventSystemRaycastResults)
            {
                if (curRaycastResult.gameObject.layer == 5)
                    return true;
            }
            return false;
        }
        //==================================================
        private static List<RaycastResult> GetEventSystemRaycastResults(Vector3 pointer)
        {
            var eventData = new PointerEventData(EventSystem.current)
            {
                position = pointer
            };
            var raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raycastResults);
            return raycastResults;
        }
        //==================================================
    }
}