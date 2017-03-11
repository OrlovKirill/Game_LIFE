using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIFE
    {
    class ScannerTerrainDecorator: AbstractTerrainDecorator
        {
        int size;
        bool[,] ter;
        bool[,] ExtTer;
        
        Form1 f1;

        public ScannerTerrainDecorator (Form1 f1) : base(f1)
            {
            this.f1 = f1;
            size = Form1.staticTerrain.GetLength(0);
            ter = new bool[size , size];
            Array.Copy(ter , Form1.staticTerrain , size * size);
            }

        public override void MakeTurn ()
            {
            terrain.MakeTurn();
            terrain.AfterInBefore();
            terrain.AfterInFalse();
            Scan();
            terrain.Draw(f1.pictureBox2);
            terrain.BeforeInAfter();
            }

        private void Scan ()
            {
            ExtTer = new bool[size + 2 , size + 2];
            for (int i = 0 ; i < size ; i++)
                for (int j = 0 ; j < size ; j++)
                    ExtTer[i + 1 , j + 1] = terrain.cells[i , j].stateBefore;


            for (int i = 0 ; i < size - 1 ; i++)
                for (int j = 0 ; j < size - 1 ; j++)
                    if (terrain.cells[i , j].stateBefore)
                        if (IsBlock(i , j))
                            PatternDetected(i , j , 0);

            for (int i = 1 ; i < size - 1 ; i++)
                for (int j = 0 ; j < size - 3 ; j++)
                    if (terrain.cells[i , j].stateBefore)
                        if (IsHive1(i , j))
                            PatternDetected(i , j , 11);

            for (int i = 0 ; i < size - 3 ; i++)
                for (int j = 1 ; j < size - 1 ; j++)
                    if (terrain.cells[i , j].stateBefore)
                        if (IsHive2(i , j))
                            PatternDetected(i , j , 12);

            for (int i = 0 ; i < size - 2 ; i++)
                for (int j = 0 ; j < size ; j++)
                    if (terrain.cells[i , j].stateBefore)
                        if (IsFlasher1(i , j))
                            PatternDetected(i , j , 21);

            for (int i = 0 ; i < size ; i++)
                for (int j = 0 ; j < size - 2 ; j++)
                    if (terrain.cells[i , j].stateBefore)
                        if (IsFlasher2(i , j))
                            PatternDetected(i , j , 22);

            for (int i = 1 ; i < size - 1 ; i++)
                for (int j = 0 ; j < size - 2 ; j++)
                    if (terrain.cells[i , j].stateBefore)
                        if (IsGlider1(i , j))
                            PatternDetected(i , j , 31);

            for (int i = 2 ; i < size ; i++)
                for (int j = 1 ; j < size - 1 ; j++)
                    if (terrain.cells[i , j].stateBefore)
                        if (IsGlider2(i , j))
                            PatternDetected(i , j , 32);

            for (int i = 1 ; i < size - 1 ; i++)
                for (int j = 2 ; j < size ; j++)
                    if (terrain.cells[i , j].stateBefore)
                        if (IsGlider3(i , j))
                            PatternDetected(i , j , 33);

            for (int i = 0 ; i < size - 2 ; i++)
                for (int j = 1 ; j < size - 1 ; j++)
                    if (terrain.cells[i , j].stateBefore)
                        if (IsGlider4(i , j))
                            PatternDetected(i , j , 34);

            for (int i = 0 ; i < size - 9 ; i++)
                for (int j = 1 ; j < size - 1 ; j++)
                    if (terrain.cells[i , j].stateBefore)
                        if (IsPentaDek1(i , j))
                            PatternDetected(i , j , 41);

            for (int i = 1 ; i < size - 1 ; i++)
                for (int j = 0 ; j < size - 9 ; j++)
                    if (terrain.cells[i , j].stateBefore)
                        if (IsPentaDek2(i , j))
                            PatternDetected(i , j , 42);

                
            bool IsBlock (int x , int y)
                {
                if (terrain.cells[x + 1 , y].stateBefore && terrain.cells[x , y + 1].stateBefore && terrain.cells[x + 1 , y + 1].stateBefore)
                    {
                    if (x > 0)
                        if (terrain.cells[x - 1 , y].stateBefore || terrain.cells[x - 1 , y + 1].stateBefore)   // верхняя грань
                            return false;
                        else
                            if (y > 0)
                            if (terrain.cells[x - 1 , y - 1].stateBefore)                     // верхний левый угол
                                return false;
                    if (y > 0)
                        if (terrain.cells[x , y - 1].stateBefore || terrain.cells[x + 1 , y - 1].stateBefore)   // левая грань
                            return false;
                        else
                            if (x < size - 2)
                            if (terrain.cells[x + 2 , y - 1].stateBefore)                     // нижний левый угол
                                return false;
                    if (y < size - 2)
                        if (terrain.cells[x , y + 2].stateBefore || terrain.cells[x + 1 , y + 2].stateBefore)   // правая грань
                            return false;
                        else
                            if (x > 0)
                            if (terrain.cells[x - 1 , y + 1].stateBefore)                     // верхний правый угол
                                return false;
                    if (x < size - 2)
                        if (terrain.cells[x + 2 , y].stateBefore || terrain.cells[x + 2 , y + 1].stateBefore)   // нижняя грань
                            return false;
                        else
                            if (y < size - 2)
                            if (terrain.cells[x + 2 , y + 2].stateBefore)                     // нижний правый угол
                                return false;
                    return true;
                    }
                else
                    return false;
                }       // 0 "блок"

            bool IsHive1 (int x , int y)
                {

                if (terrain.cells[x - 1 , y + 1].stateBefore && terrain.cells[x + 1 , y + 1].stateBefore && terrain.cells[x + 1 , y + 2].stateBefore && terrain.cells[x - 1 , y + 2].stateBefore && terrain.cells[x , y + 3].stateBefore)
                    if (NumberOfCells(x - 1 , y , 5 , 6) == 6)
                        return true;

                return false;
                }       // 11 "вертикальный улей"

            bool IsHive2 (int x , int y)
                {
                if (terrain.cells[x + 1 , y - 1].stateBefore && terrain.cells[x + 1 , y + 1].stateBefore && terrain.cells[x + 2 , y - 1].stateBefore && terrain.cells[x + 2 , y + 1].stateBefore && terrain.cells[x + 3 , y].stateBefore)
                    if (NumberOfCells(x , y - 1 , 6 , 5) == 6)
                        return true;

                return false;
                }        // 12 "горизонтальный улей"

            bool IsFlasher1 (int x , int y)
                {
                if (terrain.cells[x + 1 , y].stateBefore && terrain.cells[x + 2 , y].stateBefore)
                    if (NumberOfCells(x , y , 5 , 3) == 3)
                        return true;
                return false;
                }       // 21 "горизонтальная мигалка"

            bool IsFlasher2 (int x , int y)
                {
                if (terrain.cells[x , y + 1].stateBefore && terrain.cells[x , y + 2].stateBefore)
                    if (NumberOfCells(x , y , 3 , 5) == 3)
                        return true;
                return false;
                }       // 22 "вертикальная мигалка"

            bool IsGlider1 (int x , int y)
                {
                if (terrain.cells[x + 1 , y + 1].stateBefore && terrain.cells[x - 1 , y + 2].stateBefore && terrain.cells[x , y + 2].stateBefore && terrain.cells[x + 1 , y + 2].stateBefore)
                    if (NumberOfCells(x - 1 , y , 5 , 5) == 5)
                        return true;
                return false;
                }       // 31 "верхний планер"

            bool IsGlider2 (int x , int y)
                {
                if (terrain.cells[x - 1 , y + 1].stateBefore && terrain.cells[x - 2 , y + 1].stateBefore && terrain.cells[x - 2 , y - 1].stateBefore && terrain.cells[x - 2 , y].stateBefore)
                    {
                    int n = NumberOfCells(x - 2 , y - 1 , 5 , 5);
                    if (y - 1 > 0 && terrain.cells[x , y - 2].stateBefore)
                        n--;
                    if (y - 1 > 0 && x + 1 < size && terrain.cells[x + 1 , y - 2].stateBefore)
                        n--;
                    if (x + 1 < size && y + 2 < size && terrain.cells[x + 1 , y + 2].stateBefore)
                        n--;
                    if (n == 5)
                        return true;
                    }
                return false;
                }       // 32 "правый планер"

            bool IsGlider3 (int x , int y)
                {
                if (terrain.cells[x + 1 , y - 2].stateBefore && terrain.cells[x - 1 , y - 2].stateBefore && terrain.cells[x , y - 2].stateBefore && terrain.cells[x - 1 , y - 1].stateBefore)
                    {
                    int n = NumberOfCells(x - 1 , y - 2 , 5 , 5);
                    if (x + 2 < size && terrain.cells[x + 2 , y].stateBefore)
                        n--;
                    if (y + 1 < size && x + 2 < size - 1 && terrain.cells[x + 2 , y + 1].stateBefore)
                        n--;
                    if (x - 2 > 0 && y + 1 < size && terrain.cells[x - 2 , y + 1].stateBefore)
                        n--;
                    if (n == 5)
                        return true;
                    }
                return false;
                }       // 33 "нижний планер"

            bool IsGlider4 (int x , int y)
                {
                if (terrain.cells[x + 1 , y - 1].stateBefore && terrain.cells[x + 2 , y + 1].stateBefore && terrain.cells[x + 2 , y - 1].stateBefore && terrain.cells[x + 2 , y].stateBefore)
                    {
                    int n = NumberOfCells(x , y - 1 , 5 , 5);
                    if (y + 2 < size && terrain.cells[x , y + 2].stateBefore)
                        n--;
                    if (y - 1 > 0 && x - 1 >= 0 && terrain.cells[x - 1 , y - 2].stateBefore)
                        n--;
                    if (x > 0 && y + 2 < size && terrain.cells[x - 1 , y + 2].stateBefore)
                        n--;
                    if (n == 5)
                        return true;
                    }
                return false;
                }       // 34 "левый планер"

            bool IsPentaDek1 (int x , int y)
                {
                if (terrain.cells[x + 1 , y].stateBefore && terrain.cells[x + 2 , y - 1].stateBefore && terrain.cells[x + 2 , y + 1].stateBefore && terrain.cells[x + 3 , y].stateBefore && terrain.cells[x + 4 , y].stateBefore && terrain.cells[x + 5 , y].stateBefore && terrain.cells[x + 6 , y].stateBefore && terrain.cells[x + 7 , y - 1].stateBefore && terrain.cells[x + 7 , y + 1].stateBefore && terrain.cells[x + 8 , y].stateBefore && terrain.cells[x + 9 , y].stateBefore)
                    {
                    int n = NumberOfCells(x , y - 1 , 12 , 5);
                    if (x > 0 && y > 1 && terrain.cells[x - 1 , y - 2].stateBefore)
                        n--;
                    if (y > 1 && terrain.cells[x , y - 2].stateBefore)
                        n--;
                    if (x > 0 && y + 2 < size && terrain.cells[x - 1 , y + 2].stateBefore)
                        n--;
                    if (y + 2 < size && terrain.cells[x , y + 2].stateBefore)
                        n--;
                    if (y > 1 && terrain.cells[x + 4 , y - 2].stateBefore)
                        n--;
                    if (y > 1 && terrain.cells[x + 5 , y - 2].stateBefore)
                        n--;
                    if (y + 2 < size && terrain.cells[x + 4 , y + 2].stateBefore)
                        n--;
                    if (y + 2 < size && terrain.cells[x + 5 , y + 2].stateBefore)
                        n--;
                    if (y + 2 < size && terrain.cells[x + 9 , y + 2].stateBefore)
                        n--;
                    if (y + 2 < size && x + 10 < size && terrain.cells[x + 10 , y + 2].stateBefore)
                        n--;
                    if (y - 2 > 0 && terrain.cells[x + 9 , y - 2].stateBefore)
                        n--;
                    if (y - 2 > 0 && x + 10 < size && terrain.cells[x + 10 , y - 2].stateBefore)
                        n--;
                    if (n == 12)
                        return true;
                    }
                return false;
                }       // 41 "горизонтальный пентадек"

            bool IsPentaDek2 (int x , int y)
                {
                if (terrain.cells[x , y + 1].stateBefore && terrain.cells[x + 1 , y + 2].stateBefore && terrain.cells[x - 1 , y + 2].stateBefore && terrain.cells[x , y + 3].stateBefore && terrain.cells[x , y + 4].stateBefore && terrain.cells[x , y + 5].stateBefore && terrain.cells[x , y + 6].stateBefore && terrain.cells[x - 1 , y + 7].stateBefore && terrain.cells[x + 1 , y + 7].stateBefore && terrain.cells[x , y + 8].stateBefore && terrain.cells[x , y + 9].stateBefore)
                    {
                    int n = NumberOfCells(x - 1 , y , 5 , 12);
                    if (x > 1 && y > 0 && terrain.cells[x - 2 , y - 1].stateBefore)
                        n--;
                    if (x > 1 && terrain.cells[x - 2 , y].stateBefore)
                        n--;
                    if (y > 0 && x + 2 < size && terrain.cells[x + 2 , y - 1].stateBefore)
                        n--;
                    if (x + 2 < size && terrain.cells[x + 2 , y].stateBefore)
                        n--;
                    if (x > 1 && terrain.cells[x - 2 , y + 4].stateBefore)
                        n--;
                    if (x > 1 && terrain.cells[x - 2 , y + 5].stateBefore)
                        n--;
                    if (x + 2 < size && terrain.cells[x + 2 , y + 4].stateBefore)
                        n--;
                    if (x + 2 < size && terrain.cells[x + 2 , y + 5].stateBefore)
                        n--;
                    if (x + 2 < size && terrain.cells[x + 2 , y + 9].stateBefore)
                        n--;
                    if (x + 2 < size && y + 10 < size && terrain.cells[x + 2 , y + 10].stateBefore)
                        n--;
                    if (x - 2 > 0 && terrain.cells[x - 2 , y + 9].stateBefore)
                        n--;
                    if (x - 2 > 0 && y + 10 < size && terrain.cells[x - 2 , y + 10].stateBefore)
                        n--;
                    if (n == 12)
                        return true;
                    }
                return false;
                }       // 42 "вертикальный пентадек"
                

            int NumberOfCells (int x , int y , int onX , int onY)
                {
                int num = 0;
                for (int i = x ; i < x + onX ; i++)
                    for (int j = y ; j < y + onY ; j++)
                        if (ExtTer[i , j])
                            num++;
                return num;
                }
            }

        private void PatternDetected (int x , int y , int pat)
            {
            switch (pat)
                {
                case 0:

                    FillCell(x , y);
                    FillCell(x + 1 , y);
                    FillCell(x , y + 1);
                    FillCell(x + 1 , y + 1);
                    break;
                case 11:
                    FillCell(x , y);
                    FillCell(x - 1 , y + 1);
                    FillCell(x + 1 , y + 1);
                    FillCell(x + 1 , y + 2);
                    FillCell(x - 1 , y + 2);
                    FillCell(x , y + 3);
                    break;
                case 12:
                    FillCell(x , y);
                    FillCell(x + 1 , y - 1);
                    FillCell(x + 1 , y + 1);
                    FillCell(x + 2 , y - 1);
                    FillCell(x + 2 , y + 1);
                    FillCell(x + 3 , y);
                    break;
                case 21:
                    FillCell(x , y);
                    FillCell(x + 1 , y);
                    FillCell(x + 2 , y);
                    break;
                case 22:
                    FillCell(x , y);
                    FillCell(x , y + 1);
                    FillCell(x , y + 2);
                    break;
                case 31:
                    FillCell(x , y);
                    FillCell(x + 1 , y + 1);
                    FillCell(x - 1 , y + 2);
                    FillCell(x , y + 2);
                    FillCell(x + 1 , y + 2);
                    break;
                case 32:
                    FillCell(x , y);
                    FillCell(x - 1 , y + 1);
                    FillCell(x - 2 , y + 1);
                    FillCell(x - 2 , y - 1);
                    FillCell(x - 2 , y);
                    break;
                case 33:
                    FillCell(x , y);
                    FillCell(x + 1 , y - 2);
                    FillCell(x - 1 , y - 2);
                    FillCell(x , y - 2);
                    FillCell(x - 1 , y - 1);
                    break;
                case 34:
                    FillCell(x , y);
                    FillCell(x + 1 , y - 1);
                    FillCell(x + 2 , y + 1);
                    FillCell(x + 2 , y - 1);
                    FillCell(x + 2 , y);
                    break;
                case 41:
                    FillCell(x , y);
                    FillCell(x + 1 , y);
                    FillCell(x + 2 , y - 1);
                    FillCell(x + 2 , y + 1);
                    FillCell(x + 3 , y);
                    FillCell(x + 4 , y);
                    FillCell(x + 5 , y);
                    FillCell(x + 6 , y);
                    FillCell(x + 7 , y - 1);
                    FillCell(x + 7 , y + 1);
                    FillCell(x + 8 , y);
                    FillCell(x + 9 , y);
                    break;
                case 42:
                    FillCell(x , y);
                    FillCell(x , y + 1);
                    FillCell(x + 1 , y + 2);
                    FillCell(x - 1 , y + 2);
                    FillCell(x , y + 3);
                    FillCell(x , y + 4);
                    FillCell(x , y + 5);
                    FillCell(x , y + 6);
                    FillCell(x + 1 , y + 7);
                    FillCell(x - 1 , y + 7);
                    FillCell(x , y + 8);
                    FillCell(x , y + 9);
                    break;
                }

            }

        private void FillCell (int x , int y)
            {
            terrain.cells[x , y].stateAfter = true;
            }

        
        }
    }