/****************************************
Daggorath PC-Port Version 0.2.1
Richard Hunerlach
November 13, 2002

The copyright for Dungeons of Daggorath
is held by Douglas J. Morgan.
(c) 1982, DynaMicro
*****************************************/

namespace DoD
{
    //TODO: Consider converting to Point or making an immutable struct.

    /// <summary>This class is used to translate between original 256x192
    /// coordinates and whichever modern coordinate system is used.</summary>
    /// <remarks>
    /// It sets 512x384 as the default, but when the video system
    /// gets set up during initialization, these values are set to
    /// whatever screen resolution is chosen.
    /// <para/>
    /// This could be expanded later to do screen centering in cases
    /// where the available (or user-chosen) screen resolution is
    /// not an exact multiple of 256x192.
    /// <para/>
    /// The absolute versions are used for most things, and the
    /// relative versions are used for drawing the font
    /// </remarks>
    public class Coordinate
    {
        #region Construction

        /// <summary>Initializes an instance of the <see cref="Coordinate"/> class.</summary>
        public Coordinate ()
        {
            _originalWidth = 256.0;
            _originalHeight = 192.0;
            _currentWidth = 512.0;
            _currentHeight = 384.0;
        }
        #endregion

        /// <summary>Sets the data members based on screen width.</summary>
        /// <param name="width">The width.</param>
        /// <remarks>
        /// Assumes a 4/3 width/height ratio.
        ///</remarks>
        public void SetCurWH ( double width )
        {
            _currentWidth = ((int)width / 256) * 256;
            _currentHeight = (_currentWidth * 0.75);
            _offsetX = (width - _currentWidth) / 2;
            _offsetY = (_offsetX * 0.75);
        }
        
        /// <summary>Calculates absolute screen X-coordinate based on DoD X-coordinate.</summary>
        /// <param name="originalValue">Original X value.</param>
        /// <returns>The new value.</returns>
        public float NewX ( double originalValue ) => ((float)((originalValue) / _originalWidth * _currentWidth) + (float)_offsetX);

        /// <summary>Calculates relative screen X-coordinate based on DoD X-coordinate.</summary>
        /// <param name="originalValue">Original X value.</param>
        /// <returns>The new value.</returns>
        public float NewXa ( double originalValue ) => ((float)((originalValue) / _originalWidth * _currentWidth));

        /// <summary>Calculates absolute screen Y-coordinate based on DoD Y-coordinate.</summary>
        /// <param name="originalValue">Original Y value.</param>
        /// <returns>The new value.</returns>
        public float NewY ( double originalValue ) => ((float)((_originalHeight - (originalValue)) / _originalHeight * _currentHeight) + (float)_offsetY);

        /// <summary>Calculates relative screen Y-coordinate based on DoD Y-coordinate.</summary>
        /// <param name="originalValue">Original Y value.</param>
        /// <returns>The new value.</returns>
        public float NewYa ( double originalValue ) => ((float)((originalValue) / _originalHeight * _currentHeight));

        #region Private Members

        private readonly double _originalWidth;
        private readonly double _originalHeight;
        private double _currentWidth;
        private double _currentHeight;
        private double _offsetX; // offsets in case the screen dimension is not
        private double _offsetY; // an exact multiple of 256 or 192
        #endregion
    }
}