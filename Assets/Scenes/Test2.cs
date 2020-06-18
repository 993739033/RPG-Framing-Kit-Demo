using Test.Attribute;
using UnityEngine;

namespace Scenes
{ 
    [System.Serializable]
    public class Test2
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void initLog()
        {
            Debug.Log("runtimeinit");
        }
        
        [AttributeTest(type = TestType.A)]
        public void init()
        {
            
        }
        
    }
}