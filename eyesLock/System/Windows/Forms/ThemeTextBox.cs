using System.Drawing;

namespace System.Windows.Forms
{
    internal class ThemeTextBox : TextBox
    {
        public Color BorderColor { get; set; } = Color.Gray;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0xF || m.Msg == 0x133)
            {
                using (Graphics g = Graphics.FromHwnd(Handle))
                {
                    Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
                    ControlPaint.DrawBorder(g, rect, BorderColor, ButtonBorderStyle.Solid);
                }
            }
        }
    }
}