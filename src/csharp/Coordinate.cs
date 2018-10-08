/****************************************
Daggorath PC-Port Version 0.2.1
Richard Hunerlach
November 13, 2002

The copyright for Dungeons of Daggorath
is held by Douglas J. Morgan.
(c) 1982, DynaMicro
*****************************************/
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoD
{    
    // This class is used to translate between original 256x192
    // coordinates and whichever modern coordinate system is used.
    // It sets 512x384 as the default, but when the video system
    // gets set up during initialization, these values are set to
    // whatever screen resolution is chosen.
    //
    // This could be expanded later to do screen centering in cases
    // where the available (or user-chosen) screen resolution is
    // not an exact multiple of 256x192.
    //
    // The absolute versions are used for most things, and the
    // relative versions are used for drawing the font
    public class Coordinate
	{
		public Coordinate()
		{
			this.orgWidth = 256.0;
			this.orgHeight = 192.0;
			this.curWidth = 512.0;
			this.curHeight = 384.0;
		}

		// Sets the data members based on screen width
		// (assumes a 4/3 width/height ratio)
		public void SetCurWH(double W)
		{
			curWidth = ((int) W / (int) 256) * (int) 256;
			curHeight = (curWidth * 0.75);
			offX = (W - curWidth) / 2;
			offY = (offX * 0.75);
		}

		// Calculates absolute screen X-coordinate based on DoD X-coordinate
		public GLfloat NewX(double orgX)
		{
			return ((GLfloat)((orgX) / orgWidth * curWidth) + (GLfloat) offX);
		}

		// Calculates relative screen X-coordinate based on DoD X-coordinate
		public GLfloat NewXa(double orgX)
		{
			return ((GLfloat)((orgX) / orgWidth * curWidth));
		}

		// Calculates absolute screen Y-coordinate based on DoD Y-coordinate
		public GLfloat NewY(double orgY)
		{
			return ((GLfloat)((orgHeight - (orgY)) / orgHeight * curHeight) + (GLfloat) offY);
		}

		// Calculates relative screen Y-coordinate based on DoD Y-coordinate
		public GLfloat NewYa(double orgY)
		{
			return ((GLfloat)((orgY) / orgHeight * curHeight));
		}

		private double orgWidth;
		private double orgHeight;
		private double curWidth;
		private double curHeight;
		private double offX; // offsets in case the screen dimension is not
		private double offY; // an exact multiple of 256 or 192
	}
}