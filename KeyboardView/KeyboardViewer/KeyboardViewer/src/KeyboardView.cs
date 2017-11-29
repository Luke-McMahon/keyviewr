using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;

namespace KeyboardViewer
{
    class KeyboardView
    {
        private Dictionary<Key, Sprite> _keyToSprite;

        public KeyboardView()
        {
            _keyToSprite = new Dictionary<Key, Sprite>();
        }

        public void RegisterKey(Key key, Sprite spr)
        {
            _keyToSprite.Add(key, spr);
        }

        public bool Contains(Key key)
        {
            return _keyToSprite.ContainsKey(key);
        }

        public Sprite GetKey(Key key)
        {
            Sprite result;
            _keyToSprite.TryGetValue(key, out result);
            if (result != null)
            {
                return result;
            }

            Console.WriteLine("[ERROR] Dictionary Value with key (" + key + ") is null. Returning null.");
            return null;
        }

        public Dictionary<Key, Sprite> KeyDictionary { get { return _keyToSprite; } }
    }
}
