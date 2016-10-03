using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
 
namespace TC.WinForms
{
  /// <summary>Represents a text box control for entering passwords.</summary>
  [ToolboxItem(true), ToolboxBitmap(typeof(TextBox))]
  public class PasswordTextBox : TextBox
  {
    private const int
      WM_GETTEXT = 0x000D,
      WM_GETTEXTLENGTH = 0x000E,
      EM_SETPASSWORDCHAR = 0x00CC;
    
    private bool _isAccessingText;
    
    /// <summary>Initializes a new instance of the <see cref="T:PasswordTextBox" /> class.</summary>
    public PasswordTextBox()
    {
      UseSystemPasswordChar = true;
    }
 
    /// <summary>Gets or sets the current text in the <see cref="T:TextBox"/>.</summary>
    /// <returns>The text displayed in the control.</returns>
    public override string Text
    {
      get
      {
        _isAccessingText = true;
        try { return base.Text; }
        finally { _isAccessingText = false; }
      }
      set
      {
        _isAccessingText = true;
        try { base.Text = value; }
        finally { _isAccessingText = false; }
      }
    }
 
    /// <summary>Gets the length of text in the control.</summary>
    /// <returns>The number of characters contained in the text of the control.</returns>
    public override int TextLength
    {
      get
      {
        _isAccessingText = true;
        try { return base.TextLength; }
        finally { _isAccessingText = false; }
      }
    }
 
    /// <summary>Processes Windows message.</summary>
    /// <param name="m">The Windows <see cref="T:Message" /> to process.</param>
    protected override void WndProc(ref Message m)
    {
      switch (m.Msg)
      {
        case WM_GETTEXT:
        case WM_GETTEXTLENGTH:
          if (!_isAccessingText)
          {
            m.Result = IntPtr.Zero;
            return;
          }
          break;
        
        case EM_SETPASSWORDCHAR:
          return;
      }
 
      base.WndProc(ref m);
    }
  }
}