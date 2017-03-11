using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIFE
    {
    abstract class AbstractTerrainDecorator : Terrain
        {
        protected Terrain terrain;

        public AbstractTerrainDecorator (Form1 f) : base(f)
            {
            }

        public void SetTerrain (Terrain terrain)
            {
            this.terrain = terrain;
            }

        }
    }
