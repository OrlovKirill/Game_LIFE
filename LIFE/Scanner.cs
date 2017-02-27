using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace LIFE
    {
    public class Scanner
        {
        public event Patterndetected PatternDetected;
        private Form1 f1;
        private int size;
        private bool[,] Terrain;
        bool[,] ExtTer;

        public Scanner (Form1 f1)
            {
            this.f1 = f1;
            }

        public void Scan()
            {
            size = f1.GetSize;
            Terrain = new bool[size , size];
            Array.Copy(f1.GetTerrain , Terrain , size * size);
            Pen pen = new Pen(Color.LightGray , 1);

            ExtTer = new bool[size + 2 , size + 2];
            for (int i = 0 ; i < size ; i++)
                for (int j = 0 ; j < size ; j++)
                    ExtTer[i + 1 , j + 1] = Terrain[i , j];

            for (int i = 0 ; i < size - 1 ; i++)
                for (int j = 0 ; j < size - 1 ; j++)
                    if (Terrain[i , j])
                        if (IsBlock(i , j))
                            PatternDetected(i , j , 0);

            for (int i = 1 ; i < size - 1 ; i++)
                for (int j = 0 ; j < size - 3 ; j++)
                    if (Terrain[i , j])
                        if (IsHive1(i , j))
                            PatternDetected(i , j , 11);

            for (int i = 0 ; i < size - 3 ; i++)
                for (int j = 1 ; j < size - 1 ; j++)
                    if (Terrain[i , j])
                        if (IsHive2(i , j))
                            PatternDetected(i , j , 12);

            for (int i = 0 ; i < size - 2 ; i++)
                for (int j = 0 ; j < size ; j++)
                    if (Terrain[i , j])
                        if (IsFlasher1(i , j))
                            PatternDetected(i , j , 21);

            for (int i = 0 ; i < size ; i++)
                for (int j = 0 ; j < size - 2 ; j++)
                    if (Terrain[i , j])
                        if (IsFlasher2(i , j))
                            PatternDetected(i , j , 22);

            for (int i = 1 ; i < size - 1 ; i++)
                for (int j = 0 ; j < size - 2 ; j++)
                    if (Terrain[i , j])
                        if (IsGlider1(i , j))
                            PatternDetected(i , j , 31);

            for (int i = 2 ; i < size ; i++)
                for (int j = 1 ; j < size - 1 ; j++)
                    if (Terrain[i , j])
                        if (IsGlider2(i , j))
                            PatternDetected(i , j , 32);

            for (int i = 1 ; i < size - 1 ; i++)
                for (int j = 2 ; j < size ; j++)
                    if (Terrain[i , j])
                        if (IsGlider3(i , j))
                            PatternDetected(i , j , 33);

            for (int i = 0 ; i < size - 2 ; i++)
                for (int j = 1 ; j < size - 1 ; j++)
                    if (Terrain[i , j])
                        if (IsGlider4(i , j))
                            PatternDetected(i , j , 34);

            for (int i = 0 ; i < size - 9 ; i++)
                for (int j = 1 ; j < size - 1 ; j++)
                    if (Terrain[i , j])
                        if (IsPentaDek1(i , j))
                            PatternDetected(i , j , 41);

            for (int i = 1 ; i < size - 1 ; i++)
                for (int j = 0 ; j < size - 9 ; j++)
                    if (Terrain[i , j])
                        if (IsPentaDek2(i , j))
                            PatternDetected(i , j , 42);
            }

        private bool IsBlock (int x , int y)
            {
            if (Terrain[x + 1 , y] && Terrain[x , y + 1] && Terrain[x + 1 , y + 1])
                {
                if (x > 0)
                    if (Terrain[x - 1 , y] || Terrain[x - 1 , y + 1])   // верхняя грань
                        return false;
                    else
                        if (y > 0)
                        if (Terrain[x - 1 , y - 1])                     // верхний левый угол
                            return false;
                if (y > 0)
                    if (Terrain[x , y - 1] || Terrain[x + 1 , y - 1])   // левая грань
                        return false;
                    else
                        if (x < size - 2)
                        if (Terrain[x + 2 , y - 1])                     // нижний левый угол
                            return false;
                if (y < size - 2)
                    if (Terrain[x , y + 2] || Terrain[x + 1 , y + 2])   // правая грань
                        return false;
                    else
                        if (x > 0)
                        if (Terrain[x - 1 , y + 1])                     // верхний правый угол
                            return false;
                if (x < size - 2)
                    if (Terrain[x + 2 , y] || Terrain[x + 2 , y + 1])   // нижняя грань
                        return false;
                    else
                        if (y < size - 2)
                        if (Terrain[x + 2 , y + 2])                     // нижний правый угол
                            return false;
                return true;
                }
            else
                return false;
            }       // 0 "блок"

        private bool IsHive1 (int x , int y)
            {

            if (Terrain[x - 1 , y + 1] && Terrain[x + 1 , y + 1] && Terrain[x + 1 , y + 2] && Terrain[x - 1 , y + 2] && Terrain[x , y + 3])
                if (NumberOfCells(x - 1 , y , 5 , 6) == 6)
                    return true;

            return false;
            }       // 11 "вертикальный улей"

        private bool IsHive2 (int x , int y)
            {
            if (Terrain[x + 1 , y - 1] && Terrain[x + 1 , y + 1] && Terrain[x + 2 , y - 1] && Terrain[x + 2 , y + 1] && Terrain[x + 3 , y])
                if (NumberOfCells(x , y - 1 , 6 , 5) == 6)
                    return true;

            return false;
            }        // 12 "горизонтальный улей"

        private bool IsFlasher1 (int x , int y)
            {
            if (Terrain[x + 1 , y] && Terrain[x + 2 , y])
                if (NumberOfCells(x , y , 5 , 3) == 3)
                    return true;
            return false;
            }       // 21 "горизонтальная мигалка"

        private bool IsFlasher2 (int x , int y)
            {
            if (Terrain[x , y + 1] && Terrain[x , y + 2])
                if (NumberOfCells(x , y , 3 , 5) == 3)
                    return true;
            return false;
            }       // 22 "вертикальная мигалка"

        private bool IsGlider1 (int x , int y)
            {
            if (Terrain[x + 1 , y + 1] && Terrain[x - 1 , y + 2] && Terrain[x , y + 2] && Terrain[x + 1 , y + 2])
                if (NumberOfCells(x - 1 , y , 5 , 5) == 5)
                    return true;
            return false;
            }       // 31 "верхний планер"

        private bool IsGlider2 (int x , int y)
            {
            if (Terrain[x - 1 , y + 1] && Terrain[x - 2 , y + 1] && Terrain[x - 2 , y - 1] && Terrain[x - 2 , y])
                {
                int n = NumberOfCells(x - 2 , y - 1 , 5 , 5);
                if (y - 1 > 0 && Terrain[x , y - 2])
                    n--;
                if (y - 1 > 0 && x + 1 < size && Terrain[x + 1 , y - 2])
                    n--;
                if (x + 1 < size && y + 2 < size && Terrain[x + 1 , y + 2])
                    n--;
                if (n == 5)
                    return true;
                }
            return false;
            }       // 32 "правый планер"

        private bool IsGlider3 (int x , int y)
            {
            if (Terrain[x + 1 , y - 2] && Terrain[x - 1 , y - 2] && Terrain[x , y - 2] && Terrain[x - 1 , y - 1])
                {
                int n = NumberOfCells(x - 1 , y - 2 , 5 , 5);
                if (x + 2 < size && Terrain[x + 2 , y])
                    n--;
                if (y + 1 < size && x + 2 < size - 1 && Terrain[x + 2 , y + 1])
                    n--;
                if (x - 2 > 0 && y + 1 < size && Terrain[x - 2 , y + 1])
                    n--;
                if (n == 5)
                    return true;
                }
            return false;
            }       // 33 "нижний планер"

        private bool IsGlider4 (int x , int y)
            {
            if (Terrain[x + 1 , y - 1] && Terrain[x + 2 , y + 1] && Terrain[x + 2 , y - 1] && Terrain[x + 2 , y])
                {
                int n = NumberOfCells(x , y - 1 , 5 , 5);
                if (y + 2 < size && Terrain[x , y + 2])
                    n--;
                if (y - 1 > 0 && x - 1 >= 0 && Terrain[x - 1 , y - 2])
                    n--;
                if (x > 0 && y + 2 < size && Terrain[x - 1 , y + 2])
                    n--;
                if (n == 5)
                    return true;
                }
            return false;
            }       // 34 "левый планер"

        private bool IsPentaDek1 (int x , int y)
            {
            if (Terrain[x + 1 , y] && Terrain[x + 2 , y - 1] && Terrain[x + 2 , y + 1] && Terrain[x + 3 , y] && Terrain[x + 4 , y] && Terrain[x + 5 , y] && Terrain[x + 6 , y] && Terrain[x + 7 , y - 1] && Terrain[x + 7 , y + 1] && Terrain[x + 8 , y] && Terrain[x + 9 , y])
                {
                int n = NumberOfCells(x , y - 1 , 12 , 5);
                if (x > 0 && y > 1 && Terrain[x - 1 , y - 2])
                    n--;
                if (y > 1 && Terrain[x , y - 2])
                    n--;
                if (x > 0 && y + 2 < size && Terrain[x - 1 , y + 2])
                    n--;
                if (y + 2 < size && Terrain[x , y + 2])
                    n--;
                if (y > 1 && Terrain[x + 4 , y - 2])
                    n--;
                if (y > 1 && Terrain[x + 5 , y - 2])
                    n--;
                if (y + 2 < size && Terrain[x + 4 , y + 2])
                    n--;
                if (y + 2 < size && Terrain[x + 5 , y + 2])
                    n--;
                if (y + 2 < size && Terrain[x + 9 , y + 2])
                    n--;
                if (y + 2 < size && x + 10 < size && Terrain[x + 10 , y + 2])
                    n--;
                if (y - 2 > 0 && Terrain[x + 9 , y - 2])
                    n--;
                if (y - 2 > 0 && x + 10 < size && Terrain[x + 10 , y - 2])
                    n--;
                if (n == 12)
                    return true;
                }
            return false;
            }       // 41 "горизонтальный пентадек"

        private bool IsPentaDek2 (int x , int y)
            {
            if (Terrain[x , y + 1] && Terrain[x + 1 , y + 2] && Terrain[x - 1 , y + 2] && Terrain[x , y + 3] && Terrain[x , y + 4] && Terrain[x , y + 5] && Terrain[x , y + 6] && Terrain[x - 1 , y + 7] && Terrain[x + 1 , y + 7] && Terrain[x , y + 8] && Terrain[x , y + 9])
                {
                int n = NumberOfCells(x - 1 , y , 5 , 12);
                if (x > 1 && y > 0 && Terrain[x - 2 , y - 1])
                    n--;
                if (x > 1 && Terrain[x - 2 , y])
                    n--;
                if (y > 0 && x + 2 < size && Terrain[x + 2 , y - 1])
                    n--;
                if (x + 2 < size && Terrain[x + 2 , y])
                    n--;
                if (x > 1 && Terrain[x - 2 , y + 4])
                    n--;
                if (x > 1 && Terrain[x - 2 , y + 5])
                    n--;
                if (x + 2 < size && Terrain[x + 2 , y + 4])
                    n--;
                if (x + 2 < size && Terrain[x + 2 , y + 5])
                    n--;
                if (x + 2 < size && Terrain[x + 2 , y + 9])
                    n--;
                if (x + 2 < size && y + 10 < size && Terrain[x + 2 , y + 10])
                    n--;
                if (x - 2 > 0 && Terrain[x - 2 , y + 9])
                    n--;
                if (x - 2 > 0 && y + 10 < size && Terrain[x - 2 , y + 10])
                    n--;
                if (n == 12)
                    return true;
                }
            return false;
            }       // 42 "вертикальный пентадек"

        private int NumberOfCells (int x , int y , int onX , int onY)
            {
            int num = 0;
            for (int i = x ; i < x + onX ; i++)
                for (int j = y ; j < y + onY ; j++)
                    if (ExtTer[i , j])
                        num++;
            return num;
            }
        }
    }
