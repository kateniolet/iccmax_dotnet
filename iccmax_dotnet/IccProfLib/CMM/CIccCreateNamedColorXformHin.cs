using RefIccMax.IccProfLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iccmax_dotnet.IccProfLib.CMM
{
    /**
**************************************************************************
* Type: Class
* 
* Purpose: 
*  Hint for creation of a named color xform
**************************************************************************
*/
    class CIccCreateNamedColorXformHint: IIccCreateXformHint
{
        public  CIccCreateNamedColorXformHint()
    {
            //TODO(Port)
        //csSpectralPcs = icSigNoSpectralData;
        //memset(&spectralRange, 0, sizeof(spectralRange));
        //memset(&biSpectralRange, 0, sizeof(biSpectralRange));
    }

    public virtual string GetHintType()  {return "CIccCreateNamedColorXformHint";}

icColorSpaceSignature csPcs;
icColorSpaceSignature csDevice;
icSpectralColorSignature csSpectralPcs;
        //TODO(Port) icSpectralRange in icProfileHeader
//icSpectralRange spectralRange;
//icSpectralRange biSpectralRange;
};

}
