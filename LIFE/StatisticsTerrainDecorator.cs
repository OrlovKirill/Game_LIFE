using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;

namespace LIFE
    {
    class StatisticsTerrainDecorator: AbstractTerrainDecorator
        {
        Stopwatch time;
        Form1 f1;
        int beforeNumber = 0;
        int afterNumber = 0;
        decimal growth;
        public StatisticsTerrainDecorator (Form1 f1) : base(f1)
            {
            time = new Stopwatch();
            this.f1 = f1;
            //f1.Size = new Size(Convert.ToInt16(f1.Size.Height) , Convert.ToInt16(f1.Size.Width) + 200);
            
            }

        public override void MakeTurn ()
            {
            if (afterNumber == 0)
                {
                foreach (Cell cell in terrain.cells)
                    if (cell.stateAfter)
                        beforeNumber++;
                }
            else
                {
                beforeNumber = afterNumber;
                afterNumber = 0;
                }

            time.Start();
            terrain.MakeTurn();
            time.Stop();

            foreach (Cell cell in terrain.cells)
                if (cell.stateAfter)
                    afterNumber++;

            growth = Convert.ToDecimal(afterNumber) / Convert.ToDecimal(beforeNumber);

            f1.NumOfCells.Text = "CELLS: " + afterNumber.ToString();

            f1.TurnTime.Text = "TURN TIME: " + time.ElapsedMilliseconds.ToString() + " ms";
            time.Reset();
            if (growth >= 1)
                f1.Growth.Text = "GROWTH: +" + ((Math.Round(growth,4)) - 1).ToString("P");
            else
                f1.Growth.Text = "GROWTH: -" + (1 - Math.Round(growth,4)).ToString("P");

            f1.Update();
            }

        
        }
    }
