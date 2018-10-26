/*
 * Copyright © Michael Taylor (P3Net)
 * All Rights Reserved
 * For changes from C++ to C# and .NET.
 *
 * http://www.michaeltaylorp3.net
 */
/****************************************
Daggorath PC-Port Version 0.2.1
Richard Hunerlach
November 13, 2002

The copyright for Dungeons of Daggorath
is held by Douglas J. Morgan.
(c) 1982, DynaMicro
*****************************************/
using System;
using System.Linq;

namespace DoD.Graphics
{
    /// <summary>This class is used to translate between original 256x192 coordinates and whichever modern coordinate system is used.</summary>
    /// <remarks>
    /// It sets 512x384 as the default, but when the video system gets set up during initialization, these values are set to
    /// whatever screen resolution is chosen.
    /// <para />
    /// This could be expanded later to do screen centering in cases where the available (or user-chosen) screen resolution
    /// is not an exact multiple of 256x192.
    /// <para />
    /// The absolute versions are used for most things, and the relative versions are used for drawing the font
    /// </remarks>
    public class Coordinate
    {
        #region Construction

        /// <summary>Initializes an instance of the <see cref="Coordinate"/> class.</summary>
        public Coordinate ()
        {
            orgWidth = 256.0;
            orgHeight = 192.0;
            curWidth = 512.0;
            curHeight = 384.0;
        }
        #endregion

        /// <summary>Sets the data members based on screen width.</summary>
        /// <remarks>
        /// Assumes a 4/3 width/height ratio.
        /// </remarks>
        public void SetCurWH ( double W )
        {
            throw new NotImplementedException();
            //curWidth = ((int) W / (int) 256) * (int) 256;
            //curHeight = (curWidth * 0.75);
            //offX = (W - curWidth) / 2;
            //offY = (offX * 0.75);
        }

        /// <summary>Calculates absolute screen X-coordinate based on DoD X-coordinate.</summary>
        public float NewX ( double orgX )
        {
            throw new NotImplementedException();
            //return ((GLfloat)((orgX) / orgWidth * curWidth) + (GLfloat) offX);
        }

        /// <summary>Calculates relative screen X-coordinate based on DoD X-coordinate.</summary>
        public float NewXa ( double orgX )
        {
            throw new NotImplementedException();
            //return ((GLfloat)((orgX) / orgWidth * curWidth));
        }

        /// <summary>Calculates absolute screen Y-coordinate based on DoD Y-coordinate.</summary>
        public float NewY ( double orgY )
        {
            throw new NotImplementedException();
            //return ((GLfloat)((orgHeight - (orgY)) / orgHeight * curHeight) + (GLfloat) offY);
        }

        /// <summary>Calculates relative screen Y-coordinate based on DoD Y-coordinate.</summary>
        public float NewYa ( double orgY )
        {
            throw new NotImplementedException();
            //return ((GLfloat)((orgY) / orgHeight * curHeight));
        }

        #region Private Members

        private double orgWidth;
        private double orgHeight;
        private double curWidth;
        private double curHeight;
        private double offX; // offsets in case the screen dimension is not
        private double offY; // an exact multiple of 256 or 192
        #endregion
    }
}