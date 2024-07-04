/** @file
    File:       IccCmm.h

    Contains:   Header file for implementation of the CIccCmm class.

    Version:    V1

    Copyright:  (c) see ICC Software License
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
// -Added support for Monochrome ICC profile apply by Rohit Patil 12-03-2008
// -Integrate changes for PCS adjustment by George Pawle 12-09-2008
// -Port to C# by Katrina Niolet 07-04-2024
//
//////////////////////////////////////////////////////////////////////

namespace iccmax_dotnet.IccProfLib.CMM
{
    /**
    **************************************************************************
    * Type: Class
    * 
    * Purpose: 
    *  Manages the named xform hints
    **************************************************************************
*/
    class CIccCreateXformHintManager
    {
        public CIccCreateXformHintManager() { m_pList = null; }
        
        ~CIccCreateXformHintManager() { } //TODO(Port) need to manually cleanup m_pList?

        /// Adds and owns the passed named hint to it's list
        public bool AddHint(IIccCreateXformHint pHint)
        {
            if (m_pList == null)
            {
                m_pList = new List<IIccCreateXformHintPtr>();
            }

            if (pHint != null)
            {
                if (GetHint(pHint.GetHintType()) != null)
                {
                    //TODO(Port) need to Destroy it?
                    pHint = null;
                    return false;
                }
                IIccCreateXformHintPtr Hint;
                Hint.ptr = pHint;
                m_pList.Add(Hint);
                return true;
            }

            return false;
        }

        /// Deletes the object referenced by the passed named hint pointer and removes it from the list
        public bool DeleteHint(IIccCreateXformHint pHint)
        {
            if (m_pList != null && pHint != null)
            {
                foreach (IIccCreateXformHintPtr i in m_pList)
                {
                    if (i.ptr == pHint)
                    {
                        //TODO(Port) need to Destroy it?
                        pHint = null;
                        m_pList.Remove(i);
                        return true;
                    }
                }
            }

            return false;
        }

        /// Finds and returns a pointer to the named hint
        public IIccCreateXformHint GetHint(string hintName)
        {
            IIccCreateXformHint pHint = null;

            if (m_pList != null)
            {
                foreach (IIccCreateXformHintPtr i in m_pList)
                {
                    if (i.ptr != null)
                    {
                        if (i.ptr.GetHintType() == hintName)
                        {
                            pHint = i.ptr;
                            break;
                        }
                    }
                }
            }
            return pHint;
        }

        // private hint ptr class
        private struct IIccCreateXformHintPtr
        {
            public IIccCreateXformHint ptr;
        };

        // private members
        List<IIccCreateXformHintPtr> m_pList;
    };


}
