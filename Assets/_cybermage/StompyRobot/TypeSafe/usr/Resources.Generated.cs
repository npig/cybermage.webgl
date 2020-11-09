// ------------------------------------------------------------------------------
//  _______   _____ ___ ___   _   ___ ___ 
// |_   _\ \ / / _ \ __/ __| /_\ | __| __|
//   | |  \ V /|  _/ _|\__ \/ _ \| _|| _| 
//   |_|   |_| |_| |___|___/_/ \_\_| |___|
// 
// This file has been generated automatically by TypeSafe.
// Any changes to this file may be lost when it is regenerated.
// https://www.stompyrobot.uk/tools/typesafe
// 
// TypeSafe Version: 1.4.1
// 
// ------------------------------------------------------------------------------



public sealed class CM_Resources {
    
    private CM_Resources() {
    }
    
    private const string _tsInternal = "1.4.1";
    
    public static global::TypeSafe.PrefabResource pickup_spawns {
        get {
            return ((global::TypeSafe.PrefabResource)(@__ts_internal_resources[0]));
        }
    }
    
    public static global::TypeSafe.Resource<global::UnityEngine.Audio.AudioMixer> Mixer {
        get {
            return ((global::TypeSafe.Resource<global::UnityEngine.Audio.AudioMixer>)(@__ts_internal_resources[1]));
        }
    }
    
    public static global::TypeSafe.Resource<global::UnityEngine.TextAsset> LineBreaking_Leading_Characters {
        get {
            return ((global::TypeSafe.Resource<global::UnityEngine.TextAsset>)(@__ts_internal_resources[2]));
        }
    }
    
    public static global::TypeSafe.Resource<global::UnityEngine.TextAsset> LineBreaking_Following_Characters {
        get {
            return ((global::TypeSafe.Resource<global::UnityEngine.TextAsset>)(@__ts_internal_resources[3]));
        }
    }
    
