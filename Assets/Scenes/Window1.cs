using UnityEngine;

namespace Scenes.Editor
{
    public class Window1 : MonoBehaviour
    {
        private string name;
        [Range(0,100)]
        private int age;

        public string Name
        {
            get => name;
            set => name = value;
        }
        
        public int Age
        {
            get => age;
            set => age = value;
        }
    }
}