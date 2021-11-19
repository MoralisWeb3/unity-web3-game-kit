using UnityEngine;

namespace Assets.Scripts
{
    public static class Extensions
    {
        public static T GetFirstChildComponentByName<T>(this GameObject obj, string name, bool includeInactive) where T : Component
        {
            foreach (T component in obj.GetComponentsInChildren<T>(includeInactive))
            {
                if (component.gameObject.name.Equals(name))
                {
                    return component;
                }
            }

            return null;
        }
    }
}