    private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> @__ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                new global::TypeSafe.PrefabResource("pickup_spawns", "pickup_spawns"),
                new global::TypeSafe.Resource<global::UnityEngine.Audio.AudioMixer>("Mixer", "Mixer"),
                new global::TypeSafe.Resource<global::UnityEngine.TextAsset>("LineBreaking Leading Characters", "LineBreaking Leading Characters"),
                new global::TypeSafe.Resource<global::UnityEngine.TextAsset>("LineBreaking Following Characters", "LineBreaking Following Characters")});
    
    public sealed class prefabs {
        
        private prefabs() {
        }
        
        public static global::TypeSafe.PrefabResource isometricAlignment {
            get {
                return ((global::TypeSafe.PrefabResource)(@__ts_internal_resources[0]));
            }
        }
        
        private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> @__ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                    new global::TypeSafe.PrefabResource("isometricAlignment", "prefabs/isometricAlignment")});
        
        public sealed class entities {
            
            private entities() {
            }
            
            public static global::TypeSafe.PrefabResource Zombie {
                get {
                    return ((global::TypeSafe.PrefabResource)(@__ts_internal_resources[0]));
                }
            }
            
            public static global::TypeSafe.PrefabResource Cybermage {
                get {
                    return ((global::TypeSafe.PrefabResource)(@__ts_internal_resources[1]));
                }
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> @__ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                        new global::TypeSafe.PrefabResource("Zombie", "prefabs/entities/Zombie"),
                        new global::TypeSafe.PrefabResource("Cybermage", "prefabs/entities/Cybermage")});
            
            /// <summary>
            /// Return a list of all resources in this folder.
            /// This method has a very low performance cost, no need to cache the result.
            /// </summary>
            /// <returns>A list of resource objects in this folder.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
                return @__ts_internal_resources;
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> @__ts_internal_recursiveLookupCache;
            
            /// <summary>
            /// Return a list of all resources in this folder and all sub-folders.
            /// The result of this method is cached, so subsequent calls will have very low performance cost.
            /// </summary>
            /// <returns>A list of resource objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
                if ((@__ts_internal_recursiveLookupCache != null)) {
                    return @__ts_internal_recursiveLookupCache;
                }
                global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
                tmp.AddRange(GetContents());
                @__ts_internal_recursiveLookupCache = tmp;
                return @__ts_internal_recursiveLookupCache;
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder.
            /// </summary>
            public static void UnloadAll() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder and subfolders.
            /// </summary>
            private void UnloadAllRecursive() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
            }
        }
        
        public sealed class ui {
            
            private ui() {
            }
            
            public static global::TypeSafe.PrefabResource statsContainer {
                get {
                    return ((global::TypeSafe.PrefabResource)(@__ts_internal_resources[0]));
                }
            }
            
            public static global::TypeSafe.PrefabResource worldSpaceHeader {
                get {
                    return ((global::TypeSafe.PrefabResource)(@__ts_internal_resources[1]));
                }
            }
            
            public static global::TypeSafe.PrefabResource folioContainer {
                get {
                    return ((global::TypeSafe.PrefabResource)(@__ts_internal_resources[2]));
                }
            }
            
            public static global::TypeSafe.PrefabResource worldSpaceText {
                get {
                    return ((global::TypeSafe.PrefabResource)(@__ts_internal_resources[3]));
                }
            }
            
            public static global::TypeSafe.PrefabResource worldSpaceLink {
                get {
                    return ((global::TypeSafe.PrefabResource)(@__ts_internal_resources[4]));
                }
            }
            
            public static global::TypeSafe.PrefabResource background {
                get {
                    return ((global::TypeSafe.PrefabResource)(@__ts_internal_resources[5]));
                }
            }
            
            public static global::TypeSafe.PrefabResource mainScreen {
                get {
                    return ((global::TypeSafe.PrefabResource)(@__ts_internal_resources[6]));
                }
            }
            
            public static global::TypeSafe.PrefabResource uiCanvas {
                get {
                    return ((global::TypeSafe.PrefabResource)(@__ts_internal_resources[7]));
                }
            }
            
            public static global::TypeSafe.PrefabResource worldSpaceSubHeader {
                get {
                    return ((global::TypeSafe.PrefabResource)(@__ts_internal_resources[8]));
                }
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> @__ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                        new global::TypeSafe.PrefabResource("statsContainer", "prefabs/ui/statsContainer"),
                        new global::TypeSafe.PrefabResource("worldSpaceHeader", "prefabs/ui/worldSpaceHeader"),
                        new global::TypeSafe.PrefabResource("folioContainer", "prefabs/ui/folioContainer"),
                        new global::TypeSafe.PrefabResource("worldSpaceText", "prefabs/ui/worldSpaceText"),
                        new global::TypeSafe.PrefabResource("worldSpaceLink", "prefabs/ui/worldSpaceLink"),
                        new global::TypeSafe.PrefabResource("background", "prefabs/ui/background"),
                        new global::TypeSafe.PrefabResource("mainScreen", "prefabs/ui/mainScreen"),
                        new global::TypeSafe.PrefabResource("uiCanvas", "prefabs/ui/uiCanvas"),
                        new global::TypeSafe.PrefabResource("worldSpaceSubHeader", "prefabs/ui/worldSpaceSubHeader")});
            
            /// <summary>
            /// Return a list of all resources in this folder.
            /// This method has a very low performance cost, no need to cache the result.
            /// </summary>
            /// <returns>A list of resource objects in this folder.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
                return @__ts_internal_resources;
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> @__ts_internal_recursiveLookupCache;
            
            /// <summary>
            /// Return a list of all resources in this folder and all sub-folders.
            /// The result of this method is cached, so subsequent calls will have very low performance cost.
            /// </summary>
            /// <returns>A list of resource objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
                if ((@__ts_internal_recursiveLookupCache != null)) {
                    return @__ts_internal_recursiveLookupCache;
                }
                global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
                tmp.AddRange(GetContents());
                @__ts_internal_recursiveLookupCache = tmp;
                return @__ts_internal_recursiveLookupCache;
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder.
            /// </summary>
            public static void UnloadAll() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder and subfolders.
            /// </summary>
            private void UnloadAllRecursive() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
            }
        }
        
        /// <summary>
        /// Return a list of all resources in this folder.
        /// This method has a very low performance cost, no need to cache the result.
        /// </summary>
        /// <returns>A list of resource objects in this folder.</returns>
        public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
            return @__ts_internal_resources;
        }
        
        private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> @__ts_internal_recursiveLookupCache;
        
        /// <summary>
        /// Return a list of all resources in this folder and all sub-folders.
        /// The result of this method is cached, so subsequent calls will have very low performance cost.
        /// </summary>
        /// <returns>A list of resource objects in this folder and sub-folders.</returns>
        public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
            if ((@__ts_internal_recursiveLookupCache != null)) {
                return @__ts_internal_recursiveLookupCache;
            }
            global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
            tmp.AddRange(GetContents());
            tmp.AddRange(entities.GetContentsRecursive());
            tmp.AddRange(ui.GetContentsRecursive());
            @__ts_internal_recursiveLookupCache = tmp;
            return @__ts_internal_recursiveLookupCache;
        }
        
        /// <summary>
        /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
        /// This method does not cache the result, so you should cache the result yourself if you will use it often.
        /// </summary>
        /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
        public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
            where TResource : global::UnityEngine.Object {
            return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
        }
        
        /// <summary>
        /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
        /// This method does not cache the result, so you should cache the result yourself if you will use it often.
        /// </summary>
        /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
        public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
            where TResource : global::UnityEngine.Object {
            return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
        }
        
        /// <summary>
        /// Call Unload() on every loaded resource in this folder.
        /// </summary>
        public static void UnloadAll() {
            global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
        }
        
        /// <summary>
        /// Call Unload() on every loaded resource in this folder and subfolders.
        /// </summary>
        private void UnloadAllRecursive() {
            global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
        }
    }
    
    public sealed class audio {
        
        private audio() {
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _06Prox {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[0]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _03AtmosLoopB {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[1]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _05Dlog02 {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[2]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _05Dlog05 {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[3]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _01SpawnB {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[4]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _01SpawnD {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[5]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _00MusicLoopB {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[6]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _00MusicLoop {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[7]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _06ProximB {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[8]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _05Dlog03 {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[9]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _05Dlog01 {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[10]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _02LeadLoop {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[11]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _05Dlog07 {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[12]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _05Dlog04 {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[13]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _04Modem {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[14]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _04Dialtone {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[15]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _08PickupSpawn {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[16]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _05Dlog08 {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[17]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _03AtmosLoopC {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[18]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _03AtmosLoopA {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[19]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _01SpawnA {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[20]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _05Dlog06 {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[21]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _01SpawnC {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[22]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> _07Pickup {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(@__ts_internal_resources[23]));
            }
        }
        
        private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> @__ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("06Prox", "audio/06Prox"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("03AtmosLoopB", "audio/03AtmosLoopB"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("05Dlog02", "audio/05Dlog02"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("05Dlog05", "audio/05Dlog05"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("01SpawnB", "audio/01SpawnB"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("01SpawnD", "audio/01SpawnD"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("00MusicLoopB", "audio/00MusicLoopB"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("00MusicLoop", "audio/00MusicLoop"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("06ProximB", "audio/06ProximB"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("05Dlog03", "audio/05Dlog03"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("05Dlog01", "audio/05Dlog01"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("02LeadLoop", "audio/02LeadLoop"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("05Dlog07", "audio/05Dlog07"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("05Dlog04", "audio/05Dlog04"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("04Modem", "audio/04Modem"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("04Dialtone", "audio/04Dialtone"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("08PickupSpawn", "audio/08PickupSpawn"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("05Dlog08", "audio/05Dlog08"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("03AtmosLoopC", "audio/03AtmosLoopC"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("03AtmosLoopA", "audio/03AtmosLoopA"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("01SpawnA", "audio/01SpawnA"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("05Dlog06", "audio/05Dlog06"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("01SpawnC", "audio/01SpawnC"),
                    new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("07Pickup", "audio/07Pickup")});
        
        /// <summary>
        /// Return a list of all resources in this folder.
        /// This method has a very low performance cost, no need to cache the result.
        /// </summary>
        /// <returns>A list of resource objects in this folder.</returns>
        public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
            return @__ts_internal_resources;
        }
        
        private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> @__ts_internal_recursiveLookupCache;
        
        /// <summary>
        /// Return a list of all resources in this folder and all sub-folders.
        /// The result of this method is cached, so subsequent calls will have very low performance cost.
        /// </summary>
        /// <returns>A list of resource objects in this folder and sub-folders.</returns>
        public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
            if ((@__ts_internal_recursiveLookupCache != null)) {
                return @__ts_internal_recursiveLookupCache;
            }
            global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
            tmp.AddRange(GetContents());
            @__ts_internal_recursiveLookupCache = tmp;
            return @__ts_internal_recursiveLookupCache;
        }
        
        /// <summary>
        /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
        /// This method does not cache the result, so you should cache the result yourself if you will use it often.
        /// </summary>
        /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
        public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
            where TResource : global::UnityEngine.Object {
            return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
        }
        
        /// <summary>
        /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
        /// This method does not cache the result, so you should cache the result yourself if you will use it often.
        /// </summary>
        /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
        public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
            where TResource : global::UnityEngine.Object {
            return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
        }
        
        /// <summary>
        /// Call Unload() on every loaded resource in this folder.
        /// </summary>
        public static void UnloadAll() {
            global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
        }
        
        /// <summary>
        /// Call Unload() on every loaded resource in this folder and subfolders.
        /// </summary>
        private void UnloadAllRecursive() {
            global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
        }
    }
    
    public sealed class Fonts_Materials {
        
        private Fonts_Materials() {
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Material> LiberationSans_SDF_Drop_Shadow {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Material>)(@__ts_internal_resources[0]));
            }
        }
        
        public static global::TypeSafe.Resource<global::UnityEngine.Material> LiberationSans_SDF_Outline {
            get {
                return ((global::TypeSafe.Resource<global::UnityEngine.Material>)(@__ts_internal_resources[1]));
            }
        }
        
        private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> @__ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                    new global::TypeSafe.Resource<global::UnityEngine.Material>("LiberationSans SDF - Drop Shadow", "Fonts & Materials/LiberationSans SDF - Drop Shadow"),
                    new global::TypeSafe.Resource<global::UnityEngine.Material>("LiberationSans SDF - Outline", "Fonts & Materials/LiberationSans SDF - Outline")});
        
        /// <summary>
        /// Return a list of all resources in this folder.
        /// This method has a very low performance cost, no need to cache the result.
        /// </summary>
        /// <returns>A list of resource objects in this folder.</returns>
        public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
            return @__ts_internal_resources;
        }
        
        private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> @__ts_internal_recursiveLookupCache;
        
        /// <summary>
        /// Return a list of all resources in this folder and all sub-folders.
        /// The result of this method is cached, so subsequent calls will have very low performance cost.
        /// </summary>
        /// <returns>A list of resource objects in this folder and sub-folders.</returns>
        public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
            if ((@__ts_internal_recursiveLookupCache != null)) {
                return @__ts_internal_recursiveLookupCache;
            }
            global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
            tmp.AddRange(GetContents());
            @__ts_internal_recursiveLookupCache = tmp;
            return @__ts_internal_recursiveLookupCache;
        }
        
        /// <summary>
        /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
        /// This method does not cache the result, so you should cache the result yourself if you will use it often.
        /// </summary>
        /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
        public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
            where TResource : global::UnityEngine.Object {
            return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
        }
        
        /// <summary>
        /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
        /// This method does not cache the result, so you should cache the result yourself if you will use it often.
        /// </summary>
        /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
        public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
            where TResource : global::UnityEngine.Object {
            return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
        }
        
        /// <summary>
        /// Call Unload() on every loaded resource in this folder.
        /// </summary>
        public static void UnloadAll() {
            global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
        }
        
        /// <summary>
        /// Call Unload() on every loaded resource in this folder and subfolders.
        /// </summary>
        private void UnloadAllRecursive() {
            global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
        }
    }
    
    /// <summary>
    /// Return a list of all resources in this folder.
    /// This method has a very low performance cost, no need to cache the result.
    /// </summary>
    /// <returns>A list of resource objects in this folder.</returns>
    public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
        return @__ts_internal_resources;
    }
    
    private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> @__ts_internal_recursiveLookupCache;
    
    /// <summary>
    /// Return a list of all resources in this folder and all sub-folders.
    /// The result of this method is cached, so subsequent calls will have very low performance cost.
    /// </summary>
    /// <returns>A list of resource objects in this folder and sub-folders.</returns>
    public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
        if ((@__ts_internal_recursiveLookupCache != null)) {
            return @__ts_internal_recursiveLookupCache;
        }
        global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
        tmp.AddRange(GetContents());
        tmp.AddRange(prefabs.GetContentsRecursive());
        tmp.AddRange(audio.GetContentsRecursive());
        tmp.AddRange(Fonts_Materials.GetContentsRecursive());
        @__ts_internal_recursiveLookupCache = tmp;
        return @__ts_internal_recursiveLookupCache;
    }
    
    /// <summary>
    /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
    /// This method does not cache the result, so you should cache the result yourself if you will use it often.
    /// </summary>
    /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
    public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
        where TResource : global::UnityEngine.Object {
        return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
    }
    
    /// <summary>
    /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
    /// This method does not cache the result, so you should cache the result yourself if you will use it often.
    /// </summary>
    /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
    public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
        where TResource : global::UnityEngine.Object {
        return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
    }
    
    /// <summary>
    /// Call Unload() on every loaded resource in this folder.
    /// </summary>
    public static void UnloadAll() {
        global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
    }
    
    /// <summary>
    /// Call Unload() on every loaded resource in this folder and subfolders.
    /// </summary>
    private void UnloadAllRecursive() {
        global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
    }
}
