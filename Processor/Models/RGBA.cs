namespace Processor.Models
{
    public class RGBA
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public byte A { get; set; }

        public RGBA()
        {
        }

        public RGBA(byte[] pixels, int index)
        {
            R = pixels[index + 0];
            G = pixels[index + 1];
            B = pixels[index + 2];
            A = pixels[index + 3];
        }

        public RGBA(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public void AssignRGBAToPixel(byte[] pixels, int index)
        {
            pixels[index * 4 + 0] = R;
            pixels[index * 4 + 1] = G;
            pixels[index * 4 + 2] = B;
            pixels[index * 4 + 3] = A;
        }

        public System.Drawing.Color GetColor()
        {
            return System.Drawing.Color.FromArgb(A, R, G, B);
        }

        public float GetHue()
        {
            return GetColor().GetHue();
        }
    }
}