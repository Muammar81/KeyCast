using System.Drawing.Text;
using System.Reflection.Emit;
using System.Windows.Forms;

public partial class SmoothLabel : System.Windows.Forms.Label
{
    private TextRenderingHint _hint = TextRenderingHint.SystemDefault;
    public TextRenderingHint TextRenderingHint
    {
        get { return this._hint; }
        set { this._hint = value; }
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        pe.Graphics.TextRenderingHint = TextRenderingHint;
        base.OnPaint(pe);
    }
}