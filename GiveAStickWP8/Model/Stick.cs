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

            int baseR = 0;
            int baseG = 0;
            int baseB = 0;
            int alpha = 255;

            switch (order)
            {
                case 0: baseR = 255; baseG = 0; baseB = 18;
                    break;

                case 1: baseR = 255; baseG = 180; baseB = 18;
                    break;

                case 2: baseR = 255; baseG = 225; baseB = 18;
                    break;

                default: baseR = 255; baseG = 225; baseB = 255; alpha = 100;
                    break;
            }

            rectColor.R = BitConverter.GetBytes(baseR)[0];
            rectColor.G = BitConverter.GetBytes(baseG)[0];
            rectColor.B = BitConverter.GetBytes(baseB)[0];

            rectColor.A = (byte)alpha;

            Brush result = new SolidColorBrush(rectColor);

            return result;
        }
    }
}
