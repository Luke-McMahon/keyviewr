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
    }
}
