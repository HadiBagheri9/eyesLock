using System.Drawing;

namespace System.Windows.Forms
{
    internal class ThemeTextBox : TextBox
    {
        public Color BorderColor { get; set; } = Color.White;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0xF || m.Msg == 0x133)
            {
                using (Graphics g = Graphics.FromHwnd(Handle))
                {
                    using (Pen p = new Pen(BorderColor, 2))
                    {
                        Rectangle rect = new Rectangle(0, 0, Width - 2, Height - 2);
                        ControlPaint.DrawBorder(g, rect, BorderColor, ButtonBorderStyle.Solid);
                        g.DrawRectangle(p, rect);
                    }
                }
            }
        }
    }
}