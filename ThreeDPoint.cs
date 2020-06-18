using System;

namespace MTF_Calc
{

    public partial class MainApp

    {
        public class ThreeDPoint
        {
            #region Fields

            /// <summary>
            /// X coordinate
            /// </summary>
            private double x = 0.0;

            /// <summary>
            /// Y coordinate
            /// </summary>
            private double y = 0.0;

            /// <summary>
            /// Z coordinate
            /// </summary>
            private double z = 0.0;

            #endregion // Fields

            #region Properties

            /// <summary>
            /// X coordinate
            /// </summary>
            public double X
            {
                get
                {
                    return this.x;
                }

                set
                {
                    this.x = value;
                }
            }

            /// <summary>
            /// Y coordinate
            /// </summary>
            public double Y
            {
                get
                {
                    return this.y;
                }

                set
                {
                    this.y = value;
                }
            }

            /// <summary>
            /// Z coordinate
            /// </summary>
            public double Z
            {
                get
                {
                    return this.z;
                }

                set
                {
                    this.z = value;
                }
            }

            #endregion // Properties

            #region Constructors

            /// <summary>
            /// Constructor - Initializes x, y, z to 0.0
            /// </summary>
            public ThreeDPoint()
            {
                ZeroXYZ();
            }

            /// <summary>
            /// Constructor - Initializes x, y, z to user-defined values
            /// </summary>
            /// <param name="x">X coordinate</param>
            /// <param name="y">Y coordinate</param>
            /// <param name="z">Z coordinate</param>
            public ThreeDPoint(double x, double y, double z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            /// <summary>
            /// Constructor - Initializes x, y, z from another ThreeDPoint
            /// </summary>
            /// <param name="point">ThreeDPoint</param>
            public ThreeDPoint(ThreeDPoint point)
            {
                if (point != null)
                {
                    this.x = point.X;
                    this.y = point.Y;
                    this.z = point.Z;
                }
                else
                {
                    ZeroXYZ();
                }
            }

            #endregion // Constructors

            #region Operator Overloads

            /// <summary>
            /// Override to compare 2 ThreeDPoint objects
            /// </summary>
            /// <param name="obj">Object of type ThreeDPoint</param>
            /// <returns>True if equal, else false</returns>
            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                    return false;
                }

                ThreeDPoint p = obj as ThreeDPoint;
                if ((object)p == null)
                {
                    return false;
                }

                return ((this.X == p.X) && (this.Y == p.Y) && (this.Z == p.Z));
            }

            /// <summary>
            /// Override to compare 2 ThreeDPoint objects
            /// </summary>
            /// <param name="p">Object of type ThreeDPoint</param>
            /// <returns>True if equal, else false</returns>
            public bool Equals(ThreeDPoint p)
            {
                if ((object)p == null)
                {
                    return false;
                }

                return ((this.X == p.X) && (this.Y == p.Y) && (this.Z == p.Z));
            }

            /// <summary>
            /// Override of GetHashCode() - functionality unchanged
            /// </summary>
            /// <returns>Base classes GetHashCode() return</returns>
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            /// <summary>
            /// Override of ToString() to provide the full coordinate
            /// </summary>
            /// <returns>String representation</returns>
            public override string ToString()
            {
                return String.Format("{0},{1},{2}", this.X, this.Y, this.Z);
            }

            #endregion // Operator Overloads

            /// <summary>
            /// Sets new values to x, y, z coordinates
            /// </summary>
            /// <param name="x">X value</param>
            /// <param name="y">Y value</param>
            /// <param name="z">Z value</param>
            public void UpdateAll(double x, double y, double z)
            {
                this.X = x;
                this.Y = y;
                this.Z = z;
            }

            /// <summary>
            /// Zeroes the values of x, y, z
            /// </summary>
            public void ZeroXYZ()
            {
                this.X = 0.0;
                this.Y = 0.0;
                this.Z = 0.0;
            }

            /// <summary>
            /// Subtracts the passed in offset from this ThreeDPoint object
            /// </summary>
            /// <param name="offset">Offset to be subtracted</param>
            public void Subtract(ThreeDPoint offset)
            {
                if (offset != null)
                {
                    this.X = this.X - offset.X;
                    this.Y = this.Y - offset.Y;
                    this.Z = this.Z - offset.Z;
                }
            }

            /// <summary>
            /// Round the X/Y/Z values to the nearest whole integer
            /// </summary>
            public void RoundValues()
            {
                this.X = Math.Round(this.X, 0, MidpointRounding.AwayFromZero);
                this.Y = Math.Round(this.Y, 0, MidpointRounding.AwayFromZero);
                this.Z = Math.Round(this.Z, 0, MidpointRounding.AwayFromZero);
            }

            /// <summary>
            /// Floor the X/Y/Z values
            /// </summary>
            public void FloorValues()
            {
                this.X = Math.Floor(this.X);
                this.Y = Math.Floor(this.Y);
                this.Z = Math.Floor(this.Z);
            }
        }
    }
}


