using System.Drawing;

namespace _01_WebForms.Services
{
    public interface ITextToImgService
    {
        Image DrawText(string text, Font font, Color textColor, Color backColor);
    }
}
