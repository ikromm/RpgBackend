using System.Collections.Generic;
using UnityEngine;

namespace ikromm
{
    [DisallowMultipleComponent]
    public class ResourceManager : PersistentUnitySingleton<ResourceManager>
    {
        private Dictionary<string, Object> resourceCache = new Dictionary<string, Object>(); //TODO we could do with a hash instead of a string here.

        private ResourceMappingResolver<ResourcePaths> pathMappingResolver;
        private ResourceMappingResolver<ResourcePostfixes> postfixMappingResolver;

        public void Awake()
        {
            pathMappingResolver = new ResourceMappingResolver<ResourcePaths>();
            postfixMappingResolver = new ResourceMappingResolver<ResourcePostfixes>();
        }

        /// <summary>
        /// Caches and returns the resource that resides in the selected path
        /// </summary>
        /// <typeparam name="T">The type of the resource to cast the result to.</typeparam>
        /// <param name="path">The path of the resource. Use *only* forward slashes.</param>
        /// <returns>The resource that has been loaded</returns>
        public T Load<T>(string path) where T : Object
        {
            if (!resourceCache.ContainsKey(path))
                resourceCache.Add(path, Resources.Load<T>(path));

            return (T)resourceCache[path];
        }

        /// <summary>
        /// Caches and returns the resource that resides in the selected path. The path is constructed on the fly.
        /// </summary>
        /// <typeparam name="T">The type of the resource to cast the result to.</typeparam>
        /// <param name="path">The path prefix the resource resides in.</param>
        /// <param name="id">The id of the object requesting the resource loading.</param>
        /// <param name="postfix">The postfix appended to the resource's id.</param>
        /// <returns></returns>
        public T Load<T>(ResourcePaths path, int id, ResourcePostfixes postfix) where T : Object
        {
            return Load<T>(path, id.ToString(), postfix);
        }

        /// <summary>
        /// Caches and returns the resource that resides in the selected path. The path is constructed on the fly.
        /// </summary>
        /// <typeparam name="T">The type of the resource to cast the result to.</typeparam>
        /// <param name="path">The path prefix the resource resides in.</param>
        /// <param name="id">The id of the object requesting the resource loading.</param>
        /// <param name="postfix">The postfix appended to the resource's id.</param>
        /// <returns></returns>
        public T Load<T>(ResourcePaths path, string id, ResourcePostfixes postfix) where T : Object
        {
            string resourcePath = pathMappingResolver[path] + id + postfixMappingResolver[postfix];

            return Load<T>(resourcePath);
        }

    }

    [MappingTable("ResourcePathMappings")]
    public enum ResourcePaths
    {
        IngameMenu,
        Items
    }

    [MappingTable("ResourcePostfixMappings")]
    public enum ResourcePostfixes
    {
        Portrait,
        PortraitSelected,
        Icon
    }
}
