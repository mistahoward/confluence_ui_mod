using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace confluence_ui_mod.InputHandler
{
    public interface IInputHandler
    {
        InputMode SelectedInputMode { get; set; }
        
    }
}