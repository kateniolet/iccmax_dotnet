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
    *  Interface for performing Cmm Environment Variable Lookup
    **************************************************************************
*/
    public interface IIccCmmEnvVarLookup
    {
        public bool GetEnvVar(icSigCmmEnvVar sig, icFloatNumber val);
        public bool IndexedEnvVar(icUInt32Number nIndex, ref icSigCmmEnvVar sig, ref icFloatNumber val);
    };
}
