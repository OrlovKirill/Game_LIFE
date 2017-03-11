using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIFE
    {

    //Cell – хранит свои координаты, свой тип (занята или свободна), подсчитывает действие (появится или исчезнуть), хранит для этого ссылки на 8 соседей.
    //Таким образом, вся логика жизни хранится в Cell.

    class Cell
        {

        public int x { get; }
        public int y { get; }
        public bool stateBefore { get; private set; }
        public bool stateAfter { get; set; }
        Cell[] neighborsArray = new Cell[8];

        public Cell (int x , int y , bool state)
            {
            this.x = x;
            this.y = y;
            this.stateAfter = state;
            }

        public void SetNeighbors (Cell n1, Cell n2 , Cell n3 , Cell n4 , Cell n5 , Cell n6, Cell n7 , Cell n8)
            {
            neighborsArray[0] = n1;
            neighborsArray[1] = n2;
            neighborsArray[2] = n3;
            neighborsArray[3] = n4;
            neighborsArray[4] = n5;
            neighborsArray[5] = n6;
            neighborsArray[6] = n7;
            neighborsArray[7] = n8;
            }

        public void Turn ()
            {
            //Клетка оживает, если: соседних живых клеток ровно 3
            //Клетка гаснет, если: соседних живых клеток меньше 2 или больше 3
            int n = 0;
            foreach (Cell cell in neighborsArray)
                if (cell != null && cell.stateBefore)
                    n++;
            if (n < 2 || n > 3)
                stateAfter = false;
            else
                if (n == 3)
                stateAfter = true;
                else
                stateAfter = stateBefore;
            }

        public void AfterInBefore ()
            {
            stateBefore = stateAfter;
            }
        public void BeforeInAfter ()
            {
            stateAfter = stateBefore;
            }
        public void AfterInFalse ()
            {
            stateAfter = false;
            }
        public void BeforeInFalse ()
            {
            stateBefore = false;
            }
        }
    }
