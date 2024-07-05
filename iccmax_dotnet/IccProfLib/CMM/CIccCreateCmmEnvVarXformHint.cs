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
    *  Hint for getting CMM environment variable values
    **************************************************************************
*/
    public abstract class CIccCreateCmmEnvVarXformHint : IIccCreateXformHint
{
    public virtual string GetHintType() {return "CIccCreateCmmEnvVarXformHint";}
    public abstract IIccCmmEnvVarLookup GetNewCmmEnvVarLookup();
};
}
