using RefIccMax.IccProfLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace iccmax_dotnet.IccProfLib
{
    /** @file
        File:       IccUtil.h

        Contains:   Implementation of utility classes/functions

        Version:    V1

        Copyright:  � see ICC Software License
*/

    /*
     * The ICC Software License, Version 0.2
     *
     *
     * Copyright (c) 2003-2012 The International Color Consortium. All rights 
     * reserved.
     *
     * Redistribution and use in source and binary forms, with or without
     * modification, are permitted provided that the following conditions
     * are met:
     *
     * 1. Redistributions of source code must retain the above copyright
     *    notice, this list of conditions and the following disclaimer. 
     *
     * 2. Redistributions in binary form must reproduce the above copyright
     *    notice, this list of conditions and the following disclaimer in
     *    the documentation and/or other materials provided with the
     *    distribution.
     *
     * 3. In the absence of prior written permission, the names "ICC" and "The
     *    International Color Consortium" must not be used to imply that the
     *    ICC organization endorses or promotes products derived from this
     *    software.
     *
     *
     * THIS SOFTWARE IS PROVIDED ``AS IS'' AND ANY EXPRESSED OR IMPLIED
     * WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
     * OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
     * DISCLAIMED.  IN NO EVENT SHALL THE INTERNATIONAL COLOR CONSORTIUM OR
     * ITS CONTRIBUTING MEMBERS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
     * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
     * LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF
     * USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
     * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
     * OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT
     * OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF
     * SUCH DAMAGE.
     * ====================================================================
     *
     * This software consists of voluntary contributions made by many
     * individuals on behalf of the The International Color Consortium. 
     *
     *
     * Membership in the ICC is encouraged when this software is used for
     * commercial purposes. 
     *
     *  
     * For more information on The International Color Consortium, please
     * see <http://www.color.org/>.
     *  
     * 
     */

    ////////////////////////////////////////////////////////////////////// 
    // HISTORY:
    //
    // -Initial implementation by Max Derhak 5-15-2003
    // -Port to C# by Katrina Niolet 07-05-2024
    //
    //////////////////////////////////////////////////////////////////////
#if PORT

        ICCPROFLIB_API void* icRealloc(void* ptr, size_t size);
#endif

    public static class Util
    {
        public static bool icIsNear(icFloatNumber v1, icFloatNumber v2, icFloatNumber nearRange = 1.0e-8f)
        {
            return Math.Abs(v1 - v2) <= nearRange;
        }

        public static double icRoundOffset(double v)
        {
            if (v < 0.0)
                return v - 0.5;
            else
                return v + 0.5;
        }

        public static icValidateStatus icMaxStatus(icValidateStatus s1, icValidateStatus s2)
        {
            return s1 > s2 ? s1 : s2;
        }

        static icInt32Number icHexDigit(icChar digit)
        {
            if (digit >= '0' && digit <= '9')
                return digit - '0';
            if (digit >= 'A' && digit <= 'F')
                return digit - 'A' + 10;
            /*  if (digit>='a' && digit<='f')
                return digit-'a'+10;*/
            return -1;
        }

        public static bool icIsSpaceCLR(icColorSpaceSignature sig)
        {
            icChar[] szSig = new icChar[5];
            szSig[0] = (icChar)((uint)sig >> 24);
            szSig[1] = (icChar)((uint)sig >> 16);
            szSig[2] = (icChar)((uint)sig >> 8);
            szSig[3] = (icChar)((uint)sig);
            szSig[4] = '\0';

            icInt32Number d0 = icHexDigit(szSig[0]);

            if (szSig[0] == 'n' && szSig[1] == 'c')
                return true;
            else if (new string(szSig.Skip(1).Take(3).ToArray()) == "CLR")
            {
                d0 = icHexDigit(szSig[0]);
                if (d0 >= 1)
                    return true;
            }
            else if (new string(szSig).Substring(2, 2) == "CL")
            {
                d0 = icHexDigit(szSig[0]);
                icInt32Number d1 = icHexDigit(szSig[1]);

                if (d0 >= 0 && d1 >= 0)
                {
                    icInt32Number n = (d0 << 4) + d1;

                    if (n > 0xf)
                        return true;
                }
            }
            return false;
        }


        public static void icColorIndexName(out icChar[] szName, icColorSpaceSignature csSig,
                              int nIndex, int nColors, icChar[] szUnknown)
        {
            icChar[] szSig = new icChar[5];
            int i;

            if (csSig != Global.icSigUnknownData)
            {
                szSig[0] = (icChar)((uint)csSig >> 24);
                szSig[1] = (icChar)((uint)csSig >> 16);
                szSig[2] = (icChar)((uint)csSig >> 8);
                szSig[3] = (icChar)((uint)csSig);
                szSig[4] = '\0';

                for (i = 3; i > 0; i--)
                {
                    if (szSig[i] == ' ')
                        szSig[i] = '\0';
                }
                if (nColors == 1)
                {
                    szName = szSig;
                }
                else if (nColors == new string(szSig).Length)
                {
                    string name = "%s_%c";
                    string.Format(name, szSig, szSig[nIndex]);
                    szName = name.ToCharArray();
                }
                else
                {
                    string name = "%s_%d";
                    string.Format(name, szSig, nIndex + 1);
                    szName = name.ToCharArray();
                }
            }
            else if (nColors == 1)
            {
                szName = szUnknown;
            }
            else
            {
                string name = "%s_%d";
                string.Format(name, szUnknown, nIndex + 1);
                szName = name.ToCharArray();
            }
        }


        public static void icColorValue(out icChar[] szValue, icFloatNumber nValue,
                                  icColorSpaceSignature csSig, int nIndex, bool bUseLegacy = false)
        {
            if (csSig == icColorSpaceSignature.icSigLabData)
            {
                if (!bUseLegacy)
                {
                    if (nIndex == 0 || nIndex > 2)
                    {
                        string value = "%7.3lf";
                        string.Format(value, nValue * 100.0);
                        szValue = value.ToCharArray();
                    }
                    else
                    {
                        string value = "%8.3lf";
                        string.Format(value, nValue * 255.0 - 128.0);
                        szValue = value.ToCharArray();
                    }
                }
                else
                {
                    if (nIndex == 0 || nIndex > 2)
                    {
                        string value = "%7.3lf";
                        string.Format(value, nValue * 100.0 * 65535.0 / 65280.0);
                        szValue = value.ToCharArray();
                    }
                    else
                    {

                        string value = "%8.3lf";
                        string.Format(value, nValue * 255.0 * 65535.0 / 65280.0 - 128.0);
                        szValue = value.ToCharArray();
                    }
                }
            }
            else if (csSig == Global.icSigUnknownData)
            {
                string value = "%8.3lf";
                string.Format(value, nValue);
                szValue = value.ToCharArray();

            }
            else
            {
                if (nIndex == 0 || nIndex > 2)
                {
                    string value = "%8.3lf";
                    string.Format(value, nValue);
                    szValue = value.ToCharArray();
                }
                else
                {
                    string value = "%8.3lf";
                    string.Format(value, nValue * 100.0);
                    szValue = value.ToCharArray();
                }
            }
        }

        public static icFloatNumber icFtoD(icS15Fixed16Number num)
        {
            icFloatNumber rv = (icFloatNumber)((double)num / 65536.0);

            return rv;
        }

        public static icS15Fixed16Number icDtoF(icFloatNumber num)
        {
            icS15Fixed16Number rv;

            if (num < -32768.0f)
                num = -32768.0f;
            else if (num > 32767.0f)
                num = 32767.0f;

            rv = (icS15Fixed16Number)icRoundOffset((double)num * 65536.0);

            return rv;
        }

        public static icU16Fixed16Number icDtoUF(icFloatNumber num)
        {
            icU16Fixed16Number rv;

            if (num < 0)
                num = 0;
            else if (num > 65535.0f)
                num = 65535.0f;

            rv = (icU16Fixed16Number)icRoundOffset((double)num * 65536.0);

            return rv;
        }

        public static icFloatNumber icUFtoD(icU16Fixed16Number num)
        {
            icFloatNumber rv = (icFloatNumber)((double)num / 65536.0);

            return rv;
        }

        public static icU1Fixed15Number icDtoUSF(icFloatNumber num)
        {
            icU1Fixed15Number rv;

            if (num < 0f)
                num = 0f;
            else if (num > 65535.0f / 32768.0f)
                num = 65535.0f / 32768.0f;

            rv = (icU1Fixed15Number)icRoundOffset(num * 32768.0f);

            return rv;
        }

        public static icFloatNumber icUSFtoD(icU1Fixed15Number num)
        {
            icFloatNumber rv = (icFloatNumber)((icFloatNumber)num / 32768.0f);

            return rv;
        }

        public static icU8Fixed8Number icDtoUCF(icFloatNumber num)
        {
            icU8Fixed8Number rv;

            if (num < 0f)
                num = 0f;
            else if (num > 255.0f)
                num = 255.0f;

            rv = (icU8Fixed8Number)icRoundOffset(num * 256.0f);

            return rv;
        }

        public static icFloatNumber icUCFtoD(icU8Fixed8Number num)
        {
            icFloatNumber rv = (icFloatNumber)((icFloatNumber)num / 256.0f);

            return rv;
        }

        public static bool icIsS15Fixed16NumberNear(icS15Fixed16Number F, icFloatNumber D)
        {
            icFloatNumber v = icFtoD(F);

            return (icUInt32Number)(F * 10000.0f + 0.5) == (icUInt32Number)(D * 10000.0f + 0.5);
        }

        public static bool icIsIllumD50(icXYZNumber xyz)
        {
            return icIsS15Fixed16NumberNear(xyz.X, 0.9642f) &&
                   icIsS15Fixed16NumberNear(xyz.Y, 1.0000f) &&
                   icIsS15Fixed16NumberNear(xyz.Z, 0.8249f);
        }

        /**
        **************************************************************************
        * Name: icMatrixInvert3x3
        * 
        * Purpose: 
        *  Inversion of a 3x3 matrix using the Adjoint Cofactor and the determinant of
        *  the 3x3 matrix.
        *
        *  Note: Matrix index positions:
        *     0 1 2
        *     3 4 5
        *     6 7 8
        * 
        * Args: 
        *  M = matrix to invert.
        * 
        * Return: 
        *  true = matrix is invertible and stored back into M, false = matrix is not
        *  invertible.
        **************************************************************************
*/
        public static bool icMatrixInvert3x3(ref icFloatNumber[] M)
        {
            const icFloatNumber epsilon = 1e-8f;

            icFloatNumber m48 = M[4] * M[8];
            icFloatNumber m75 = M[7] * M[5];
            icFloatNumber m38 = M[3] * M[8];
            icFloatNumber m65 = M[6] * M[5];
            icFloatNumber m37 = M[3] * M[7];
            icFloatNumber m64 = M[6] * M[4];

            icFloatNumber det = M[0] * (m48 - m75) -
              M[1] * (m38 - m65) +
              M[2] * (m37 - m64);

            if (det > -epsilon && det < epsilon)
                return false;

            icFloatNumber[] Co = new icFloatNumber[9];

            Co[0] = +(m48 - m75);
            Co[1] = -(m38 - m65);
            Co[2] = +(m37 - m64);

            Co[3] = -(M[1] * M[8] - M[7] * M[2]);
            Co[4] = +(M[0] * M[8] - M[6] * M[2]);
            Co[5] = -(M[0] * M[7] - M[6] * M[1]);

            Co[6] = +(M[1] * M[5] - M[4] * M[2]);
            Co[7] = -(M[0] * M[5] - M[3] * M[2]);
            Co[8] = +(M[0] * M[4] - M[3] * M[1]);

            M[0] = Co[0] / det;
            M[1] = Co[3] / det;
            M[2] = Co[6] / det;

            M[3] = Co[1] / det;
            M[4] = Co[4] / det;
            M[5] = Co[7] / det;

            M[6] = Co[2] / det;
            M[7] = Co[5] / det;
            M[8] = Co[8] / det;

            return true;
        }

        /**
        **************************************************************************
        * Name: icMatrixMultiply3x3
        * 
        * Purpose: 
        *  Multiply two 3x3 matricies resulting in a 3x3 matrix.
        *
        *  Note: Matrix index positions:
        *     0 1 2
        *     3 4 5
        *     6 7 8
        * 
        * Args: 
        *  result = matrix to recieve result.
        *  l = left matrix to multiply (matrix multiplication is order dependent)
        *  r = right matrix to multiply (matrix multiplicaiton is order dependent)
        *
        **************************************************************************
*/
        public static void icMatrixMultiply3x3(out icFloatNumber[] result,
                                 icFloatNumber[] l,
                                icFloatNumber[] r)
        {
            const uint e11 = 0;
            const uint e12 = 1;
            const uint e13 = 2;
            const uint e21 = 3;
            const uint e22 = 4;
            const uint e23 = 5;
            const uint e31 = 6;
            const uint e32 = 7;
            const uint e33 = 8;

            result = new icFloatNumber[9];

            result[e11] = l[e11] * r[e11] + l[e12] * r[e21] + l[e13] * r[e31];
            result[e12] = l[e11] * r[e12] + l[e12] * r[e22] + l[e13] * r[e32];
            result[e13] = l[e11] * r[e13] + l[e12] * r[e23] + l[e13] * r[e33];
            result[e21] = l[e21] * r[e11] + l[e22] * r[e21] + l[e23] * r[e31];
            result[e22] = l[e21] * r[e12] + l[e22] * r[e22] + l[e23] * r[e32];
            result[e23] = l[e21] * r[e13] + l[e22] * r[e23] + l[e23] * r[e33];
            result[e31] = l[e31] * r[e11] + l[e32] * r[e21] + l[e33] * r[e31];
            result[e32] = l[e31] * r[e12] + l[e32] * r[e22] + l[e33] * r[e32];
            result[e33] = l[e31] * r[e13] + l[e32] * r[e23] + l[e33] * r[e33];
        }

        /**
**************************************************************************
* Name: icVectorApplyMatrix3x3
* 
* Purpose: 
*  Applies a 3x3 matrix to a 3 element column vector. 
*
*  Note: Matrix index positions:
*     0 1 2
*     3 4 5
*     6 7 8
* 
*  Note: result = m x v
*
* Args: 
*  result = vector to receive result.
*  m = matrix to multiply
*  v = vector to apply matrix to
*
**************************************************************************
*/
        public static void icVectorApplyMatrix3x3(out icFloatNumber[] result,
                            icFloatNumber[] m,
                            icFloatNumber[] v)
        {
            const uint e11 = 0;
            const uint e12 = 1;
            const uint e13 = 2;
            const uint e21 = 3;
            const uint e22 = 4;
            const uint e23 = 5;
            const uint e31 = 6;
            const uint e32 = 7;
            const uint e33 = 8;
            result = new icFloatNumber[3];
            result[0] = m[e11] * v[0] + m[e12] * v[1] + m[e13] * v[2];
            result[1] = m[e21] * v[0] + m[e22] * v[1] + m[e23] * v[2];
            result[2] = m[e31] * v[0] + m[e32] * v[1] + m[e33] * v[2];
        }

        //TODO Port can we do this natively?
        public static icFloatNumber icF16toF(icFloat16Number num)
        {
            icUInt16Number numsgn, numexp, nummnt;
            icUInt32Number rv, rvsgn, rvexp, rvmnt;
            icInt32Number tmpexp;
            icFloatNumber rvfp, rvf;
            int exp;

            if (((uint)num & (uint)0x7FFF) == 0)
            {
                rv = ((icUInt32Number)num) << 16;
            }
            else
            {
                numsgn = (ushort)((ushort)num & (ushort)0x8000);
                numexp = (ushort)((ushort)num & (ushort)0x7C00);
                nummnt = (ushort)((ushort)num & (ushort)0x03FF);
                if (numexp == 0)
                {
                    exp = -1;
                    do
                    {
                        exp++;
                        nummnt <<= 1;
                    } while ((nummnt & 0x0400) == 0); // Shift until leading bit overflows into exponent bit
                    rvsgn = ((icUInt32Number)numsgn) << 16;
                    tmpexp = (int)(((icUInt32Number)(numexp >> 10)) - 15 + 127 - exp);
                    rvexp = (icUInt32Number)(tmpexp << 23);
                    rvmnt = ((icUInt32Number)(nummnt & 0x03FFu)) << 13;
                    rv = (rvsgn | rvexp | rvmnt);
                }
                else if (numexp == 0x7C00)
                {
                    if (nummnt == 0)
                    {
                        rv = (((icUInt32Number)numsgn) << 16) | ((icUInt32Number)0x7F800000);
                    }
                    else
                    {
                        rv = (icUInt32Number)0xFFC00000;
                    }
                }
                else
                {
                    rvsgn = ((icUInt32Number)numsgn) << 16;
                    tmpexp = (int)(((icUInt32Number)(numexp >> 10)) - 15 + 127);
                    rvexp = (icUInt32Number)(tmpexp << 23);
                    rvmnt = ((icUInt32Number)nummnt) << 13;
                    rv = (rvsgn | rvexp | rvmnt);
                }
            }
            rvfp = (icFloatNumber)rv;
            rvf = rvfp;
            return rvf;
        }

        //TODO Port can we do this natively?
        public static icFloat16Number icFtoF16(icFloat32Number num)
        {
            icUInt16Number rv;
            icUInt16Number rvsgn, rvexp, rvmnt;
            icUInt32Number flt, fltp, fltsgn, fltexp, fltmnt;
            int exp;

            fltp = (icUInt32Number)num;
            flt = fltp;
            if ((flt & 0x7FFFFFFF) == 0)
            {
                rv = (icUInt16Number)(flt >> 16);
            }
            else
            {
                fltsgn = flt & 0x80000000;
                fltexp = flt & 0x7F800000;
                fltmnt = flt & 0x007FFFFF;
                if (fltexp == 0)
                {
                    rv = (icUInt16Number)(fltsgn >> 16);
                }
                else if (fltexp == 0x7F800000)
                {
                    if (fltmnt == 0)
                    {
                        rv = (icUInt16Number)((fltsgn >> 16) | 0x7C00); // Signed Inf
                    }
                    else
                    {
                        rv = (icUInt16Number)0xFE00; // NaN
                    }
                }
                else
                { // Normalized number
                    rvsgn = (icUInt16Number)(fltsgn >> 16);
                    exp = ((int)(fltexp >> 23)) - 127 + 15;
                    if (exp >= 0x1F)
                    {  // Overflow
                        rv = (icUInt16Number)((fltsgn >> 16) | 0x7C00); // Signed Inf
                    }
                    else if (exp <= 0)
                    {  // Underflow
                        if ((14 - exp) > 24)
                        {
                            rvmnt = (icUInt16Number)0;  // Set mantissa to zero
                        }
                        else
                        {
                            fltmnt |= 0x00800000;  // Include hidden leading bit
                            rvmnt = (icUInt16Number)(fltmnt >> (14 - exp));
                            if (((fltmnt >> (13 - exp)) & 0x00000001) != 0) // Rounding?
                                rvmnt += (icUInt16Number)1;
                        }
                        rv = ((ushort)(rvsgn | rvmnt));
                    }
                    else
                    {
                        rvexp = (icUInt16Number)(exp << 10);
                        rvmnt = (icUInt16Number)(fltmnt >> 13);
                        if ((fltmnt & 0x00001000) != 0) // Rounding?
                            rv = (ushort)((rvsgn | rvexp | rvmnt) + (icUInt16Number)1);
                        else
                            rv = ((ushort)(rvsgn | rvexp | rvmnt));
                    }
                }
            }
            return (icFloat16Number)rv;
        }


        /*0 to 255 <-> 0.0 to 1.0*/
        public static icUInt8Number icFtoU8(icFloatNumber num)
        {
            icUInt8Number rv;

            if (num < 0)
                num = 0;
            else if (num > 1.0)
                num = 1.0f;

            rv = (icUInt8Number)icRoundOffset(num * 255.0);

            return rv;
        }
        public static icFloatNumber icU8toF(icUInt8Number num)
        {
            icFloatNumber rv = (icFloatNumber)((icFloatNumber)num / 255.0);

            return rv;
        }

        /*0 to 65535 <-> 0.0 to 1.0*/
        public static icUInt16Number icFtoU16(icFloatNumber num)
        {
            icUInt16Number rv;

            if (num < 0)
                num = 0;
            else if (num > 1.0)
                num = 1.0f;

            rv = (icUInt16Number)icRoundOffset(num * 65535.0);

            return rv;
        }
        public static icFloatNumber icU16toF(icUInt16Number num)
        {
            icFloatNumber rv = (icFloatNumber)((icFloatNumber)num / 65535.0);

            return rv;
        }

        /*0 to 255 <-> -128.0 to 127.0*/
        public static icUInt8Number icABtoU8(icFloatNumber num)
        {
            icFloatNumber v = num + 128.0f;
            if (v < 0)
                v = 0;
            else if (v > 255)
                v = 255;

            return (icUInt8Number)(v + 0.5);
        }
        public static icFloatNumber icU8toAB(icUInt8Number num)
        {
            return (icFloatNumber)num - 128.0f;
        }

        //TODO(PORT) is ref or out here?
        public static void icNormXYZ(ref icFloatNumber[] XYZ, icFloatNumber[] WhiteXYZ = null)
        {
            if (WhiteXYZ == null)
                WhiteXYZ = Global.icD50XYZ;

            XYZ[0] = XYZ[0] / WhiteXYZ[0];
            XYZ[1] = XYZ[1] / WhiteXYZ[1];
            XYZ[2] = XYZ[2] / WhiteXYZ[2];

        }
        //TODO(PORT) is ref or out here?
        public static void icDeNormXYZ(ref icFloatNumber[] XYZ, icFloatNumber[] WhiteXYZ = null)
        {
            if (WhiteXYZ == null)
                WhiteXYZ = Global.icD50XYZ;

            XYZ[0] = XYZ[0] * WhiteXYZ[0];
            XYZ[1] = XYZ[1] * WhiteXYZ[1];
            XYZ[2] = XYZ[2] * WhiteXYZ[2];
        }


        public static icFloatNumber icCubeth(icFloatNumber v)
        {
            if (v > 0.008856)
            {
                return (icFloatNumber)Global.ICC_CBRTF(v);
            }
            else
            {
                return (icFloatNumber)(7.787037037037037037037037037037 * v + 16.0 / 116.0);
            }
        }
        public static icFloatNumber icICubeth(icFloatNumber v)
        {

            if (v > 0.20689303448275862068965517241379)
                return v * v * v;
            else
#if !SAMPLEICC_NOCLIPLABTOXYZ
            if (v > 16.0 / 116.0)
#endif
                return (icFloatNumber)((v - 16.0 / 116.0) / 7.787037037037037037037037037037);
#if !SAMPLEICC_NOCLIPLABTOXYZ
            else
                return 0.0f;
#endif
        }

        public static void icXYZtoLab(ref icFloatNumber[] Lab, icFloatNumber[] XYZ = null, icFloatNumber[] WhiteXYZ = null)
        {
            icFloatNumber Xn, Yn, Zn;

            if (XYZ == null)
                XYZ = Lab;

            if (WhiteXYZ == null)
                WhiteXYZ = Global.icD50XYZ;

            Xn = icCubeth(XYZ[0] / WhiteXYZ[0]);
            Yn = icCubeth(XYZ[1] / WhiteXYZ[1]);
            Zn = icCubeth(XYZ[2] / WhiteXYZ[2]);

            Lab[0] = (icFloatNumber)(116.0 * Yn - 16.0);
            Lab[1] = (icFloatNumber)(500.0 * (Xn - Yn));
            Lab[2] = (icFloatNumber)(200.0 * (Yn - Zn));
        }

        public static void icLabtoXYZ(ref icFloatNumber[] XYZ, icFloatNumber[] Lab = null, icFloatNumber[] WhiteXYZ = null)
            {
            if (Lab == null)
                Lab = XYZ;

            if (WhiteXYZ == null)
                WhiteXYZ = Global.icD50XYZ;

            icFloatNumber fy = (icFloatNumber)((Lab[0] + 16.0) / 116.0);

            XYZ[0] = icICubeth((icFloatNumber)(Lab[1] / 500.0 + fy)) * WhiteXYZ[0];
            XYZ[1] = icICubeth(fy) * WhiteXYZ[1];
            XYZ[2] = icICubeth((icFloatNumber)(fy - Lab[2] / 200.0)) * WhiteXYZ[2];
        }
#if PORT

        ICCPROFLIB_API void icLab2Lch(icFloatNumber* Lch, icFloatNumber* Lab = NULL);
        ICCPROFLIB_API void icLch2Lab(icFloatNumber* Lab, icFloatNumber* Lch = NULL);

        ICCPROFLIB_API icFloatNumber icMin(icFloatNumber v1, icFloatNumber v2);
        ICCPROFLIB_API icFloatNumber icMax(icFloatNumber v1, icFloatNumber v2);

        ICCPROFLIB_API icUInt32Number icIntMin(icUInt32Number v1, icUInt32Number v2);
        ICCPROFLIB_API icUInt32Number icIntMax(icUInt32Number v1, icUInt32Number v2);

        ICCPROFLIB_API icFloatNumber icDeltaE(const icFloatNumber* Lab1, const icFloatNumber* Lab2);

        ICCPROFLIB_API icFloatNumber icRmsDif(const icFloatNumber* v1, const icFloatNumber* v2, icUInt32Number nSample);

        ICCPROFLIB_API bool icValidTagPos(const icPositionNumber& pos, icUInt32Number nTagHeaderSize, icUInt32Number nTagSize, bool bAllowEmpty = false);
        ICCPROFLIB_API bool icValidOverlap(const icPositionNumber& pos1, const icPositionNumber& pos2, bool bAllowSame = true);

        /**Floating point encoding of Lab in PCS is in range 0.0 to 1.0 */
        ///Here are some conversion routines to convert to regular Lab encoding
        ICCPROFLIB_API void icLabFromPcs(icFloatNumber* Lab);
        ICCPROFLIB_API void icLabToPcs(icFloatNumber* Lab);

        /** Floating point encoding of XYZ in PCS is in range 0.0 to 1.0
         (Note: X=1.0 is encoded as about 0.5)*/
        ///Here are some conversion routines to convert to regular XYZ encoding
        ICCPROFLIB_API void icXyzFromPcs(icFloatNumber* XYZ);
        ICCPROFLIB_API void icXyzToPcs(icFloatNumber* XYZ);


        ICCPROFLIB_API void icMemDump(std::string &sDump, void* pBuf, icUInt32Number nNum);
        ICCPROFLIB_API void icMatrixDump(std::string &sDump, icS15Fixed16Number* pMatrix);
        ICCPROFLIB_API const icChar* icGetSig(icChar * pBuf, icUInt32Number sig, bool bGetHexVal = true);
        ICCPROFLIB_API const icChar* icGet16bitSig(icChar * pBuf, icUInt16Number sig, bool bGetHexVal = true);
        ICCPROFLIB_API const icChar* icGetSigStr(icChar * pBuf, icUInt32Number nSig);
        ICCPROFLIB_API const icChar* icGetColorSig(icChar * pBuf, icUInt32Number sig, bool bGetHexVal = true);
        ICCPROFLIB_API const icChar* icGetColorSigStr(icChar * pBuf, icUInt32Number nSig);

//#define icUtf8StrCmp(x, y) strcmp((const char*)x, (const char*)y)

        ICCPROFLIB_API std::string icGetSigPath(icUInt32Number sig);
        ICCPROFLIB_API icSignature icGetFirstSigPathSig(std::string sigPath);
        ICCPROFLIB_API icSignature icGetSecondSigPathSig(std::string sigPath);
        ICCPROFLIB_API icSignature icGetLastSigPathSig(std::string sigPath);

        ICCPROFLIB_API icUInt32Number icGetSigVal(const icChar* pBuf);
        ICCPROFLIB_API icUInt32Number icGetSpaceSamples(icColorSpaceSignature sig);
        ICCPROFLIB_API icUInt32Number icGetSpectralSpaceSamples(const icHeader* pHdr);
        ICCPROFLIB_API icUInt32Number icGetMaterialColorSpaceSamples(icMaterialColorSignature sig);

        bool ICCPROFLIB_API icSameSpectralRange(const icSpectralRange &rng1, const icSpectralRange &rng2);

        ICCPROFLIB_API icUInt8Number icGetStorageTypeBytes(icUInt16Number nStorageType);

        ICCPROFLIB_API extern const char* icMsgValidateWarning;
        ICCPROFLIB_API extern const char* icMsgValidateNonCompliant;
        ICCPROFLIB_API extern const char* icMsgValidateCriticalError;
        ICCPROFLIB_API extern const char* icMsgValidateInformation;

//# ifdef ICC_BYTE_ORDER_LITTLE_ENDIAN
        inline void icSwab16Ptr(void* pVoid)
        {
            icUInt8Number* ptr = (icUInt8Number*)pVoid;
            icUInt8Number tmp;

            tmp = ptr[0]; ptr[0] = ptr[1]; ptr[1] = tmp;
        }

        inline void icSwab16Array(void* pVoid, int num)
        {
            icUInt8Number* ptr = (icUInt8Number*)pVoid;
            icUInt8Number tmp;

            while (num > 0)
            {
                tmp = ptr[0]; ptr[0] = ptr[1]; ptr[1] = tmp;
                ptr += 2;
                num--;
            }
        }

        inline void icSwab32Ptr(void* pVoid)
        {
            icUInt8Number* ptr = (icUInt8Number*)pVoid;
            icUInt8Number tmp;

            tmp = ptr[0]; ptr[0] = ptr[3]; ptr[3] = tmp;
            tmp = ptr[1]; ptr[1] = ptr[2]; ptr[2] = tmp;
        }

        inline void icSwab32Array(void* pVoid, int num)
        {
            icUInt8Number* ptr = (icUInt8Number*)pVoid;
            icUInt8Number tmp;

            while (num > 0)
            {
                tmp = ptr[0]; ptr[0] = ptr[3]; ptr[3] = tmp;
                tmp = ptr[1]; ptr[1] = ptr[2]; ptr[2] = tmp;
                ptr += 4;
                num--;
            }

        }

        inline void icSwab64Ptr(void* pVoid)
        {
            icUInt8Number* ptr = (icUInt8Number*)pVoid;
            icUInt8Number tmp;

            tmp = ptr[0]; ptr[0] = ptr[7]; ptr[7] = tmp;
            tmp = ptr[1]; ptr[1] = ptr[6]; ptr[6] = tmp;
            tmp = ptr[2]; ptr[2] = ptr[5]; ptr[5] = tmp;
            tmp = ptr[3]; ptr[3] = ptr[4]; ptr[4] = tmp;
        }

        inline void icSwab64Array(void* pVoid, int num)
        {
            icUInt8Number* ptr = (icUInt8Number*)pVoid;
            icUInt8Number tmp;

            while (num > 0)
            {
                tmp = ptr[0]; ptr[0] = ptr[7]; ptr[7] = tmp;
                tmp = ptr[1]; ptr[1] = ptr[6]; ptr[6] = tmp;
                tmp = ptr[2]; ptr[2] = ptr[5]; ptr[5] = tmp;
                tmp = ptr[3]; ptr[3] = ptr[4]; ptr[4] = tmp;
                ptr += 8;
                num--;
            }

        }
//else //!ICC_BYTE_ORDER_LITTLE_ENDIAN
//#define icSwab16Ptr(flt)
//#define icSwab16Array(flt, n)
/#define icSwab32Ptr(flt)
/#define icSwab32Array(flt, n)
/#define icSwab64Ptr(flt)
/#define icSwab64Array(flt, n)
//endif

/#define icSwab16(flt) icSwab16Ptr(&flt)
/#define icSwab32(flt) icSwab32Ptr(&flt)
/#define icSwab64(flt) icSwab64Ptr(&flt)


        /**
         **************************************************************************
         * Type: Class
         * 
         * Purpose: 
         *  This is a utility class which can be used to get profile info 
         *  for printing. The member functions are used to convert signatures
         *  and other enum values to character strings for printing.
         **************************************************************************
         */
        class ICCPROFLIB_API  CIccInfo {
public:
  CIccInfo();
        virtual ~CIccInfo();
        //Signature values
        const icChar* GetVersionName(icUInt32Number val);
        const icChar* GetSubClassVersionName(icUInt32Number val);
        const icChar* GetDeviceAttrName(icUInt64Number val);
        const icChar* GetProfileFlagsName(icUInt32Number val, bool bCheckMCS = false);

        const icChar* GetTagSigName(icTagSignature sig);
        const icChar* GetTechnologySigName(icTechnologySignature sig);
        const icChar* GetTagTypeSigName(icTagTypeSignature sig);
        const icChar* GetStructSigName(icStructSignature sig);
        const icChar* GetArraySigName(icArraySignature sig);
        const icChar* GetColorSpaceSigName(icColorSpaceSignature sig);
        const icChar* GetProfileClassSigName(icProfileClassSignature sig);
        const icChar* GetPlatformSigName(icPlatformSignature sig);
        const icChar* GetCmmSigName(icCmmSignature sig);
        const icChar* GetReferenceMediumGamutSigNameName(icReferenceMediumGamutSignature sig);
        const icChar* GetColorimetricIntentImageStateName(icColorimetricIntentImageStateSignature sig);
        const icChar* GetSpectralColorSigName(icSpectralColorSignature sig);
        const icChar* GetElementTypeSigName(icElemTypeSignature sig);

        const icChar* GetSigName(icUInt32Number val);

        const icChar* GetPathEntrySigName(icUInt32Number val);

        std::string GetSigPathName(std::string sigPath);

        //Other values
        const icChar* GetMeasurementFlareName(icMeasurementFlare val);
        const icChar* GetMeasurementGeometryName(icMeasurementGeometry val);
        const icChar* GetRenderingIntentName(icRenderingIntent val, bool bIsV5 = false);
        const icChar* GetSpotShapeName(icSpotShape val);
        const icChar* GetStandardObserverName(icStandardObserver val);
        const icChar* GetIlluminantName(icIlluminant val);

        const icChar* GetUnknownName(icUInt32Number val);
        const icChar* GetMeasurementUnit(icSignature sig);
        const icChar* GetProfileID(icProfileID * profileID);
        const icChar* GetColorantEncoding(icColorantEncoding colorant);

        bool IsProfileIDCalculated(icProfileID* profileID);
        icValidateStatus CheckData(std::string &sReport, const icDateTimeNumber &dateTime, std::string sDesc = "");
        icValidateStatus CheckData(std::string &sReport, const icXYZNumber &XYZ, std::string sDesc = "");
        icValidateStatus CheckData(std::string &sReport, const icFloatXYZNumber &XYZ, std::string sDesc = "");
        icValidateStatus CheckData(std::string &sReport, const icSpectralRange &range, std::string sDesc = "");

        icValidateStatus CheckLuminance(std::string &sReport, const icFloatXYZNumber &XYZ, std::string sDesc = "");

        bool IsValidSpace(icColorSpaceSignature sig);
        bool IsValidSpectralSpace(icColorSpaceSignature sig);

        protected:
  icChar m_szStr[128];
        icChar m_szSigStr[128];
        std::string* m_str;
    };

    /**
     **************************************************************************
     * Type: Class
     * 
     * Purpose: 
     *  This is a utility class which can be for pixel sample storage.
     *  It features constant allocation access time when the pixel buffer size
     *  is less thatn icDefaultPixelBufSize
     **************************************************************************
     */
/#define icDefaultPixelBufSize 100
    class ICCPROFLIB_API CIccPixelBuf
{
public:
  CIccPixelBuf(int nChan = icDefaultPixelBufSize);
    ~CIccPixelBuf();
    icFloatNumber &operator[](int nPos) { return m_pixel[nPos]; }
    icFloatNumber* get() { return m_pixel; }


  operator icFloatNumber*()
    { return m_pixel; }
  operator void*()
    { return m_pixel; }

    protected:
  icFloatNumber m_buf[icDefaultPixelBufSize];
    icFloatNumber* m_pixel;
};



#endif







    }

}
