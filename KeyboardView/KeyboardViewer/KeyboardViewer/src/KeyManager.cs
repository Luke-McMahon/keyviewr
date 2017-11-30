using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardViewer
{
    class KeyManager
    {
        private readonly List<Key> _allKeys;
        private readonly List<Key> _keysDown;

        private readonly KeyboardView _view;

        public KeyManager()
        {
            _view = new KeyboardView();
            _allKeys = new List<Key>();
            _keysDown = new List<Key>();
        }



        public void AddKey(Key key)
        {
            if(!_keysDown.Contains(key))
                _keysDown.Add(key);

            foreach (Key k in _keysDown)
            {
                if (_view.Contains(k))
                {
                    _view.GetKey(k).Typed();
                }
            }
        }

        public void RemoveKeys()
        {
            _keysDown.Clear();
        }

        public void PrintKeys()
        {
            var keyLog = "";
            for (var i = 0; i < _keysDown.Count; i++)
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
            if (_view.GetKey(key) != null)
            {
                _view.GetKey(key).Untyped();
            }
            _keysDown.Remove(key);
        }

        public KeyboardView View { get { return _view; } }
        public List<Key> Keys { get { return _keysDown; } }
    }
}
