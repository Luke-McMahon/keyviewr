using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardViewer
{
    class KeyManager
    {
        private List<Key> _keysDown;

        public KeyManager()
        {
            _keysDown = new List<Key>();
        }

        public void AddKey(Key key)
        {
            if(!_keysDown.Contains(key))
                _keysDown.Add(key);
        }

        public void RemoveKeys()
        {
            _keysDown.Clear();
        }

        public void PrintKeys()
        {
            string keyLog = "";
            for (int i = 0; i < _keysDown.Count; i++)
            {
                if (i != _keysDown.Count - 1)
                {
                    keyLog += _keysDown[i].ToString() + ", ";
                }
                else
                {
                    keyLog += _keysDown[i].ToString();
                }
            }
            Console.WriteLine("Pressed: " + keyLog);
        }

        public void RemoveKey(Key key)
        {
            _keysDown.Remove(key);
        }
    }
}
