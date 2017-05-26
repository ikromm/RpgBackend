using UnityEngine;
using System.Collections;

namespace ikromm
{
    public static class LoadableResourcesExtensions
    {
        /// <summary>
        /// Loads a resource of the specific object.
        /// </summary>
        /// <typeparam name="T">The type of the resource to cast the result to.</typeparam>
        /// <param name="obj">The object to get the ID from</param>
        /// <param name="path">The path mapping of the resource.</param>
        /// <param name="postfix">The mapping of the  the to add to the resource's path.</param>
        /// <returns></returns>
        public static T LoadResource<T>(this ILoadableResources obj, ResourcePaths path, ResourcePostfixes postfix) where T : Object
        {
            return ResourceManager.Instance.Load<T>(path, obj.ID, postfix);
        }
    }
}
