using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFERPMapco.Objetos.Utilerias
{
    class ApplyAnimation
    {
        public Size FormSize;
        public Alertas.AnimateStyle Style;

        public ApplyAnimation(Size formSize, Alertas.AnimateStyle style)
        {
            this.FormSize = formSize;
            this.Style = style;
        }
    }
}
