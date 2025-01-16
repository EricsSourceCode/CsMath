// Copyright Eric Chauvin 2025.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html


using System;



// With a matrix using two subscripts,
// the first subscript is the row and
// the second index is the column.
// <sub>row,column</sub>




// namespace



public class MatrixVec3
{
private MainData mData;
private int rowSize = 1;
private int columnSize = 1;
private int vecArSize = 0;
private Vector3.Vect[] vecArray;




private MatrixVec3()
{
}




internal MatrixVec3( MainData useMainData )
{
mData = useMainData;

rowSize = 1;
columnSize = 1;
vecArSize = 1;
vecArray = new Vector3.Vect[1];
}


internal int getRowSize()
{
return rowSize;
}



internal int getColumnSize()
{
return columnSize;
}


internal void setSize( int rows, int columns )
{
rowSize = rows;
columnSize = columns;

vecArSize = rows * columns;
vecArray = new Vector3.Vect[vecArSize];
}



private int getIndex( int row, int column )
{
RangeT.test( row, 0, rowSize - 1,
      "MatrixVec3.getIndex() row range." );

RangeT.test( column, 0, columnSize - 1,
      "MatrixVec3.getIndex() column range." );

// This can be optimized for the cache
// depending on if you are going sequentially
// through rows or columns.
// return (column * rowSize) + row;

int where =(row * columnSize) + column;
RangeT.test( where, 0, vecArSize - 1,
      "MatrixVec3.getIndex() where range." );

return where;
}



internal Vector3.Vect getVal( int row,
                              int column )
{
int where = getIndex( row, column );

return vecArray[where];
}



internal void setVal( int row,
                      int column,
                      Vector3.Vect vec )
{
int where = getIndex( row, column );

vecArray[where] = vec;
}



internal void makeTestPattern()
{
//       rows, cols
setSize( 50, 100 );

Vector3.Vect vec;

for( int row = 0; row < rowSize; row++ )
  {
  for( int col = 0; col < columnSize; col++ )
    {
    vec.x = col * 0.1;
    vec.y = row * 0.1;
    vec.z = 0; // col * col * -0.007;
    setVal( row, col, vec );
    }
  }
}




internal void setFromTwoVecs( VectorFlt vec1,
                              VectorFlt vec2 )
{
int columns = vec1.getSize();

if( columns != vec2.getSize())
  {
  throw new Exception(
    "MatrixVec3.setFromTwoVecs column size." );
  }

setSize( 2, columns );

Vector3.Vect vec;

for( int col = 0; col < columns; col++ )
  {
  vec.x = col * 0.1;
  vec.y = 0; // row * 0.1;
  vec.z = vec1.getVal( col );
  setVal( 0, col, vec );
  }

for( int col = 0; col < columns; col++ )
  {
  vec.x = col * 0.1;
  vec.y = 1.0; // row * 0.1;
  vec.z = vec2.getVal( col );
  setVal( 1, col, vec );
  }

}




internal void setFromDoubledVec( VectorFlt vec1 )
{
int columns = vec1.getSize();

setSize( 2, columns );

Vector3.Vect vec;

for( int col = 0; col < columns; col++ )
  {
  vec.x = col * 0.1;
  vec.y = 0; // row * 0.1;
  vec.z = vec1.getVal( col );
  setVal( 0, col, vec );
  }

for( int col = 0; col < columns; col++ )
  {
  vec.x = col * 0.1;
  vec.y = 1.0; // row * 0.1;
  // Repeat the same vector here.
  vec.z = vec1.getVal( col );
  setVal( 1, col, vec );
  }

}



} // Class
