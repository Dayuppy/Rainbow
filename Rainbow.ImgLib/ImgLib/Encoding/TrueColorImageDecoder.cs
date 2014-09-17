﻿//Copyright (C) 2014+ Marco (Phoenix) Calautti.

//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, version 2.0.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License 2.0 for more details.

//A copy of the GPL 2.0 should have been included with the program.
//If not, see http://www.gnu.org/licenses/

//Official repository and contact information can be found at
//http://github.com/marco-calautti/Rainbow

using System.Drawing;

namespace Rainbow.ImgLib.Encoding
{
    public class TrueColorImageDecoder : ImageDecoder
    {
        protected byte[] pixelData;
        protected int width, height;

        protected ColorDecoder decoder;

        public TrueColorImageDecoder(byte[] pixelData, int width, int height, ColorDecoder decoder)
        {
            this.pixelData = pixelData;
            this.width = width;
            this.height = height;
            this.decoder = decoder;
        }
        public Image DecodeImage()
        {
            Color[] colors = decoder.DecodeColors(pixelData);
            Bitmap bmp = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    bmp.SetPixel(x, y, colors[y * width + x]);

            return bmp;
        }

    }
}