
namespace confluence_ui_mod.InputHandler
{
    public class InputHandler : IInputHandler
    {
        public InputMode SelectedInputMode { get; set; }
        public InputHandler()
        {
            SelectedInputMode = InputMode.Keyboard;
        }
        
    }
}