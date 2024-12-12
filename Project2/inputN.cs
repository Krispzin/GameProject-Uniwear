using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game12;
using Microsoft.Xna.Framework;
using ThanaNita.MonoGameTnt;

namespace Project2
{
    public class inputN : Actor
    {
        Text text;
        ExitNotifier exitNotifier;
        public inputN(ExitNotifier exitNotifier)
        {
            this.exitNotifier = exitNotifier;
            text = new Text("Poppins-Medium.ttf", 100, Color.White,
                            "User Interface: test");
           Add(text);
        }
    }
}
