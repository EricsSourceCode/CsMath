// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html



// For Neural Networks: Rows are
// superscripts and columns are subscripts.
// With a matrix using two subscripts,
// the first subscript is the row and
// the second index is the column.

using System;



// namespace



public class FloatMatrix
{
private MainData mData;
private FloatVec[] fArray;
private int lastAppend = 0;



internal FloatMatrix( MainData mainData )
{
mData = mainData;

try
{
fArray = new FloatVec[1];
fArray[0] = new FloatVec( mData );

}
catch( Exception ) //  Except )
  {
  string showS = "FloatMatrix: not" +
     " enough memory.";
     //   + Except.Message;

  throw new Exception( showS );
  }
}



void freeAll()
{
fArray = new FloatVec[1];
fArray[0] = new FloatVec( mData );
}




internal void setSize( int rows, int columns )
{
if( (rows == getRows()) &&
    (columns == getColumns()))
  return;

if( rows < 1 )
  {
  throw new Exception(
          "FloatMatrix.setSize() rows." );
  }

if( columns < 1 )
  {
  throw new Exception(
             "FloatMatrix.setSize() col." );
  }

try
{
fArray = new FloatVec[rows];
for( int count = 0; count < rows; count++ )
  fArray[count] = new FloatVec( mData );

}
catch( Exception ) // Except )
  {
  string showS = "FloatMatrix: not" +
     " enough memory.";

  throw new Exception( showS );
  }

for( int count = 0; count < rows; count++ )
  fArray[count].setSize( columns );

}




internal void resizeRows( int newSize )
{
int oldSize = getRows();
int columns = getColumns();

if( newSize == oldSize )
  return;

if( newSize < 1 )
  {
  throw new Exception(
          "FloatMatrix.resizeRows() rows." );
  }

try
{
Array.Resize( ref fArray, newSize );

if( newSize > oldSize )
  {
  for( int count = oldSize; count < newSize;
                                    count++ )
    {
    // An array of structs would get initialized,
    // but not an array of objects.
    fArray[count] = new FloatVec( mData );
    fArray[count].setSize( columns );
    }
  }
}
catch( Exception ) // Except )
  {
  // freeAll();
  throw new Exception(
       "Not enough memory for FloatMatrix." );

  }
}



internal int getRows()
{
return fArray.Length;
}



internal int getColumns()
{
return fArray[0].getSize();
}



internal float getVal( int row, int col )
{
RangeT.test( row, 0, fArray.Length - 1,
             "FloatMatrix.getVal() range." );

// Column is checked in the FloatVec.
return fArray[row].getVal( col );
}



internal void setVal( int row, int col,
                      float setTo )
{
RangeT.test( row, 0, fArray.Length - 1,
             "Float32Array.setVal() range." );

fArray[row].setVal( col, setTo );
}




internal void copy( FloatMatrix toCopy )
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



internal void clearLastAppend()
{
lastAppend = 0;
}


internal int getLastAppend()
{
return lastAppend;
}




internal void appendFromString( string toSet )
{
if( toSet == null )
  return;

int col = getColumns();

int max = toSet.Length;

// Or clear it to zeros on the end of it.
if( max < col )
  return;

int rows = getRows();
if( (lastAppend + 1 ) >= rows )
  resizeRows( rows + 1000 );

fArray[lastAppend].setFromString( toSet );
lastAppend++;
}



} // Class
