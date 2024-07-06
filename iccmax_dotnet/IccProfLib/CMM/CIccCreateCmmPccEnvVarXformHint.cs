using iccmax_dotnet.IccProfLib.CMM;
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
    public abstract class CIccCreateCmmPccEnvVarXformHint :  IIccCreateXformHint
{
    virtual public string GetHintType() { return "CIccCreateCmmPccEnvVarXformHint"; }
    public abstract IIccCmmEnvVarLookup GetNewCmmEnvVarLookup();
};}
