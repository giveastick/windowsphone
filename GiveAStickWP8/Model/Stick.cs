using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WP.Core;

namespace GiveAStickWP8
{
    public class Stick : ObservableObject
    {
        public string Nickname {get; set;}
        public int Balance { get; set; }
        private Brush _Brush;

        public Brush Brush
        {
            get { return _Brush; }
            set { OnPropertyChanging(); _Brush = value; OnPropertyChanged(); }
        }


        public int Order { get; set; }

        public Stick()
        {
        }

        public Brush getRectangleFillBrush(int order)
        {
            Color rectColor = Color.FromArgb(0x00, 0x00, 0x00, 0x00);

            int baseR = 255;
            int baseG = 0;
            int baseB = 13;

            int newR = baseR - order * 12;
            int newG = baseG - order * 0;
            int newB = baseB - order * 2;

            if (newR < 0) newR = 0;
            if (newG < 0) newG = 0;
            if (newB < 0) newB = 0;
            
            rectColor.A = (byte)255;

            rectColor.R = BitConverter.GetBytes(newR)[0];
            rectColor.G = BitConverter.GetBytes(newG)[0];
            rectColor.B = BitConverter.GetBytes(newB)[0];

            Brush result = new SolidColorBrush(rectColor);

            return result;
        }
    }
}
