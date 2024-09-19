/*


// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html



// With a matrix using two subscripts,
// the first subscript is the row and
// the second index is the column.
// <sub>row,column</sub>

// For Neural Networks: Rows are
// superscripts and columns are subscripts.


using System;



// namespace


// If it's the same row but the column is
// incremented by one, then the values are
// next to each other in ram.  And in the same
// area of the RAM cache.  So on for-loops
// of columns and rows, the outside loop should
// be rows.  Then it's reading/writing to
// adjacent areas in ram in sequence.
// for( row
//   for( column



public class MatrixFlt
{
private MainData mData;
private FloatVec[] fArray;
private int lastAppend = 0;

====
Make it this type of array:
  static const Int32 digitArraySize = 500;
  static const Int32 last = digitArraySize *
                            digitArraySize;



  inline Int64 getV( const Int32 column,
                     const Int32 row ) const
    {
    Int32 where = (row *
                   digitArraySize)
                   + column;

    // RangeC::test( where, 0, last - 1,
       // "TwoDInt64.getV() range for where." );

    return aR[where];
    }




internal MatrixFlt( MainData mainData )
{
mData = mainData;

try
{
fArray = new float[1];

}
catch( Exception ) //  Except )
  {
  string showS = "MatrixFlt: not" +
     " enough memory.";
     //   + Except.Message;

  throw new Exception( showS );
  }
}



void freeAll()
{
fArray = new float[1];
}



=========
internal void setSize( int rows, int columns )
{
if( (rows == getRows()) &&
    (columns == getColumns()))
  return;

if( rows < 1 )
  {
  throw new Exception(
          "VectorArray.setSize() rows." );
  }

if( columns < 1 )
  {
  throw new Exception(
             "VectorArray.setSize() col." );
  }

try
{
fArray = new FloatVec[rows];
for( int count = 0; count < rows; count++ )
  fArray[count] = new FloatVec( mData );

}
catch( Exception ) // Except )
  {
  string showS = "VectorArray: not" +
     " enough memory.";

  throw new Exception( showS );
  }

for( int count = 0; count < rows; count++ )
  fArray[count].setSize( columns );

}





=====
internal float getVal( int row, int col )
{
RangeT.test( row, 0, fArray.Length - 1,
             "VectorArray.getVal() range." );

// Column is checked in the FloatVec.
return fArray[row].getVal( col );
}



internal void setVal( int row, int col,
                      float setTo )
{
RangeT.test( row, 0, fArray.Length - 1,
             "VectorArray.setVal() range." );

fArray[row].setVal( col, setTo );
}




internal void copy( VectorArray toCopy )
{
int rows = toCopy.getRows();
int columns = toCopy.getColumns();

setSize( rows, columns );

for( int row = 0; row < rows; row++ )
  {
  for( int col = 0; col < columns; col++ )
    {
    float val = toCopy.getVal( row, col );
    fArray[row].setVal( col, val );
    }
  }
}





A column vector on the right.
=====
internal void multiplyVecRight( FloatVec x,
                           FloatVec result )
{
int rows = getRows();
int cols = getColumns();
int xSize = x.getSize();
if( xSize != cols )
  {
  throw new Exception(
            "multiplyVec cols != vec size." );
  }

result.setSize( rows );

// Column vector on the right.
// a b    x   =  ax + by
// c d    y      cx + dy

// Column vector on the left.
// x     a c  =  (ax + by), (cx + dy)
// y     b d

// The dot product of a row with a column vector.

for( int row = 0; row < rows; row++ )
  {
  float toSet =  fArray[row].dotProd( x );
  result.setVal( row, toSet );
  }
}




  public struct Matrix3
    {
    public double R0C0;
    public double R0C1;
    public double R0C2;

    public double R1C0;
    public double R1C1;
    public double R1C2;

    public double R2C0;
    public double R2C1;
    public double R2C2;
    }


public static void Matrix3Multiply(
   ref Matrix3 Result, Matrix3 M1, Matrix3 M2 )
    {
// This is the dot product of a row and
// a column vector.  Multiplying a vector
// by a matrix means doing a dot product
// of each row in the matrix with the
// vector.  Result is a vector.

    Result.R0C0 = (M1.R0C0 * M2.R0C0) +
                  (M1.R0C1 * M2.R1C0) +
                  (M1.R0C2 * M2.R2C0);

    Result.R0C1 = (M1.R0C0 * M2.R0C1) +
                  (M1.R0C1 * M2.R1C1) +
                  (M1.R0C2 * M2.R2C1);

    Result.R0C2 = (M1.R0C0 * M2.R0C2) +
                  (M1.R0C1 * M2.R1C2) +
                  (M1.R0C2 * M2.R2C2);

    // Second row:
    Result.R1C0 = (M1.R1C0 * M2.R0C0) +
                  (M1.R1C1 * M2.R1C0) +
                  (M1.R1C2 * M2.R2C0);

    Result.R1C1 = (M1.R1C0 * M2.R0C1) +
                  (M1.R1C1 * M2.R1C1) +
                  (M1.R1C2 * M2.R2C1);

    Result.R1C2 = (M1.R1C0 * M2.R0C2) +
                  (M1.R1C1 * M2.R1C2) +
                  (M1.R1C2 * M2.R2C2);

    // Third row:
    Result.R2C0 = (M1.R2C0 * M2.R0C0) +
                  (M1.R2C1 * M2.R1C0) +
                  (M1.R2C2 * M2.R2C0);

    Result.R2C1 = (M1.R2C0 * M2.R0C1) +
                  (M1.R2C1 * M2.R1C1) +
                  (M1.R2C2 * M2.R2C1);

    Result.R2C2 = (M1.R2C0 * M2.R0C2) +
                  (M1.R2C1 * M2.R1C2) +
                  (M1.R2C2 * M2.R2C2);

    }



} // Class
*/
