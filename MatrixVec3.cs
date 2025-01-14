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



internal int getIndex( int row, int column )
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



internal Vector3.Vect getVal( int where )
{
RangeT.test( where, 0, vecArSize - 1,
           "MatrixVec3.getVal() range." );

return vecArray[where];
}



internal void setVal( int where,
                     Vector3.Vect vec )
{
RangeT.test( where, 0, vecArSize -  1,
           "MatrixVec3.setVal() range." );

vecArray[where] = vec;
}



internal void makeTestPattern()
{
//       rows, cols
setSize( 2, 3 );

Vector3.Vect vec;

for( int row = 0; row < rowSize; row++ )
  {
  for( int col = 0; col < columnSize; col++ )
    {
    vec.x = col * 0.1;
    vec.y = row * 0.1;
    vec.z = col * col * -0.007;
    int index = getIndex( row, col );
    setVal( index, vec );
    }
  }
}


internal void setFromTwoVecs( VectorFlt vec1,
                              VectorFlt vec2 )
{
=====

}



} // Class



