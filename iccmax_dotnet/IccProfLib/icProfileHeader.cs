//Define how 64 bit integers are represented
global using ICUINT8TYPE = byte;
global using ICINT8TYPE = sbyte;

global using ICCUINT64 = ulong;
global using ICCINT64 = long;
global using ICUINT64TYPE = ulong;
global using ICINT64TYPE = long;

global using ICCUINT32 = uint;
global using ICCINT32 = int;
global using ICUINT32TYPE = uint;
global using ICINT32TYPE = int;

global using ICHALFFLOATTYPE = ushort;

/**
* Number definitions
*
* NOTE: 
*  Integer definitions vary from compiler to compiler.  Rather than
*  provide complex checking for compiler and system, default implementations
*  are provided with the ability to redefine actual meaning based upon
*  macros.  This can be accomplished in a separate header file that first defines
*  the macros and then includes this header, or by defining macro values on
*  a project level.
*/

/** Unsigned integer numbers */
global using icUInt8Number = byte;
global using icUInt16Number = ushort;
global using icUInt32Number = uint;
global using icUInt64Number = ulong;
global using icSignature = uint;

/** Signed numbers */
global using icInt8Number = sbyte;
global using icInt16Number = short;
global using icInt32Number = int;
global using icInt64Number = long;

/** Fixed numbers */
global using icS15Fixed16Number = int;
global using icU16Fixed16Number = uint;


/** IEEE float storage numbers */
global using icFloat16Number = System.Half;
global using icFloat32Number = float;
global using icFloat64Number = double;

/** 16-bit unicode characters **/
global using icUnicodeChar = ushort;

/**
 * MPE Future Extension Acs signature
 */

global using icAcsSignature = uint;

global using icLanguageCode = ushort;
global using icCountryCode = ushort;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RefIccMax.IccProfLib
{
    /**
     * Defines used in the specification
     */
    public enum IccVersion : uint
    {
        icMagicNumber = 0x61637370,     /* 'acsp' */
        icVersionNumber = 0x02000000,     /* 2.0, BCD */
        icVersionNumberV2_1 = 0x02100000,     /* 2.1, BCD */
        icVersionNumberV4 = 0x04000000,     /* 4.0, BCD */
        icVersionNumberV4_2 = 0x04200000,     /* 4.2, BCD */
        icVersionNumberV4_3 = 0x04300000,     /* 4.3, BCD */
        icVersionNumberV4_4 = 0x04400000,     /* 4.3, BCD */
        icVersionNumberV5 = 0x05000000,     /* 5.0, BCD */
        icVersionNumberV5_1 = 0x05100000     /* 5.1, BCD */
    }

    /** Screening Encodings */
    public enum Screening : uint
    {
        icPrtrDefaultScreensFalse = 0x00000000,     /* Bit position 0 */
        icPrtrDefaultScreensTrue = 0x00000001,     /* Bit position 0 */
        icLinesPerInch = 0x00000002,     /* Bit position 1 */
        icLinesPerCm = 0x00000000     /* Bit position 1 */
    }

    /** 
 * Device attributes, currently defined values correspond
 * to the low 4 bytes of the 8 byte attribute quantity, see
 * the header for their location.
 */
    public enum DeviceAttributes : uint
    {
        icReflective = 0x00000000,     /* Bit position 0 */
        icTransparency = 0x00000001,     /* Bit position 0 */
        icGlossy = 0x00000000,     /* Bit position 1 */
        icMatte = 0x00000002,     /* Bit position 1 */
        icMediaPositive = 0x00000000,     /* Bit position 2 */
        icMediaNegative = 0x00000004,     /* Bit position 2 */
        icMediaColour = 0x00000000,     /* Bit position 3 */
        icMediaBlackAndWhite = 0x00000008     /* Bit position 3 */
    }

    /**
 * Profile header flags, the low 16 bits are reserved for consortium
 * use.
 */
    public enum ProfileHeaderFlags : uint
    {
        icEmbeddedProfileFalse = 0x00000000,     /* Bit position 0 */
        icEmbeddedProfileTrue = 0x00000001,     /* Bit position 0 */
        icUseAnywhere = 0x00000000,     /* Bit position 1 */
        icUseWithEmbeddedDataOnly = 0x00000002,     /* Bit position 1 */
        icMCSNeedsSubsetFalse = 0x00000000,     /* Bit Position 2 */
        icMCSNeedsSubsetTrue = 0x00000004,     /* Bit Position 2 */
        icStandardRangePCS = 0x00000000,     /* Bit Position 3 */
        icExtendedRangePCS = 0x00000008     /* Bit Position 3 */
    }

    /* Used in dataType Tags */
    public enum icDataBlockType : uint
    {
        icAsciiData = 0x0000,
        icBinaryData = 0x0001,
        icUtfData = 0x0002,
        icCompressedAsciiData = Global.icCompressedData | icAsciiData,
        icCompressedBinaryData = Global.icCompressedData | icBinaryData,
        icCompressedUtfData = Global.icCompressedData | icUtfData,
    }

    /**
 * public tags and sizes 
 */
    public enum icTagSignature : uint
    {
        icSigAToB0Tag = 0x41324230,  /* 'A2B0' */
        icSigAToB1Tag = 0x41324231,  /* 'A2B1' */
        icSigAToB2Tag = 0x41324232,  /* 'A2B2' */
        icSigAToB3Tag = 0x41324233,  /* 'A2B3' */
        icSigAToM0Tag = 0x41324d30,  /* 'A2M0' */
        icSigBlueColorantTag = 0x6258595A,  /* 'bXYZ' */
        icSigBlueMatrixColumnTag = 0x6258595A,  /* 'bXYZ' */
        icSigBlueTRCTag = 0x62545243,  /* 'bTRC' */
        icSigBrdfColorimetricParameter0Tag = 0x62637030,  /* 'bcp0' */
        icSigBrdfColorimetricParameter1Tag = 0x62637031,  /* 'bcp1' */
        icSigBrdfColorimetricParameter2Tag = 0x62637032,  /* 'bcp2' */
        icSigBrdfColorimetricParameter3Tag = 0x62637033,  /* 'bcp3' */
        icSigBrdfSpectralParameter0Tag = 0x62737030,  /* 'bsp0' */
        icSigBrdfSpectralParameter1Tag = 0x62737031,  /* 'bsp1' */
        icSigBrdfSpectralParameter2Tag = 0x62737032,  /* 'bsp2' */
        icSigBrdfSpectralParameter3Tag = 0x62737033,  /* 'bsp3' */
        icSigBRDFAToB0Tag = 0x62414230,  /* 'bAB0' */
        icSigBRDFAToB1Tag = 0x62414231,  /* 'bAB1' */
        icSigBRDFAToB2Tag = 0x62414232,  /* 'bAB2' */
        icSigBRDFAToB3Tag = 0x62414233,  /* 'bAB3' */
        icSigBRDFDToB0Tag = 0x62444230,  /* 'bDB0' */
        icSigBRDFDToB1Tag = 0x62444231,  /* 'bDB1' */
        icSigBRDFDToB2Tag = 0x62444232,  /* 'bDB2' */
        icSigBRDFDToB3Tag = 0x62444233,  /* 'bDB3' */
        icSigBRDFMToB0Tag = 0x624D4230,  /* 'bMB0' */
        icSigBRDFMToB1Tag = 0x624D4231,  /* 'bMB1' */
        icSigBRDFMToB2Tag = 0x624D4232,  /* 'bMB2' */
        icSigBRDFMToB3Tag = 0x624D4233,  /* 'bMB3' */
        icSigBRDFMToS0Tag = 0x624D5330,  /* 'bMS0' */
        icSigBRDFMToS1Tag = 0x624D5331,  /* 'bMS1' */
        icSigBRDFMToS2Tag = 0x624D5332,  /* 'bMS2' */
        icSigBRDFMToS3Tag = 0x624D5333,  /* 'bMS3' */
        icSigBToA0Tag = 0x42324130,  /* 'B2A0' */
        icSigBToA1Tag = 0x42324131,  /* 'B2A1' */
        icSigBToA2Tag = 0x42324132,  /* 'B2A2' */
        icSigBToA3Tag = 0x42324133,  /* 'B2A3' */
        icSigCalibrationDateTimeTag = 0x63616C74,  /* 'calt' */
        icSigCharTargetTag = 0x74617267,  /* 'targ' */
        icSigChromaticAdaptationTag = 0x63686164,  /* 'chad' */
        icSigChromaticityTag = 0x6368726D,  /* 'chrm' */
        icSigCicpTag = 0x63696370,  /* 'cicp' */
        icSigColorEncodingParamsTag = 0x63657074,  /* 'cept' */
        icSigColorSpaceNameTag = 0x63736e6d,  /* 'csnm' */
        icSigColorantInfoTag = 0x636c696e,  /* 'clin' */
        icSigColorantInfoOutTag = 0x636c696f,  /* 'clio' */
        icSigColorantOrderTag = 0x636C726F,  /* 'clro' */
        icSigColorantOrderOutTag = 0x636c6f6f,  /* 'cloo' */
        icSigColorantTableTag = 0x636C7274,  /* 'clrt' */
        icSigColorantTableOutTag = 0x636C6F74,  /* 'clot' */
        icSigColorimetricIntentImageStateTag = 0x63696973,  /* 'ciis' */
        icSigCopyrightTag = 0x63707274,  /* 'cprt' */
        icSigCrdInfoTag = 0x63726469,  /* 'crdi' Removed in V4 */
        icSigCustomToStandardPccTag = 0x63327370,  /* 'c2sp' */
        icSigCxFTag = 0x43784620,  /* 'CxF ' */
        icSigDataTag = 0x64617461,  /* 'data' Removed in V4 */
        icSigDateTimeTag = 0x6474696D,  /* 'dtim' Removed in V4 */
        icSigDeviceMediaWhitePointTag = 0x646d7770,  /* 'dmwp' */
        icSigDeviceMfgDescTag = 0x646D6E64,  /* 'dmnd' */
        icSigDeviceModelDescTag = 0x646D6464,  /* 'dmdd' */
        icSigDeviceSettingsTag = 0x64657673,  /* 'devs' Removed in V4 */
        icSigDToB0Tag = 0x44324230,  /* 'D2B0' */
        icSigDToB1Tag = 0x44324231,  /* 'D2B1' */
        icSigDToB2Tag = 0x44324232,  /* 'D2B2' */
        icSigDToB3Tag = 0x44324233,  /* 'D2B3' */
        icSigBToD0Tag = 0x42324430,  /* 'B2D0' */
        icSigBToD1Tag = 0x42324431,  /* 'B2D1' */
        icSigBToD2Tag = 0x42324432,  /* 'B2D2' */
        icSigBToD3Tag = 0x42324433,  /* 'B2D3' */
        icSigGamutTag = 0x67616D74,  /* 'gamt' */
        icSigGamutBoundaryDescription0Tag = 0x67626430,  /* 'gbd0' */
        icSigGamutBoundaryDescription1Tag = 0x67626431,  /* 'gbd1' */
        icSigGamutBoundaryDescription2Tag = 0x67626432,  /* 'gbd2' */
        icSigGamutBoundaryDescription3Tag = 0x67626433,  /* 'gbd3' */
        icSigHToS0Tag = 0x48325330,  /* 'H2S0' */
        icSigHToS1Tag = 0x48325331,  /* 'H2S1' */
        icSigHToS2Tag = 0x48325332,  /* 'H2S2' */
        icSigHToS3Tag = 0x48325333,  /* 'H2S3' */
        icSigGrayTRCTag = 0x6b545243,  /* 'kTRC' */
        icSigGreenColorantTag = 0x6758595A,  /* 'gXYZ' */
        icSigGreenMatrixColumnTag = 0x6758595A,  /* 'gXYZ' */
        icSigGreenTRCTag = 0x67545243,  /* 'gTRC' */
        icSigLuminanceTag = 0x6C756d69,  /* 'lumi' */
        icSigMaterialDefaultValuesTag = 0x6D647620,  /* 'mdv ' */
        icSigMaterialTypeArrayTag = 0x6d637461,  /* 'mcta' */
        icSigMToA0Tag = 0x4d324130,  /* 'M2A0' */
        icSigMToB0Tag = 0x4d324230,  /* 'M2B0' */
        icSigMToB1Tag = 0x4d324231,  /* 'M2B1' */
        icSigMToB2Tag = 0x4d324232,  /* 'M2B2' */
        icSigMToB3Tag = 0x4d324233,  /* 'M2B3' */
        icSigMToS0Tag = 0x4d325330,  /* 'M2S0' */
        icSigMToS1Tag = 0x4d325331,  /* 'M2S1' */
        icSigMToS2Tag = 0x4d325332,  /* 'M2S2' */
        icSigMToS3Tag = 0x4d325333,  /* 'M2S3' */
        icSigMeasurementTag = 0x6D656173,  /* 'meas' */
        icSigMediaBlackPointTag = 0x626B7074,  /* 'bkpt' */
        icSigMediaWhitePointTag = 0x77747074,  /* 'wtpt' */
        icSigMetaDataTag = 0x6D657461,  /* 'meta' */
        icSigNamedColorTag = 0x6e6d636C,  /* 'nmcl' use for V5 */
        icSigNamedColor2Tag = 0x6E636C32,  /* 'ncl2' */
        icSigOutputResponseTag = 0x72657370,  /* 'resp' */
        icSigPerceptualRenderingIntentGamutTag = 0x72696730,  /* 'rig0' */
        icSigPreview0Tag = 0x70726530,  /* 'pre0' */
        icSigPreview1Tag = 0x70726531,  /* 'pre1' */
        icSigPreview2Tag = 0x70726532,  /* 'pre2' */
        icSigPrintConditionTag = 0x7074636e,  /* 'ptcn' */
        icSigProfileDescriptionTag = 0x64657363,  /* 'desc' */
        icSigProfileSequenceDescTag = 0x70736571,  /* 'pseq' */
        icSigProfileSequceIdTag = 0x70736964,  /* 'psid' */
        icSigPs2CRD0Tag = 0x70736430,  /* 'psd0' Removed in V4 */
        icSigPs2CRD1Tag = 0x70736431,  /* 'psd1' Removed in V4 */
        icSigPs2CRD2Tag = 0x70736432,  /* 'psd2' Removed in V4 */
        icSigPs2CRD3Tag = 0x70736433,  /* 'psd3' Removed in V4 */
        icSigPs2CSATag = 0x70733273,  /* 'ps2s' Removed in V4 */
        icSigPs2RenderingIntentTag = 0x70733269,  /* 'ps2i' Removed in V4 */
        icSigRedColorantTag = 0x7258595A,  /* 'rXYZ' */
        icSigRedMatrixColumnTag = 0x7258595A,  /* 'rXYZ' */
        icSigRedTRCTag = 0x72545243,  /* 'rTRC' */
        icSigReferenceNameTag = 0x72666e6d,  /* 'rfnm' */
        icSigSaturationRenderingIntentGamutTag = 0x72696732,  /* 'rig2' */
        icSigScreeningDescTag = 0x73637264,  /* 'scrd' Removed in V4 */
        icSigScreeningTag = 0x7363726E,  /* 'scrn' Removed in V4 */
        icSigSpectralDataInfoTag = 0x7364696e,  /* 'sdin' */
        icSigSpectralWhitePointTag = 0x73777074,  /* 'swpt' */
        icSigSpectralViewingConditionsTag = 0x7376636e,  /* 'svcn' */
        icSigStandardToCustomPccTag = 0x73326370,  /* 's2cp' */
        icSigSurfaceMapTag = 0x736D6170,  /* 'smap' */
        icSigTechnologyTag = 0x74656368,  /* 'tech' */
        icSigUcrBgTag = 0x62666420,  /* 'bfd ' Removed in V4 */
        icSigViewingCondDescTag = 0x76756564,  /* 'vued' */
        icSigViewingConditionsTag = 0x76696577,  /* 'view' */

        /* Private tags*/
        icSigEmbeddedV5ProfileTag = 0x49434335,  /* 'ICC5' */
    }

    /**
 * technology signature descriptions
 */
    public enum icTechnologySignature
      : uint
    {
        icSigDigitalCamera = 0x6463616D,  /* 'dcam' */
        icSigFilmScanner = 0x6673636E,  /* 'fscn' */
        icSigReflectiveScanner = 0x7273636E,  /* 'rscn' */
        icSigInkJetPrinter = 0x696A6574,  /* 'ijet' */
        icSigThermalWaxPrinter = 0x74776178,  /* 'twax' */
        icSigElectrophotographicPrinter = 0x6570686F,  /* 'epho' */
        icSigElectrostaticPrinter = 0x65737461,  /* 'esta' */
        icSigDyeSublimationPrinter = 0x64737562,  /* 'dsub' */
        icSigPhotographicPaperPrinter = 0x7270686F,  /* 'rpho' */
        icSigFilmWriter = 0x6670726E,  /* 'fprn' */
        icSigVideoMonitor = 0x7669646D,  /* 'vidm' */
        icSigVideoCamera = 0x76696463,  /* 'vidc' */
        icSigProjectionTelevision = 0x706A7476,  /* 'pjtv' */
        icSigCRTDisplay = 0x43525420,  /* 'CRT ' */
        icSigPMDisplay = 0x504D4420,  /* 'PMD ' */
        icSigAMDisplay = 0x414D4420,  /* 'AMD ' */
        icSigPhotoCD = 0x4B504344,  /* 'KPCD' */
        icSigPhotoImageSetter = 0x696D6773,  /* 'imgs' */
        icSigGravure = 0x67726176,  /* 'grav' */
        icSigOffsetLithography = 0x6F666673,  /* 'offs' */
        icSigSilkscreen = 0x73696C6B,  /* 'silk' */
        icSigFlexography = 0x666C6578,  /* 'flex' */
        icSigMotionPictureFilmScanner = 0x6D706673,  /* 'mpfs' */
        icSigMotionPictureFilmRecorder = 0x6D706672,  /* 'mpfr' */
        icSigDigitalMotionPictureCamera = 0x646D7063,  /* 'dmpc' */
        icSigDigitalCinemaProjector = 0x64636A70,  /* 'dcpj' */
    }

    /**
 * type signatures 
 */
    public enum icTagTypeSignature
       : uint
    {
        icSigUndefinedType = 0x00000000,
        icSigChromaticityType = 0x6368726D,  /* 'chrm' */
        icSigCicpType = 0x63696370,  /* 'cicp' */
        icSigColorantOrderType = 0x636C726F,  /* 'clro' */
        icSigColorantTableType = 0x636C7274,  /* 'clrt' */
        icSigCrdInfoType = 0x63726469,  /* 'crdi' Removed in V4 */
        icSigCurveType = 0x63757276,  /* 'curv' */
        icSigDataType = 0x64617461,  /* 'data' */
        icSigDictType = 0x64696374,  /* 'dict' */
        icSigDateTimeType = 0x6474696D,  /* 'dtim' */
        icSigDeviceSettingsType = 0x64657673,  /* 'devs' Removed in V4 */
        icSigEmbeddedHeightImageType = 0x6568696D,  /* 'ehim' */
        icSigEmbeddedNormalImageType = 0x656e696d,  /* 'enim' */
        icSigFloat16ArrayType = 0x666c3136,  /* 'fl16' */
        icSigFloat32ArrayType = 0x666c3332,  /* 'fl32' */
        icSigFloat64ArrayType = 0x666c3634,  /* 'fl64' */
        icSigGamutBoundaryDescType = 0x67626420,  /* 'gbd ' */
        icSigLut16Type = 0x6d667432,  /* 'mft2' */
        icSigLut8Type = 0x6d667431,  /* 'mft1' */
        icSigLutAtoBType = 0x6d414220,  /* 'mAB ' */
        icSigLutBtoAType = 0x6d424120,  /* 'mBA ' */
        icSigMeasurementType = 0x6D656173,  /* 'meas' */
        icSigMultiLocalizedUnicodeType = 0x6D6C7563,  /* 'mluc' */
        icSigMultiProcessElementType = 0x6D706574,  /* 'mpet' */
        icSigNamedColor2Type = 0x6E636C32,  /* 'ncl2' use v2-v4*/
        icSigParametricCurveType = 0x70617261,  /* 'para' */
        icSigProfileSequenceDescType = 0x70736571,  /* 'pseq' */
        icSigProfileSequceIdType = 0x70736964,  /* 'psid' */
        icSigResponseCurveSet16Type = 0x72637332,  /* 'rcs2' */
        icSigS15Fixed16ArrayType = 0x73663332,  /* 'sf32' */
        icSigScreeningType = 0x7363726E,  /* 'scrn' Removed in V4 */
        icSigSegmentedCurveType = 0x63757266,  /* 'curf' */
        icSigSignatureType = 0x73696720,  /* 'sig ' */
        icSigSparseMatrixArrayType = 0x736D6174,  /* 'smat' */
        icSigSpectralViewingConditionsType = 0x7376636e,  /* 'svcn' */
        icSigSpectralDataInfoType = 0x7364696e,  /* 'sdin' */
        icSigTagArrayType = 0x74617279,  /* 'tary' */
        icSigTagStructType = 0x74737472,  /* 'tstr' */
        icSigTextType = 0x74657874,  /* 'text' */
        icSigTextDescriptionType = 0x64657363,  /* 'desc' Removed in V4 */
        icSigU16Fixed16ArrayType = 0x75663332,  /* 'uf32' */
        icSigUcrBgType = 0x62666420,  /* 'bfd ' Removed in V4 */
        icSigUInt16ArrayType = 0x75693136,  /* 'ui16' */
        icSigUInt32ArrayType = 0x75693332,  /* 'ui32' */
        icSigUInt64ArrayType = 0x75693634,  /* 'ui64' */
        icSigUInt8ArrayType = 0x75693038,  /* 'ui08' */
        icSigViewingConditionsType = 0x76696577,  /* 'view' */
        icSigUtf8TextType = 0x75746638,  /* 'utf8' */
        icSigUtf16TextType = 0x75743136,  /* 'ut16' */
        icSigXYZType = 0x58595A20,  /* 'XYZ ' */
        icSigXYZArrayType = 0x58595A20,  /* 'XYZ ' */
        icSigZipUtf8TextType = 0x7a757438,  /* 'zut8' */
#if XRITE_ADDITIONS
    icSigZipXmlType_XRITE               = 0x5a584d4c,  /* 'ZXML' - X-Rite's uppercase version of 'zxml' */
#endif
        icSigZipXmlType = 0x7a786d6c,  /* 'zxml' */

        /*Private tag types*/
        icSigEmbeddedProfileType = 0x49434370,  /* 'ICCp' */
        icSigZipXMLType = 0x5a584d4c, /* 'ZXML' used by X-rite for CxF tags*/

    }

    /**
 * Tag Structure type signatures
 */
    public enum icStructSignature : uint
    {
        icSigBRDFStruct = 0x62726466,  /* 'brdf' */
        icSigColorantInfoStruct = 0x63696e66,  /* 'cinf' */
        icSigColorEncodingParamsSruct = 0x63657074,  /* 'cept' */
        icSigMeasurementInfoStruct = 0x6d656173,  /* 'meas' */
        icSigNamedColorStruct = 0x6e6d636c,  /* 'nmcl' */
        icSigProfileInfoStruct = 0x70696e66,  /* 'pinf' */
        icSigTintZeroStruct = 0x746e7430,  /* 'tnt0' */
        icSigUndefinedStruct = 0x00000000,
    }

    /**
 * Tag Array type signatures
 */
    public enum icArraySignature : uint
    {
        icSigUndefinedArray = 0x00000000,
        icSigNamedColorArray = 0x6e6d636c,  /* 'nmcl' */
        icSigColorantInfoArray = 0x63696e66,  /* 'cinf' */
        icSigUtf8TextTypeArray = 0x75746638,  /* 'utf8' */
    }

    /************************************************************************
 * CMM environment variable signatures
 ************************************************************************/
    public enum icSigCmmEnvVar : uint
    {
        //Floating point constant operation
        icSigTrueVar = 0x74727565,  /* 'true' */
        icSigNotDefVar = 0x6e646566,  /* 'ndef' */
    }

    /**
 * Multi-Processing Element type signatures
 */
    public enum icElemTypeSignature : uint
    {
        //DMP Proposal 1.0 elements
        icSigCurveSetElemType = 0x63767374,  /* 'cvst' */
        icSigMatrixElemType = 0x6D617466,  /* 'matf' */
        icSigCLutElemType = 0x636C7574,  /* 'clut' */
        icSigBAcsElemType = 0x62414353,  /* 'bACS' */
        icSigEAcsElemType = 0x65414353,  /* 'eACS' */
        // V5 elements
        icSigCalculatorElemType = 0x63616c63,  /* 'calc' */
        icSigExtCLutElemType = 0x78636c74,  /* 'xclt' */
        icSigXYZToJabElemType = 0x58746f4a,  /* 'XtoJ' */
        icSigJabToXYZElemType = 0x4a746f58,  /* 'JtoX' */
        icSigSparseMatrixElemType = 0x736d6574,  /* 'smet' */
        icSigTintArrayElemType = 0x74696e74,  /* 'tint' */

        // V5.1 elements
        icSigToneMapElemType = 0x746d6170,  /* 'tmap' */

        // V5 spectral elements
        icSigEmissionMatrixElemType = 0x656d7478,  /* 'emtx' */
        icSigInvEmissionMatrixElemType = 0x69656d78,  /* 'iemx' */
        icSigEmissionCLUTElemType = 0x65636c74,  /* 'eclt' */
        icSigReflectanceCLUTElemType = 0x72636c74,  /* 'rclt' */
        icSigEmissionObserverElemType = 0x656f6273,  /* 'eobs' */
        icSigReflectanceObserverElemType = 0x726f6273,  /* 'robs' */
    }

    /**
* BRDFStructure (icSigBrdfStruct) Member Tag signatures
*/
    public enum icBrdfMemberSignature
        : uint
    {
        icSigBrdfTypeMbr = 0x74797065,  /* 'type' */
        icSigBrdfFunctionMbr = 0x66756e63,  /* 'func' */
        icSigBrdfParamsPerChannelMbr = 0x6e756d70,  /* 'nump' */
        icSigBrdfTransformMbr = 0x7866726d,  /* 'xfrm' */
        icSigBrdfLightTransformMbr = 0x6c747866,  /* 'ltxf' */
        icSigBrdfOutputTransformMbr = 0x6f757478,  /* 'outx' */ /* Note: converts the output of the BRDF model to PCS */
    }

    /**
 * BRDF function signatures
 */
    public enum icSigBRDFFunction
       : uint
    {
        icSigBRDFFunctionMonochrome = 0x6d6f6e6f,   /* 'mono' */
        icSigBRDFFunctionColor = 0x636f6c72    /* 'colr' */
    }


    /**
* ColorantInfoStructure (icSigColorantInfoStruct) Member Tag signatures
*/
    public enum icColorantInfoMemberSignature
       : uint
    {
        icSigCinfNameMbr = 0x6e616d65, /* 'name' */
        icSigCinfLocalizedNameMbr = 0x6c636e6d, /* 'lcnm' */
        icSigCinfPcsDataMbr = 0x70637320, /* 'pcs ' */
        icSigCinfSpectralDataMbr = 0x73706563, /* 'spec' */
    }

    /**
* ColorEncodingParamsStructure (icSigColorEncodingParamsStruct) Member Tag signatures
*/
    public enum icColorEncodingParamsMemberSignature
         : uint
    {
        icSigCeptBluePrimaryXYZMbr = 0x6258595a,  /* bXYZ' */
        icSigCeptGreenPrimaryXYZMbr = 0x6758595a,  /* gXYZ' */
        icSigCeptRedPrimaryXYZMbr = 0x7258595a,  /* rXYZ' */
        icSigCeptTransferFunctionMbr = 0x66756e63, /* func */
        icSigCeptInverseTransferFunctionMbr = 0x69666e63, /* ifnc */
        icSigCeptLumaChromaMatrixMbr = 0x6c6d6174,  /* lmat' */
        icSigCeptWhitePointLuminanceMbr = 0x776c756d,  /* wlum' */
        icSigCeptWhitePointChromaticityMbr = 0x7758595a,  /* wXYZ' */
        icSigCeptEncodingRangeMbr = 0x65526e67,  /* eRng' */
        icSigCeptBitDepthMbr = 0x62697473,  /* bits' */
        icSigCeptImageStateMbr = 0x696d7374,  /* imst' */
        icSigCeptImageBackgroundMbr = 0x69626b67,  /* ibkg' */
        icSigCeptViewingSurroundMbr = 0x73726e64,  /* srnd' */
        icSigCeptAmbientIlluminanceMbr = 0x61696c6d,  /* ailm' */
        icSigCeptAmbientWhitePointLuminanceMbr = 0x61776c6d,  /* awlm' */
        icSigCeptAmbientWhitePointChromaticityMbr = 0x61777063,  /* awpc' */
        icSigCeptViewingFlareMbr = 0x666c6172,  /* 'flar' */
        icSigCeptValidRelativeLuminanceRangeMbr = 0x6c726e67,  /* lrng' */
        icSigCeptMediumWhitePointLuminanceMbr = 0x6d77706c,  /* mwpl' */
        icSigCeptMediumWhitePointChromaticityMbr = 0x6d777063,  /* mwpc' */
        icSigCeptMediumBlackPointLuminanceMbr = 0x6d62706c,  /* mbpl' */
        icSigCeptMediumBlackPointChromaticityMbr = 0x6d627063,  /* mbpc' */
    }

    /**
* MeasurementInfoStructure (icSigMeasurementInfoStruct) Member Tag signatures
*/
    public enum icMeasurementInfoMemberSignature
       : uint
    {
        icSigMeasBackingMbr = 0x6d62616b, /* 'mbak' */
        icSigMeasFlareMbr = 0x6d666c72, /* 'mflr' */
        icSigMeasGeometryMbr = 0x6d67656f, /* 'mgeo' */
        icSigMeasIlluminantMbr = 0x6d696c6c, /* 'mill' */
        icSigMeasIlluminantRangeMbr = 0x6d697772, /* 'miwr' */
        icSigMeasModeMbr = 0x6d6d6f64, /* 'mmod' */
    }

    /**
* NamedColorStructure (icSigNamedColorStruct) Member Tag signatures
*/
    public enum icNamedColorlMemberSignature
        : uint
    {
        icSigNmclBrdfColorimetricMbr = 0x62636f6c,  /* 'bcol' */
        icSigNmclBrdfColorimetricParamsMbr = 0x62637072,  /* 'bcpr' */
        icSigNmclBrdfSpectralMbr = 0x62737063,  /* 'bspc' */
        icSigNmclBrdfSpectralParamsMbr = 0x62737072,  /* 'bspr' */
        icSigNmclDeviceDataMbr = 0x64657620,  /* 'dev ' */
        icSigNmclLocalizedNameMbr = 0x6c636e6d,  /* 'lcnm' */
        icSigNmclNameMbr = 0x6e616d65,  /* 'name' */
        icSigNmclNormalMapMbr = 0x6e6d6170,  /* 'nmap' */
        icSigNmclPcsDataMbr = 0x70637320,  /* 'pcs ' */
        icSigNmclSpectralDataMbr = 0x73706563,  /* 'spec' */
        icSigNmclSpectralOverBlackMbr = 0x73706362,  /* 'spcb' */
        icSigNmclSpectralOverGrayMbr = 0x73706367,  /* 'spcg' */
        icSigNmclTintMbr = 0x74696e74,  /* 'tint' */
    }

    /**
* ProfileInfoStructure (icSigProfileInfoStruct) Member Tag signatures
*/
    public enum icProfileInfoMemberSignature
       : uint
    {
        icSigPinfAttributesMbr = 0x61747472, /* 'attr' */
        icSigPinfProfileDescMbr = 0x70647363, /* 'pdsc' */
        icSigPinfProfileIDMbr = 0x70696420, /* 'pid ' */
        icSigPinfManufacturerDescMbr = 0x646d6e64, /* 'dmnd' */
        icSigPinfManufacturerSigMbr = 0x646d6e73, /* 'dmns' */
        icSigPinfModelDescMbr = 0x646d6464, /* 'dmdd' */
        icSigPinfModelSigMbr = 0x6d6f6420, /* 'mod ' */
        icSigPinfRenderTransformMbr = 0x7274726e, /* 'rtrn' */
        icSigPinfTechnologyMbr = 0x74656368, /* 'tech' */
    }

    /**
* TintZeroStructure (icSigTintZeroStruct) Member Tag signatures
*/
    public enum icTintZeroMemberSignature : uint
    {
        icSigTnt0DeviceDataMbr = 0x64657620,  /* 'dev ' */
        icSigTnt0PcsDataMbr = 0x70637320,  /* 'pcs ' */
        icSigTnt0SpectralDataMbr = 0x73706563,  /* 'spec' */
        icSigTnt0SpectralOverBlackMbr = 0x73706362,  /* 'spcb' */
        icSigTnt0SpectralOverGrayMbr = 0x73706367,  /* 'spcg' */
    }

    /** 
 * Color Space Signatures.
 * Note that only icSigXYZData and icSigLabData are valid
 * Profile Connection Spaces (PCSs)
 */
    public enum icColorSpaceSignature
       : uint
    {
        icSigNoColorData = 0x00000000,

        icSigXYZData = 0x58595A20,  /* 'XYZ ' */
        icSigLabData = 0x4C616220,  /* 'Lab ' */
        icSigLuvData = 0x4C757620,  /* 'Luv ' */
        icSigYCbCrData = 0x59436272,  /* 'YCbr' */
        icSigYxyData = 0x59787920,  /* 'Yxy ' */
        icSigRgbData = 0x52474220,  /* 'RGB ' */
        icSigGrayData = 0x47524159,  /* 'GRAY' */
        icSigHsvData = 0x48535620,  /* 'HSV ' */
        icSigHlsData = 0x484C5320,  /* 'HLS ' */
        icSigCmykData = 0x434D594B,  /* 'CMYK' */
        icSigCmyData = 0x434D5920,  /* 'CMY ' */

        icSig1colorData = 0x31434C52,  /* '1CLR' */
        icSig2colorData = 0x32434C52,  /* '2CLR' */
        icSig3colorData = 0x33434C52,  /* '3CLR' */
        icSig4colorData = 0x34434C52,  /* '4CLR' */
        icSig5colorData = 0x35434C52,  /* '5CLR' */
        icSig6colorData = 0x36434C52,  /* '6CLR' */
        icSig7colorData = 0x37434C52,  /* '7CLR' */
        icSig8colorData = 0x38434C52,  /* '8CLR' */
        icSig9colorData = 0x39434C52,  /* '9CLR' */
        icSig10colorData = 0x41434C52,  /* 'ACLR' */
        icSig11colorData = 0x42434C52,  /* 'BCLR' */
        icSig12colorData = 0x43434C52,  /* 'CCLR' */
        icSig13colorData = 0x44434C52,  /* 'DCLR' */
        icSig14colorData = 0x45434C52,  /* 'ECLR' */
        icSig15colorData = 0x46434C52,  /* 'FCLR' */
        icSigNamedData = 0x6e6d636c,  /* 'nmcl' */

        icSigMCH1Data = 0x31434C52,  /* '1CLR' */
        icSigMCH2Data = 0x32434C52,  /* '2CLR' */
        icSigMCH3Data = 0x33434C52,  /* '3CLR' */
        icSigMCH4Data = 0x34434C52,  /* '4CLR' */
        icSigMCH5Data = 0x35434C52,  /* '5CLR' */
        icSigMCH6Data = 0x36434C52,  /* '6CLR' */
        icSigMCH7Data = 0x37434C52,  /* '7CLR' */
        icSigMCH8Data = 0x38434C52,  /* '8CLR' */
        icSigMCH9Data = 0x39434C52,  /* '9CLR' */
        icSigMCHAData = 0x41434C52,  /* 'ACLR' */
        icSigMCHBData = 0x42434C52,  /* 'BCLR' */
        icSigMCHCData = 0x43434C52,  /* 'CCLR' */
        icSigMCHDData = 0x44434C52,  /* 'DCLR' */
        icSigMCHEData = 0x45434C52,  /* 'ECLR' */
        icSigMCHFData = 0x46434C52,  /* 'FCLR' */

        icSigNChannelData = 0x6e630000,  /* "nc0000" */
        /*Note: "nc0001" through "ncFFFF" are also valid signatures defined using macro icNColorSpaceSig()*/

        icSigSrcMCSChannelData = 0x6d630000,  /* "mc0000" */
        /*Note: "mc0001" through "mcFFFF" are also valid signatures defined using macro icNColorSpaceSig()*/

    }

    /** icSpectralColorSignature enumerations */
    public enum icSpectralColorSignature
      : uint
    {
        icSigNoSpectralData = 0x00000000,
        icSigReflectanceSpectralData = 0x72730000, /* "rs0000" */
        /*Note: "rs0001" through "rsFFFF" are also valid signatures defined using macro icSpectralColorSpaceSig()*/

        icSigTransmisionSpectralData = 0x74730000, /* "ts0000" */
        /*Note: "ts0001" through "tsFFFF" are also valid signatures defined using macro icSpectralColorSpaceSig()*/

        icSigRadiantSpectralData = 0x65730000, /* "es0000" */
        /*Note: "ts0001" through "tsFFFF" are also valid signatures defined using macro icSpectralColorSpaceSig()*/

        icSigBiSpectralReflectanceData = 0x62730000, /* "bs0000" */
        /*Note: "bs0001" through "bsFFFF" are also valid signatures defined using macro icSpectralColorSpaceSig(*)*/

        icSigSparseMatrixReflectanceData = 0x736D0000, /* "sm0000" */
        /*Note: "sm0001" through "smFFFF" are also valid signatures defined using macro icSpectralColorSpaceSig(*)*/

    }

    public enum icMaterialColorSignature : uint
    {
        icSigNoMCSData = 0x00000000,
        icSigMCSData = 0x6d630000,  /* "mc0000" */
        /*Note: "nc0001" through "ncFFFF" are also valid signatures defined using macro icNColorSpaceSig()*/
    }

    /** profileClass enumerations */
    public enum icProfileClassSignature : uint
    {
        icSigInputClass = 0x73636E72,  /* 'scnr' */
        icSigDisplayClass = 0x6D6E7472,  /* 'mntr' */
        icSigOutputClass = 0x70727472,  /* 'prtr' */
        icSigLinkClass = 0x6C696E6B,  /* 'link' */
        icSigAbstractClass = 0x61627374,  /* 'abst' */
        icSigColorSpaceClass = 0x73706163,  /* 'spac' */
        icSigNamedColorClass = 0x6e6d636c,  /* 'nmcl' */
        icSigColorEncodingClass = 0x63656e63,  /* 'cenc' */
        icSigMaterialIdentificationClass = 0x6D696420,  /* 'mid ' */
        icSigMaterialLinkClass = 0x6d6c6e6b,  /* 'mlnk' */
        icSigMaterialVisualizationClass = 0x6d766973,  /* 'mvis' */
    }

    /** Platform Signatures */
    public enum icPlatformSignature
      : uint
    {
        icSigMacintosh = 0x4150504C,  /* 'APPL' */
        icSigMicrosoft = 0x4D534654,  /* 'MSFT' */
        icSigSolaris = 0x53554E57,  /* 'SUNW' */
        icSigSGI = 0x53474920,  /* 'SGI ' */
        icSigTaligent = 0x54474E54,  /* 'TGNT' */
        icSigUnkownPlatform = 0x00000000
    }

    /** CMM signatures from the signature registry (as of Mar 6, 2018) */
    public enum icCmmSignature
    : uint
    {
        icSigAdobe = 0x41444245,  /* 'ADBE' */
        icSigAgfa = 0x41434D53,  /* 'ACMS' */
        icSigApple = 0x6170706C,  /* 'appl' */
        icSigColorGear = 0x43434D53,  /* 'CCMS' */
        icSigColorGearLite = 0x5543434D,  /* 'UCCM' */
        icSigColorGearC = 0x55434D53,  /* 'UCMS' */
        icSigEFI = 0x45464920,  /* 'EFI ' */
        icSigExactScan = 0x45584143,  /* 'EXAC' */
        icSigFujiFilm = 0x46462020,  /* 'FF  ' */
        icSigHarlequinRIP = 0x48434d4d,  /* 'HCMM' */
        icSigArgyllCMS = 0x6172676C,  /* 'argl' */
        icSigLogoSync = 0x44676f53,  /* 'LgoS' */
        icSigHeidelberg = 0x48444d20,  /* 'HDM ' */
        icSigLittleCMS = 0x6C636D73,  /* 'lcms' */
        icSigKodak = 0x4b434d53,  /* 'KCMS' */
        icSigKonicaMinolta = 0x4d434d44,  /* 'MCML' */
        icSigWindowsCMS = 0x57435320,  /* 'WCS ' */
        icSigMutoh = 0x5349474E,  /* 'SIGN' */
        icSigOnyxGraphics = 0x4f4e5958,  /* 'ONYX' */
        icSigRefIccMAX = 0x52494343,  /* 'RIMX' */
        icSigDemoIccMAX = 0x44494d58,  /* 'DIMX' */
        icSigRolfGierling = 0x52474d53,  /* 'RGMS' */
        icSigSampleICC = 0x53494343,  /* 'SICC' */
        icSigToshiba = 0x54434D4D,  /* 'TCMM' */
        icSigTheImagingFactory = 0x33324254,  /* '32BT' */
        icSigVivo = 0x7669766F,  /* 'VIVO' */
        icSigWareToGo = 0x57544720,  /* 'WTG ' */
        icSigZoran = 0x7a633030,  /* 'zc00' */
        icSigUnknownCmm = 0x00000000,
    }

    /** Rendering Intent Gamut Signatures */
    public enum icReferenceMediumGamutSignature
     : uint
    {
        icSigPerceptualReferenceMediumGamut = 0x70726d67,  /* 'prmg' */
    }

    /** Colorimetric Intent Image State Gamut Signatures */
    public enum icColorimetricIntentImageStateSignature
     : uint
    {
        icSigSceneColorimetryEstimates = 0x73636F65,  /* 'scoe' */
        icSigSceneAppearanceEstimates = 0x73617065,  /* 'sape' */
        icSigFocalPlaneColorimetryEstimates = 0x66706365,  /* 'fpce' */
        icSigReflectionHardcopyOriginalColorimetry = 0x72686F63,  /* 'rhoc' */
        icSigReflectionPrintOutputColorimetry = 0x72706F63,  /* 'rpoc' */
    }

    /**
 * MPE Curve segment Signatures
 */
    public enum icCurveSegSignature
    : uint
    {
        icSigFormulaCurveSeg = 0x70617266,  /* 'parf' */
        icSigSampledCurveSeg = 0x73616D66,  /* 'samf' */
    }

    /**
 * MPE Curve Set Curve signature
 */
    public enum icCurveElemSignature
     : uint
    {
        icSigSegmentedCurve = 0x63757266,  /* 'curf' */
        icSigSingleSampledCurve = 0x736e6766,  /* 'sngf' */
        icSigSampledCalculatorCurve = 0x636c6366,  /* 'clcf' */
    }

    /** Enum for defining type of Single Sampled Curve**/
    public enum icSingleSampledCurveType
    : uint
    {
        icClipSingleSampledCurve = 0,
        icExtendSingleSampledCurve
    }

    /**
 * MPE Tone Map Function signature
 */
    public enum icToneFunctionSignature
     : uint
    {
        icSigToneMapFunction = 0x6d617066,  /* 'mapf' */
    }

    /** Enum to identify single segment curve / clut2 element storage type **/
    public enum icValueEncodingType
    : uint
    {
        icValueTypeFloat32 = 0,
        icValueTypeFloat16,
        icValueTypeUInt16,
        icValueTypeUInt8,
    }

    /*------------------------------------------------------------------------*/

    /**
     * Other enums
     */

    /** Measurement Flare, used in the measurmentType tag */
    public enum icMeasurementFlare
     : uint
    {
        icFlare0 = 0x00000000,  /* 0% flare */
        icFlare100 = 0x00000001,  /* 100% flare */
    }

    /** Measurement Geometry, used in the measurmentType tag */
    public enum icMeasurementGeometry
     : uint
    {
        icGeometryUnknown = 0x00000000,  /* Unknown geometry */
        icGeometry045or450 = 0x00000001,  /* 0/45, 45/0 */
        icGeometry0dord0 = 0x00000002,  /* 0/d or d/0 */
    }

    /** Rendering Intents, used in the profile header */
    public enum icRenderingIntent
     : uint
    {
        icPerceptual = 0,
        icRelativeColorimetric = 1,
        icRelative = 1,
        icSaturation = 2,
        icAbsoluteColorimetric = 3,
        icAbsolute = 3,
    }

    /** Different Spot Shapes currently defined, used for screeningType */
    public enum icSpotShape
    : uint
    {
        icSpotShapeUnknown = 0,
        icSpotShapePrinterDefault = 1,
        icSpotShapeRound = 2,
        icSpotShapeDiamond = 3,
        icSpotShapeEllipse = 4,
        icSpotShapeLine = 5,
        icSpotShapeSquare = 6,
        icSpotShapeCross = 7,
    }

    /** Standard Observer, used in the measurmentType tag */
    public enum icStandardObserver
    : uint
    {
        icStdObsUnknown = 0x00000000,  /* Unknown observer */
        icStdObs1931TwoDegrees = 0x00000001,  /* 1931 two degrees */
        icStdObs1964TenDegrees = 0x00000002,  /* 1961 ten degrees */
    }

    /** Pre-defined illuminants, used in measurement and viewing conditions type */
    public enum icIlluminant
    : uint
    {
        icIlluminantUnknown = 0x00000000,
        icIlluminantD50 = 0x00000001,
        icIlluminantD65 = 0x00000002,
        icIlluminantD93 = 0x00000003,
        icIlluminantF2 = 0x00000004,
        icIlluminantD55 = 0x00000005,
        icIlluminantA = 0x00000006,
        icIlluminantEquiPowerE = 0x00000007,  /* Equi-Power (E) */
        icIlluminantF8 = 0x00000008,

        /* The following illuminants are defined for V5 */
        icIlluminantBlackBody = 0x00000009,  /* defined by CCT */
        icIlluminantDaylight = 0x0000000A,  /* defiend by CCT */
        icIlluminantB = 0x0000000B,
        icIlluminantC = 0x0000000C,
        icIlluminantF1 = 0x0000000D,
        icIlluminantF3 = 0x0000000E,
        icIlluminantF4 = 0x0000000F,
        icIlluminantF5 = 0x00000010,
        icIlluminantF6 = 0x00000011,
        icIlluminantF7 = 0x00000012,
        icIlluminantF9 = 0x00000013,
        icIlluminantF10 = 0x00000014,
        icIlluminantF11 = 0x00000015,
        icIlluminantF12 = 0x00000016,
    }


    /** 
 * A not so exhaustive list of ISO 369 Language Codes 
 * Convenience definition - Not defined in ICC specification 
 * ICC.1 constrains to 16 bit (2 characters)
 * See https://www.iso.org/iso-639-language-codes.html
 */
    public enum icEnumLanguageCode
       : icUInt16Number
    {
        icLanguageCodeEnglish = 0x656E, /* 'en' */
        icLanguageCodeGerman = 0x6465, /* 'de' */
        icLanguageCodeItalian = 0x6974, /* 'it' */
        icLanguageCodeDutch = 0x6E6C, /* 'nl' */
        icLanguageCodeSweden = 0x7376, /* 'sv' */
        icLanguageCodeSpanish = 0x6573, /* 'es' */
        icLanguageCodeDanish = 0x6461, /* 'da' */
        icLanguageCodeNorwegian = 0x6E6F, /* 'no' */
        icLanguageCodeJapanese = 0x6A61, /* 'ja' */
        icLanguageCodeFinnish = 0x6669, /* 'fi' */
        icLanguageCodeTurkish = 0x7472, /* 'tr' */
        icLanguageCodeKorean = 0x6B6F, /* 'ko' */
        icLanguageCodeChinese = 0x7A68, /* 'zh' */
        icLanguageCodeFrench = 0x6672, /* 'fr' */
    }

    /**
 * A not so exhaustive list of ISO 3166 country codes.
 * Convenience definition - Not defined in ICC specification 
 * ICC.1 constrains to 16 bit (2 characters)
 * See https://www.iso.org/iso-3166-country-codes.html 
 */
    public enum icEnumCountryCode
     : icUInt16Number
    {
        icCountryCodeUSA = 0x5553, /* 'US' */
        icCountryCodeUnitedKingdom = 0x554B, /* 'UK' */
        icCountryCodeGermany = 0x4445, /* 'DE' */
        icCountryCodeItaly = 0x4954, /* 'IT' */
        icCountryCodeNetherlands = 0x4E4C, /* 'NL' */
        icCountryCodeSpain = 0x4543, /* 'ES' */
        icCountryCodeDenmark = 0x444B, /* 'DK' */
        icCountryCodeNorway = 0x4E4F, /* 'NO' */
        icCountryCodeJapan = 0x4A50, /* 'JP' */
        icCountryCodeFinland = 0x4649, /* 'FI' */
        icCountryCodeTurkey = 0x5452, /* 'TR' */
        icCountryCodeKorea = 0x4B52, /* 'KR' */
        icCountryCodeChina = 0x434E, /* 'CN' */
        icCountryCodeTaiwan = 0x5457, /* 'TW' */
        icCountryCodeFrance = 0x4652, /* 'FR' */
    }

    /** Measurement Unit Signatures used in ResponseCurveSet16Type */
    public enum icMeasurementUnitSig
    : uint
    {
        icSigStatusA = 0x53746141, /* 'StaA' */
        icSigStatusE = 0x53746145, /* 'StaE' */
        icSigStatusI = 0x53746149, /* 'StaI' */
        icSigStatusT = 0x53746154, /* 'StaT' */
        icSigStatusM = 0x5374614D, /* 'StaM' */
        icSigDN = 0x444E2020, /* 'DN  ' */
        icSigDNP = 0x444E2050, /* 'DN P' */
        icSigDNN = 0x444E4E20, /* 'DNN ' */
        icSigDNNP = 0x444E4E50, /* 'DNNP' */
    }

    /** Colorant and Phosphor Encodings used in chromaticity type */
    public enum icColorantEncoding
     : ushort
    {
        icColorantUnknown = 0x0000, /* Unknown */
        icColorantITU = 0x0001, /* ITU-R BT.709 */
        icColorantSMPTE = 0x0002, /* SMPTE RP145-1994 */
        icColorantEBU = 0x0003, /* EBU Tech.3213-E */
        icColorantP22 = 0x0004, /* P22 */
    }

    /**
 * Note: The next three enum types are for DeviceSettingType structures 
 * supported by V2 profiles.  The DeviceSettingsType was removed in the
 * V4 specificaiton.*/

    /** DeviceSettingsType structure ID signatures for Microsoft 'msft' platform*/
    public enum icMSFTDevSetSig
    : uint
    {
        icMSFTDevSetResolution = 0x72736C6E, /* 'rsln' */
        icMSFTDevSetMediaType = 0x6D747970, /* 'mtyp' */
        icMSFTDevSetMediaHalftone = 0x6866746E, /* 'hftn' */
    }

    /** DeviceSettingsType media encodings for Microsoft 'msft' platform */
    public enum icDMMediaType
    : ushort
    {
        icDMMediaStandard = 0x0001, /* Standard paper */
        icDMMediaTransparancy = 0x0002, /* Transparency */
        icDMMediaGlossy = 0x0003, /* Glossy paper */
        icDMMediaUser = 0x0100, /* Device-specific type media
                                                  are >= 256 */
    }

    /** DeviceSettingsType media encodings for Microsoft 'msft' platform */
    public enum icDMHalftoneType
    : ushort
    {
        icDMDitherNone = 0x0001, /* No dithering */
        icDMDitherCoarse = 0x0002, /* Dither with a coarse brush */
        icDMDitherFine = 0x0003, /* Dither with a fine brush */
        icDMDitherLineArt = 0x0004, /* LineArt dithering */
        icDMDitherErrorDiffusion = 0x0005, /* Error Diffusion */
        icDMDitherReserved6 = 0x0006,
        icDMDitherReserved7 = 0x0007,
        icDMDitherReserved8 = 0x0008,
        icDMDitherReserved9 = 0x0009,
        icDMDitherGrayscale = 0x000A, /* Device does grayscaling */
        icDMDitherUser = 0x0100, /* Device-specifice halftones 
                                                  are >= 256 */
    }

    public enum icSparseMatrixType
    : ushort
    {
        icSparseMatrixUInt8 = 0x0001,
        icSparseMatrixUInt16 = 0x0002,
        icSparseMatrixFloat16 = 0x0003,
        icSparseMatrixFloat32 = 0x0004,
    }

    /* Image encoding type encodings for embeddedHeightImageType and embeddedNormalImageType*/
    public enum icImageEncodingType
    : ushort
    {
        icPngImageType = 0x0000,
        icTiffImageType = 0x0001,
    }

    /**
*------------------------------------------------------------------------
*
 * Arrays of numbers 
 */

    /** Int8 Array */
    public struct icInt8Array
    {
        icInt8Number[] data;    /* Variable array of values */
    }

    /** UInt8 Array */
    public struct icUInt8Array
    {
        icUInt8Number[] data;    /* Variable array of values */
    }


    /** uInt16 Array */
    public struct icUInt16Array
    {
        icUInt16Number[] data;    /* Variable array of values */
    }


    /** Int16 Array */
    public struct icInt16Array
    {
        icInt16Number[] data;    /* Variable array of values */
    }


    /** uInt32 Array */
    public struct icUInt32Array
    {
        icUInt32Number[] data;    /* Variable array of values */
    }


    /** Int32 Array */
    public struct icInt32Array
    {
        icInt32Number[] data;    /* Variable array of values */
    }


    /** UInt64 Array */
    public struct icUInt64Array
    {
        icUInt64Number[] data;    /* Variable array of values */
    }


    /** Int64 Array */
    public struct icInt64Array
    {
        icInt64Number[] data;    /* Variable array of values */
    }

    /** u16Fixed16 Array*/
    public struct icU16Fixed16Array
    {
        icU16Fixed16Number[] data;    /* Variable array of values */
    }


    /** s15Fixed16 Array */
    public struct icS15Fixed16Array
    {
        icS15Fixed16Number[] data;    /* Variable array of values */
    }


    /** The base date time number */
    public struct icDateTimeNumber
    {
        icUInt16Number year;
        icUInt16Number month;
        icUInt16Number day;
        icUInt16Number hours;
        icUInt16Number minutes;
        icUInt16Number seconds;
    }

    /** XYZ Number  */
    public struct icXYZNumber
    {
        icS15Fixed16Number X;
        icS15Fixed16Number Y;
        icS15Fixed16Number Z;
    }


    /** XYZ Array */
    public struct icXYZArray
    {
        icXYZNumber[] data;    /* Variable array of XYZ numbers */
    }


    /** Floting point XYZ */
    public struct icFloatXYZNumber
    {
        icFloat32Number X;
        icFloat32Number Y;
        icFloat32Number Z;
    }


    /** xy Chromaticity Number  */
    public struct icChromaticityNumber
    {
        icU16Fixed16Number x;
        icU16Fixed16Number y;
    }

    /** response16Number  */
    public struct icResponse16Number
    {
        icUInt16Number deviceCode;
        icUInt16Number reserved;
        icS15Fixed16Number measurementValue;
    }


    /** positionNumber **/
    public struct icPositionNumber
    {
        icUInt32Number offset;
        icUInt32Number size;
    }


    /** spectral range */
    public struct icSpectralRange
    {
        icFloat16Number start;
        icFloat16Number end;
        icUInt16Number steps;
    }

    /** observer matrix */
    public struct icObserverMatrix
    {
        icSpectralRange range;
        icUInt16Number reserved;
        icFloat32Number[] data;
    }


    /** Illuminant Vector */
    public struct icIlluminantVector
    {
        icSpectralRange range;
        icUInt16Number reserved;
        icFloat32Number[] data;
    }

    /** Curve */
    public struct icCurve
    {
        icUInt32Number count;          /* Number of entries */
        icUInt16Number[] data;    /* The actual table data, real
                                         * number is determined by count
                                         * Interpretation depends on how
                                         * data is used with a given tag
                                         */
    }

    /** Parametric Curve */
    public struct icParametricCurve
    {
        icUInt16Number funcType;       /* Function Type                */
        /* 0 = gamma only               */
        icUInt16Number pad;            /* Padding for byte alignment   */
        icS15Fixed16Number gamma;          /* x°gamma                      */
        /* up to 7 values Y,a,b,c,d,e,f */
    }

    /** Parametric Curve */
    public struct icParametricCurveFull
    {
        icUInt16Number funcType;       /* Function Type                */
        /* 0 = gamma only               */
        icUInt16Number pad;            /* Padding for byte alignment   */
        icS15Fixed16Number gamma;          /* x°gamma                      */
        icS15Fixed16Number a;              /* a                            */
        icS15Fixed16Number b;              /* b                            */
        icS15Fixed16Number c;              /* c                            */
        icS15Fixed16Number d;              /* d                            */
        icS15Fixed16Number e;              /* e                            */
        icS15Fixed16Number f;              /* f                            */
    }

    /** Data */
    public struct icData
    {
        icDataBlockType dataFlag;       /* See icDataBlockType for details */
        icInt8Number[] data;    /* Data, size determined from tag */
    }

    /** lut16 */
    public struct icLut16
    {
        icUInt8Number inputChan;      /* Number of input channels */
        icUInt8Number outputChan;     /* Number of output channels */
        icUInt8Number clutPoints;     /* Number of clutTable grid points */
        icInt8Number pad;            /* Padding for byte alignment */
        icS15Fixed16Number e00;            /* e00 in the 3 * 3 */
        icS15Fixed16Number e01;            /* e01 in the 3 * 3 */
        icS15Fixed16Number e02;            /* e02 in the 3 * 3 */
        icS15Fixed16Number e10;            /* e10 in the 3 * 3 */
        icS15Fixed16Number e11;            /* e11 in the 3 * 3 */
        icS15Fixed16Number e12;            /* e12 in the 3 * 3 */
        icS15Fixed16Number e20;            /* e20 in the 3 * 3 */
        icS15Fixed16Number e21;            /* e21 in the 3 * 3 */
        icS15Fixed16Number e22;            /* e22 in the 3 * 3 */
        icUInt16Number inputEnt;       /* Number of input table entries */
        icUInt16Number outputEnt;      /* Number of output table entries */
        icUInt16Number[] data;    /* Data follows see spec for size */
        /**
       *  Data that follows is of this form
       *
       *  icUInt16Number      inputTable[inputChan][icAny];   * The input table
       *  icUInt16Number      clutTable[icAny];               * The clut table
       *  icUInt16Number      outputTable[outputChan][icAny]; * The output table
       */
    }

    /** lut8, input & output tables are always 256 bytes in length */
    public struct icLut8
    {
        icUInt8Number inputChan;      /* Number of input channels */
        icUInt8Number outputChan;     /* Number of output channels */
        icUInt8Number clutPoints;     /* Number of clutTable grid points */
        icInt8Number pad;
        icS15Fixed16Number e00;            /* e00 in the 3 * 3 */
        icS15Fixed16Number e01;            /* e01 in the 3 * 3 */
        icS15Fixed16Number e02;            /* e02 in the 3 * 3 */
        icS15Fixed16Number e10;            /* e10 in the 3 * 3 */
        icS15Fixed16Number e11;            /* e11 in the 3 * 3 */
        icS15Fixed16Number e12;            /* e12 in the 3 * 3 */
        icS15Fixed16Number e20;            /* e20 in the 3 * 3 */
        icS15Fixed16Number e21;            /* e21 in the 3 * 3 */
        icS15Fixed16Number e22;            /* e22 in the 3 * 3 */
        icUInt8Number[] data;    /* Data follows see spec for size */
        /**
       *  Data that follows is of this form
       *
       *  icUInt8Number       inputTable[inputChan][256];     * The input table
       *  icUInt8Number       clutTable[icAny];               * The clut table
       *  icUInt8Number       outputTable[outputChan][256];   * The output table
       */
    }

    /** icLutAToB  */
    public struct icCLutStruct
    {

        icUInt8Number[] gridPoints = new icUInt8Number[16]; /* Number of grid points in each dimension.  */
        icUInt8Number prec;           /* Precision of data elements in bytes.      */
        icUInt8Number pad1;
        icUInt8Number pad2;
        icUInt8Number pad3;
        /*icUInt8Number     data[icAny];     Data follows see spec for size */

        public icCLutStruct(byte[] gridPoints, byte prec, byte pad1, byte pad2, byte pad3)
        {
            this.gridPoints = gridPoints;
            this.prec = prec;
            this.pad1 = pad1;
            this.pad2 = pad2;
            this.pad3 = pad3;
        }

        public icCLutStruct()
        {
        }
    }


    /** icLutAtoB  */
    public struct icLutAtoB
    {
        icUInt8Number inputChan;      /* Number of input channels     */
        icUInt8Number outputChan;     /* Number of output channels    */
        icUInt8Number pad1;
        icUInt8Number pad2;
        icUInt32Number offsetB;        /* Offset to first "B" curve    */
        icUInt32Number offsetMat;      /* Offset to matrix             */
        icUInt32Number offsetM;        /* Offset to first "M" curve    */
        icUInt32Number offsetC;        /* Offset to CLUT               */
        icUInt32Number offsetA;        /* Offset to first "A" curve    */
        /*icUInt8Number     data[icAny];     Data follows see spec for size */
    }

    /** icLutBtoA  */
    public struct icLutBtoA
    {
        icUInt8Number inputChan;      /* Number of input channels     */
        icUInt8Number outputChan;     /* Number of output channels    */
        icUInt8Number pad1;
        icUInt8Number pad2;
        icUInt32Number offsetB;        /* Offset to first "B" curve    */
        icUInt32Number offsetMat;      /* Offset to matrix             */
        icUInt32Number offsetM;        /* Offset to first "M" curve    */
        icUInt32Number offsetC;        /* Offset to CLUT               */
        icUInt32Number offsetA;        /* Offset to first "A" curve    */
        /*icUInt8Number     data[icAny];     Data follows see spec for size */
    }


    /** Measurement Data */
    public struct icMeasurement
    {
        icStandardObserver stdObserver;    /* Standard observer */
        icXYZNumber backing;        /* XYZ for backing material */
        icMeasurementGeometry geometry;       /* Measurement geometry */
        icMeasurementFlare flare;          /* Measurement flare */
        icIlluminant illuminant;     /* Illuminant */
    }

    /** Entry format for each named color */
    public struct icNamedColor2Entry
    {
        icUInt8Number[] rootName = new icUInt8Number[32];        /* Root name for first color */
        icUInt16Number[] pcsCoords = new icUInt16Number[3];        /* PCS coordinates of color (only Lab or XYZ allowed)*/
        icUInt16Number[] deviceCoords; /* Device coordinates of color */

        public icNamedColor2Entry(byte[] rootName, ushort[] pcsCoords, ushort[] deviceCoords)
        {
            this.rootName = rootName;
            this.pcsCoords = pcsCoords;
            this.deviceCoords = deviceCoords;
        }

        public icNamedColor2Entry()
        {
        }
    }

    /**
 * icNamedColor2 takes the place of icNamedColor
 */
    public struct icNamedColor2
    {
        icUInt32Number vendorFlag;     /* Bottom 16 bits for IC use */
        icUInt32Number count;          /* Count of named colors */
        icUInt32Number nDeviceCoords;  /* Number of device coordinates */
        icInt8Number[] prefix = new icInt8Number[32];     /* Prefix for each color name */
        icInt8Number[] suffix = new icInt8Number[32];     /* Suffix for each color name */
        icInt8Number[] data;    /* Named color data follows */

        public icNamedColor2(uint vendorFlag, uint count, uint nDeviceCoords, sbyte[] prefix, sbyte[] suffix, sbyte[] data)
        {
            this.vendorFlag = vendorFlag;
            this.count = count;
            this.nDeviceCoords = nDeviceCoords;
            this.prefix = prefix;
            this.suffix = suffix;
            this.data = data;
        }

        public icNamedColor2()
        {
        }

        /**
       *  Data that follows is of this form
       *
       *   icInt8Number         root1[32];              * Root name for first color
       *   icUInt16Number       pcsCoords1[icAny];      * PCS coordinates of first color
       *   icUInt16Number       deviceCoords1[icAny];   * Device coordinates of first color
       *   icInt8Number         root2[32];              * Root name for second color
       *   icUInt16Number       pcsCoords2[icAny];      * PCS coordinates of first color
       *   icUInt16Number       deviceCoords2[icAny];   * Device coordinates of first color
       *                      :
       *                      :
       *
       * Alternatively written if byte packing is assumed with no padding between 
       * structures then data can take the following form
       *
       *   icNamedColor2Entry  entry0; // Entry for first color
       *   icNamedColor2Entry  entry1; // Entry for second color
       *                      :
       *                      :
       * In either case repeat for name and PCS and device color coordinates up to (count-1)
       * 
       * NOTES:  
       * PCS and device space can be determined from the header.
       *
       * PCS coordinates are icUInt16 numbers and are described in Annex A of 
       * the ICC spec. Only 16 bit L*a*b* and XYZ are allowed. The number of 
       * coordinates is consistent with the headers PCS.
       *
       * Device coordinates are icUInt16 numbers where 0x0000 represents
       * the minimum value and 0xFFFF represents the maximum value. 
       * If the nDeviceCoords value is 0 this field is not given.
       */
    }

    /** Profile sequence structure */
    public struct icDescStruct
    {
        icSignature deviceMfg;      /* Device Manufacturer */
        icSignature deviceModel;    /* Decvice Model */
        icUInt64Number attributes;     /* Device attributes */
        icTechnologySignature technology;     /* Technology signature */
        icInt8Number[] data;    /* Descriptions text follows */
        /**
       *  Data that follows is of this form, this is an icInt8Number
       *  to avoid problems with a compiler generating  bad code as 
       *  these arrays are variable in length.
       *
       * icTextDescription            deviceMfgDesc;  * Manufacturer text
       * icTextDescription            modelDesc;      * Model text
       */
    }

    /** Profile sequence description */
    public struct icProfileSequenceDesc
    {
        icUInt32Number count;          /* Number of descriptions */
        icUInt8Number[] data;    /* Array of description struct */
    }


    /** textDescription */
    public struct icTextDescription
    {
        icUInt32Number count;          /* Description length */
        icInt8Number[] data;    /* Descriptions follow */
        /**
       *  Data that follows is of this form
       *
       * icInt8Number         desc[count]     * NULL terminated ascii string
       * icUInt32Number       ucLangCode;     * UniCode language code
       * icUInt32Number       ucCount;        * UniCode description length
       * icInt16Number        ucDesc[ucCount];* The UniCode description
       * icUInt16Number       scCode;         * ScriptCode code
       * icUInt8Number        scCount;        * ScriptCode count
       * icInt8Number         scDesc[67];     * ScriptCode Description
       */
    }

    /** Screening Data */
    public struct icScreeningData
    {
        icS15Fixed16Number frequency;      /* Frequency */
        icS15Fixed16Number angle;          /* Screen angle */
        icSpotShape spotShape;      /* Spot Shape encodings below */
    }


    /** screening */
    public struct icScreening
    {
        icUInt32Number screeningFlag;  /* Screening flag */
        icUInt32Number channels;       /* Number of channels */
        icScreeningData[] data;    /* Array of screening data */
    }

    /** Text Data */
    public struct icText
    {
        icInt8Number[] data;    /* Variable array of characters */
    }


    /** Structure describing either a UCR or BG curve */
    public struct icUcrBgCurve
    {
        icUInt32Number count;          /* Curve length */
        icUInt16Number[] curve;   /* The array of curve values */
    }

    /** Under color removal, black generation */
    public struct icUcrBg
    {
        icInt8Number[] data;    /* The Ucr BG data */
        /**
       *  Data that follows is of this form, this is a icInt8Number
       *  to avoid problems with a compiler generating  bad code as 
       *  these arrays are variable in length.
       *
       * icUcrBgCurve         ucr;            * Ucr curve
       * icUcrBgCurve         bg;             * Bg curve
       * icInt8Number         string;         * UcrBg description
       */
    }

    /** viewingConditionsType */
    public struct icViewingCondition
    {
        icXYZNumber illuminant;     /* In candelas per metre sq'd */
        icXYZNumber surround;       /* In candelas per metre sq'd */
        icIlluminant stdIluminant;   /* See icIlluminant defines */
    }

    /** CrdInfo type */
    public struct icCrdInfo
    {
        icUInt32Number count;          /* Char count includes NULL */
        icInt8Number[] desc;    /* Null terminated string */
    }

    /** ColorantOrder type */
    public struct icColorantOrder
    {
        icUInt32Number count;          /* Count of colorants           */
        icUInt8Number[] data;    /* One-based number of the 
                                           colorant to be printed first,
                                           second...                    */
    }


    /** ColorantTable Entry */
    public struct icColorantTableEntry
    {
        icInt8Number[] name = new icInt8Number[32];       /* First colorant name              */
        icUInt16Number[] data = new icUInt16Number[3];        /* 16 bit PCS Lab value for first   */

        public icColorantTableEntry(sbyte[] name, ushort[] data)
        {
            this.name = name;
            this.data = data;
        }

        public icColorantTableEntry()
        {
        }
    }


    /** ColorantTable */
    public struct icColorantTable
    {
        icUInt32Number count;          /* Count of colorants           */
        icColorantTableEntry[] entry;   /* N colorant entries           */
    }

    /**
 * Tag Type definitions
 */


    /** The base part of each tag */
    public struct icTagBase
    {
        icTagTypeSignature sig;            /* Signature */
        icInt8Number[] reserved = new icInt8Number[4];    /* Reserved, set to 0 */

        public icTagBase(icTagTypeSignature sig, icInt8Number[] reserved)
        {
            this.sig = sig;
            this.reserved = reserved;
        }

        public icTagBase()
        {
        }
    }


    /** curveType */
    public struct icCurveType
    {
        icTagBase tagbase;           /* Signature, "curv" */
        icCurve curve;          /* The curve data */
    }


    /** ParametricCurveType */
    public struct icParametricCurveType
    {
        icTagBase tagbase;           /* Signature, "para"        */
        icParametricCurve curve;          /* The Parametric curve data*/
    }


    /** ParametricCurveFullType */
    public struct icParametricCurveFullType
    {
        icTagBase tagbase;           /* Signature, "para"        */
        icParametricCurveFull curve;        /* The Parametric curve data*/
    }


    /** dataType */
    public struct icDataType
    {
        icTagBase tagbase;           /* Signature, "data" */
        icData data;           /* The data structure */
    }

    /** dateTimeType */
    public struct icDateTimeType
    {
        icTagBase tagbase;           /* Signature, "dtim" */
        icDateTimeNumber date;           /* The date */
    }


    /** lut16Type */
    public struct icLut16Type
    {
        icTagBase tagbase;           /* Signature, "mft2" */
        icLut16 lut;            /* Lut16 data */
    }


    /** lut8Type, input & output tables are always 256 bytes in length */
    public struct icLut8Type
    {
        icTagBase tagbase;           /* Signature, "mft1" */
        icLut8 lut;            /* Lut8 data */
    }


    /** lutAtoBType new format */
    public struct icLutAtoBType
    {
        icTagBase tagbase;           /* Signature, "mAB " */
        icLutAtoB lut;            /* icLutAtoB data    */
    }

    /** lutBtoAType new format */
    public struct icLutBtoAType
    {
        icTagBase tagbase;           /* Signature, "mBA " */
        icLutBtoA lut;            /* icLutBtoA data    */
    }


    /** Measurement Type */
    public struct icMeasurementType
    {
        icTagBase tagbase;           /* Signature, "meas" */
        icMeasurement measurement;    /* Measurement data  */
    }

    /** icNamedColor2Type, replaces icNamedColorType */
    public struct icNamedColor2Type
    {
        icTagBase tagbase;           /* Signature, "ncl2" */
        icNamedColor2 ncolor;         /* Named color data  */
    }

    /** Profile sequence description type */
    public struct icProfileSequenceDescType
    {
        icTagBase tagbase;       /* Signature, "pseq" */
        icProfileSequenceDesc desc;       /* The seq description */
    }


    /** textDescriptionType */
    public struct icTextDescriptionType
    {
        icTagBase tagbase;           /* Signature, "desc" */
        icTextDescription desc;           /* The description */
    }


    /** s15Fixed16Type */
    public struct icS15Fixed16ArrayType
    {
        icTagBase tagbase;           /* Signature, "sf32" */
        icS15Fixed16Array data;           /* Array of values */
    }


    /** screeningType */
    public struct icScreeningType
    {
        icTagBase tagbase;           /* Signature, "scrn" */
        icScreening screen;         /* Screening structure */
    }


    /** sigType */
    public struct icSignatureType
    {
        icTagBase tagbase;           /* Signature, "sig" */
        icSignature signature;      /* The signature data */
    }


    /** textType */
    public struct icTextType
    {
        icTagBase tagbase;           /* Signature, "text" */
        icText data;           /* Variable array of characters */
    }


    /** u16Fixed16Type */
    public struct icU16Fixed16ArrayType
    {
        icTagBase tagbase;           /* Signature, "uf32" */
        icU16Fixed16Array data;           /* Variable array of values */
    }

    /** Under color removal, black generation type */
    public struct icUcrBgType
    {
        icTagBase tagbase;           /* Signature, "bfd " */
        icUcrBg data;           /* ucrBg structure */
    }


    /** uInt16Type */
    public struct icUInt16ArrayType
    {
        icTagBase tagbase;           /* Signature, "ui16" */
        icUInt16Array data;           /* Variable array of values */
    }


    /** uInt32Type */
    public struct icUInt32ArrayType
    {
        icTagBase tagbase;           /* Signature, "ui32" */
        icUInt32Array data;           /* Variable array of values */
    }


    /** uInt64Type */
    public struct icUInt64ArrayType
    {
        icTagBase tagbase;           /* Signature, "ui64" */
        icUInt64Array data;           /* Variable array of values */
    }

    /** uInt8Type */
    public struct icUInt8ArrayType
    {
        icTagBase tagbase;           /* Signature, "ui08" */
        icUInt8Array data;           /* Variable array of values */
    }


    /** viewingConditionsType */
    public struct icViewingConditionType
    {
        icTagBase tagbase;           /* Signature, "view" */
        icViewingCondition view;           /* Viewing conditions */
    }


    /** XYZ Type */
    public struct icXYZType
    {
        icTagBase tagbase;           /* Signature, "XYZ" */
        icXYZArray data;           /* Variable array of XYZ numbers */
    }

    /**
 * CRDInfoType where [0] is the CRD product name count and string and
 * [1] -[5] are the rendering intents 0-4 counts and strings
 */
    public struct icCrdInfoType
    {
        icTagBase tagbase;           /* Signature, "crdi" */
        icCrdInfo info;           /* 5 sets of counts & strings */
    }


    /*   icCrdInfo       productName;     PS product count/string */
    /*   icCrdInfo       CRDName0;        CRD name for intent 0 */
    /*   icCrdInfo       CRDName1;        CRD name for intent 1 */
    /*   icCrdInfo       CRDName2;        CRD name for intent 2 */
    /*   icCrdInfo       CRDName3;        CRD name for intent 3 */

    /** ColorantOrderType type */
    public struct icColorantOrderType
    {
        icTagBase tagbase;           /* Signature, "clro" */
        icColorantOrder order;          /* ColorantOrder     */
    }


    /** ColorantTableType type */
    public struct icColorantTableType
    {
        icTagBase tagbase;           /* Signature, "clrt" */
        icColorantTable table;          /* ColorantTable     */
    }


    /** ChromaticAdaptation type */
    public struct icChromaticAdaptationType
    {
        icTagBase tagbase;           /* Signature, "chad"            */
        icS15Fixed16Number[] matrix = new icS15Fixed16Number[9];      /* ChromaticAdaptation Matrix   */

        public icChromaticAdaptationType(icTagBase tagbase, icS15Fixed16Number[] matrix)
        {
            this.tagbase = tagbase;
            this.matrix = matrix;
        }

        public icChromaticAdaptationType()
        {
        }
    }


    /** MultiLocalizedUnicodeEntry type */
    public struct icMultiLocalizedUnicodeEntry
    {
        icUInt16Number languageCode;   /* name language code ISO-639           */
        icUInt16Number countryCode;    /* name country code ISO-3166           */
        icUInt32Number len;            /* string length in bytes               */
        icUInt32Number off;            /* offset in bytes from start of tag    */
    }


    /** MultiLocalizedUnicode type */
    public struct icMultiLocalizedUnicodeType
    {
        icTagBase tagbase;           /* Signature, "mluc"            */
        icUInt32Number count;          /* Count of name records        */
        icUInt32Number size;           /* name record size             */
    }

    /*------------------------------------------------------------------------*/

    /**
    * Lists of tags, tags, profile header and profile structure
     */

    /** A tag */
    public struct icTag
    {
        icTagSignature sig;            /* The tag signature */
        icUInt32Number offset;         /* Start of tag relative to 
                                         * start of header, Spec
                                         * Clause 5 */
        icUInt32Number size;           /* Size in bytes */
    }


    /** A Structure that may be used independently for a list of tags */
    public struct icTagList
    {
        icUInt32Number count;          /* Number of tags in the profile */
        icTag[] tags;    /* Variable array of tags */
    }

#if PORT

    /** Profile ID */
    typedef union {
    icUInt8Number         ID8[16];
    icUInt16Number        ID16[8];
    icUInt32Number        ID32[4];
} icProfileID;
#endif

    public struct icProfileID
    {
        icUInt32Number[] ID32;
    }

    /** The Profile header */
    public struct icHeader
    {
        icUInt32Number size;             /* Profile size in bytes */
        icSignature cmmId;            /* CMM for this profile */
        icUInt32Number version;          /* Format version number */
        icProfileClassSignature deviceClass;      /* Type of profile */
        icColorSpaceSignature colorSpace;       /* Color space of data */
        icColorSpaceSignature pcs;              /* PCS, XYZ or Lab only */
        icDateTimeNumber date;             /* Date profile was created */
        icSignature magic;            /* icMagicNumber */
        icPlatformSignature platform;         /* Primary Platform */
        icUInt32Number flags;            /* Various bit settings */
        icSignature manufacturer;     /* Device manufacturer */
        icUInt32Number model;            /* Device model number */
        icUInt64Number attributes;       /* Device attributes */
        icUInt32Number renderingIntent;  /* Rendering intent */
        icXYZNumber illuminant;       /* Profile illuminant */
        icSignature creator;          /* Profile creator */
        icProfileID profileID;        /* Profile ID using RFC 1321 MD5 128bit fingerprinting */
        /*Fields New for V5*/
        icSpectralColorSignature spectralPCS;      /* Spectral colour space signature */
        icSpectralRange spectralRange;    /* Start, end, and steps for spectral PCS */
        icSpectralRange biSpectralRange;  /* Start, end, and steps for bi-spectral PCS */
        icMaterialColorSignature mcs;              /* Material Connection Space */
        icSignature deviceSubClass;   /* Refinement on type of profile */
        //TODO(PORT) reserved[4]
        icInt8Number[] reserved;    /* Reserved for future use */
    }

    /** 
 * A profile, 
 * we can't use icTagList here because its not at the end of the structure
 */
    public struct icProfile
    {
        icHeader header;         /* The header */
        icTagList tagList;        /* with tagList */
        /* Original:
        icHeader            header;             The header 
        icUInt32Number      count;              Number of tags in the profile 
        icInt8Number        data[icAny];        The tagTable and tagData */
        /*
         * Data that follows is of the form
         *
         * icTag        tagTable[icAny];        * The tag table 
         * icInt8Number tagData[icAny];         * The tag data 
         */
    }

    /*------------------------------------------------------------------------*/
    /* Obsolete entries */

    /* icNamedColor was replaced with icNamedColor2 *
    typedef struct {
        icUInt32Number      vendorFlag;     / Bottom 16 bits for IC use *
        icUInt32Number      count;          / Count of named colors *
        icInt8Number        data[icAny];    / Named color data follows *
     *
     *  Data that follows is of this form
     *
     * icInt8Number         prefix[icAny];      * Prefix for the color name, max = 32
     * icInt8Number         suffix[icAny];      * Suffix for the color name, max = 32
     * icInt8Number         root1[icAny];       * Root name for first color, max = 32
     * icInt8Number         coords1[icAny];     * Color coordinates of first color
     * icInt8Number         root2[icAny];       * Root name for first color, max = 32
     * icInt8Number         coords2[icAny];     * Color coordinates of first color
     *                      :
     *                      :
     * Repeat for root name and color coordinates up to (count-1)
     *
    } icNamedColor; */

    /* icNamedColorType was replaced by icNamedColor2Type *
    typedef struct {
        icTagBase           base;           / Signature, "ncol" *
        icNamedColor        ncolor;         / Named color data *
    } icNamedColorType; */

    public static class Global
    {
        /** 
 * Define used to indicate that this is a variable length array
 */
        public const bool icAny = true;
        public const bool USE_WINDOWS_MB_SUPPORT = true;
        //TODO support big endian - also see original IccProfLibConf?
        public const bool ICC_BYTE_ORDER_LITTLE_ENDIAN = true;

        // Set to false if you do not want LAB to XYZ conversions to clip negative XYZ values
        // (Warning! Commenting this may result in incorrect round ripping for some Lab Values)
        public const bool REFICCMAX_NOCLIPLABTOXYZ = true;

        // Set to true if you wish to utilize ZLIB for compressed text tag types
        public const bool ICC_USE_ZLIB = false;

        // Set to true below if you wish to utilize Eigen library to support matrix solving
        public const bool ICC_USE_EIGEN_SOLVER = false;


        /** Useful macros for defining Curve Segment breakpoints **/
        public const icFloat32Number icMaxFloat32Number = 3.402823466e+38F;
        public const icFloat32Number icMinFloat32Number = -3.402823466e+38F;

        public const uint icDataTypeMask = 0x0000ffff;
        public const uint icCompressedData = 0x00010000;

        //Since msvc doesn't support cbrtf use pow instead
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ICC_CBRTF(double v) { return Math.Pow(v, 1.0 / 3.0); }

        public static icColorSpaceSignature icGetColorSpaceType(icUInt32Number sig) { return ((icColorSpaceSignature)(((icUInt32Number)sig) & 0xffff0000)); }
        public static bool icIsSameColorSpaceType(icUInt32Number sig, icUInt32Number type) { return ((((icUInt32Number)sig) & 0xffff0000) == ((icUInt32Number)(type))); }
        public static icUInt32Number icNumColorSpaceChannels(icUInt32Number sig) { return (((icUInt32Number)sig) & 0x0000ffff); }
        public static icColorSpaceSignature icNColorSpaceSig(icUInt32Number type, icUInt32Number n) { return ((icColorSpaceSignature)(icGetColorSpaceType(type) + icNumColorSpaceChannels(n))); }
        public static icSpectralColorSignature icSpectralColorSpaceSig(icUInt32Number type, icUInt32Number n) { return ((icSpectralColorSignature)(icGetColorSpaceType(type) + icNumColorSpaceChannels(n))); }

        public const icColorSpaceSignature icSigLabPcsData = icColorSpaceSignature.icSigLabData;
        public const icColorSpaceSignature icSigXYZPcsData = icColorSpaceSignature.icSigXYZData;
        public const icColorSpaceSignature icSigReflectanceSpectralPcsData = ((icColorSpaceSignature)icSpectralColorSignature.icSigReflectanceSpectralData);
        public const icColorSpaceSignature icSigTransmissionSpectralPcsData = ((icColorSpaceSignature)icSpectralColorSignature.icSigTransmisionSpectralData);
        public const icColorSpaceSignature icSigRadiantSpectralPcsData = ((icColorSpaceSignature)icSpectralColorSignature.icSigRadiantSpectralData);
        public const icColorSpaceSignature icSigBiDirReflectanceSpectralPcsData = ((icColorSpaceSignature)icSpectralColorSignature.icSigBiSpectralReflectanceData);
        public const icColorSpaceSignature icSigSparseMatrixSpectralPcsData = ((icColorSpaceSignature)icSpectralColorSignature.icSigSparseMatrixReflectanceData);

        /* Default luminance (cd/m^2) for converting between Luminance based and Normalized colorimetry */
        public const uint icDefaultLuminance = 160;

        // moved from IccCmm.h
        public const double icPerceptualRefBlackX = 0.00336;
        public const double icPerceptualRefBlackY = 0.0034731;
        public const double icPerceptualRefBlackZ = 0.00287;
        public const double icPerceptualRefWhiteX = 0.9642;
        public const double icPerceptualRefWhiteY = 1.0000;
        public const double icPerceptualRefWhiteZ = 0.8249;

        /**
 * MPE Spectral Data Conversion flags.
 */
        public const uint icRelativeSpectralData = 0x00000000;     /* Bit position 0 */
        public const uint icAbsoluteSpectralData = 0x00000001;     /* Bit position 0 */
        public const uint icXYZSpectralData = 0x00000000;     /* Bit position 1 */
        public const uint icLabSpectralData = 0x00000002;     /* Bit position 1 */


        public const icStandardObserver icStdObsCustom = icStandardObserver.icStdObsUnknown;
        public const icIlluminant icIlluminantCustom = icIlluminant.icIlluminantUnknown;

        /** Useful spectral range numbers */
        public const ushort icRange380nm = 0x5df0;
        public const ushort icRange400nm = 0x5e40;
        public const ushort icRange700nm = 0x6178;
        public const ushort icRange780nm = 0x6218;

        //From IccUtil.h
        public const double icPiNum = 3.14159265358979323846;
        public const double icPosInfinity = Double.PositiveInfinity;
        public const double icNegInfinity = Double.NegativeInfinity;
        public const double icNotANumber = Double.NaN;
        public static bool icNotZero(double v) { return ((v)>1.0e-8 || (v)<-1.0e-8); }


        //TODO can these be moved to their respective enums?
        /** Convenience Enum Definitions - Not defined in ICC specification*/
        public const icTagSignature icSigUnknownTag = ((icTagSignature)0x3f3f3f3f);  /* '????' */
        public const icTagSignature icMaxEnumTag = ((icTagSignature)0xFFFFFFFF);
        public const icTechnologySignature icMaxEnumTechnology = ((icTechnologySignature)0xFFFFFFFF);
        public const icTagTypeSignature icSigUnknownType = ((icTagTypeSignature)0x3f3f3f3f);  /* '????' */
        public const icTagTypeSignature icMaxEnumType = ((icTagTypeSignature)0xFFFFFFFF);
        public const icStructSignature icSigUnknownStruct = ((icStructSignature)0x3f3f3f3f);  /* '????' */
        public const icStructSignature icMaxEnumStruct = ((icStructSignature)0xFFFFFFFF);
        public const icArraySignature icSigUnknownArray = ((icArraySignature)0x3f3f3f3f);  /* '????' */
        public const icArraySignature icMaxEnumArray = ((icArraySignature)0xFFFFFFFF);
        public const icElemTypeSignature icSigUnknownElemType = ((icElemTypeSignature)0x3f3f3f3f);  /* '????' */
        public const icElemTypeSignature icMaxEnumElemType = ((icElemTypeSignature)0xFFFFFFFF);
        public const icBrdfMemberSignature icSigUnknownBrdfMember = ((icBrdfMemberSignature)0x3f3f3f3f);  /* '????' */
        public const icBrdfMemberSignature icMaxBrdfMember = ((icBrdfMemberSignature)0xFFFFFFFF);
        public const icColorantInfoMemberSignature icSigCinfUnknownMbr = ((icColorantInfoMemberSignature)0x3f3f3f3f);  /* '????' */
        public const icColorantInfoMemberSignature icMaxCinfMbr = ((icColorantInfoMemberSignature)0xFFFFFFFF);
        public const icColorEncodingParamsMemberSignature icSigCeptUnknownMbr = ((icColorEncodingParamsMemberSignature)0x3f3f3f3f);  /* '????' */
        public const icColorEncodingParamsMemberSignature icMaxCeptMbr = ((icColorEncodingParamsMemberSignature)0xFFFFFFFF);
        public const icMeasurementInfoMemberSignature icSigMeasUnknownMbr = ((icMeasurementInfoMemberSignature)0x3f3f3f3f);  /* '????' */
        public const icMeasurementInfoMemberSignature icMaxMeasMbr = ((icMeasurementInfoMemberSignature)0xFFFFFFFF);
        public const icNamedColorlMemberSignature icSigNmclUnknownMbr = ((icNamedColorlMemberSignature)0x3f3f3f3f);  /* '????' */
        public const icNamedColorlMemberSignature icMaxNmclMbr = ((icNamedColorlMemberSignature)0xFFFFFFFF);
        public const icProfileInfoMemberSignature icSigPinfUnknownMbr = ((icProfileInfoMemberSignature)0x3f3f3f3f);  /* '????' */
        public const icProfileInfoMemberSignature icMaxPinfMbr = ((icProfileInfoMemberSignature)0xFFFFFFFF);
        public const icTintZeroMemberSignature icSigTnt0UnknownMbr = ((icTintZeroMemberSignature)0x3f3f3f3f);  /* '????' */
        public const icTintZeroMemberSignature icMaxTnt0Mbr = ((icTintZeroMemberSignature)0xFFFFFFFF);
        public const icColorSpaceSignature icSigGamutData = ((icColorSpaceSignature)0x67616D74);  /* 'gamt' */
        public const icColorSpaceSignature icSigBRDFParameters = ((icColorSpaceSignature)0x62700000);  /* "bp0000" */
        public const icColorSpaceSignature icSigBRDFDirect = ((icColorSpaceSignature)0x62640000);  /* "bd0000" */
        public const icColorSpaceSignature icColorSpaceSignatureicSigUnknownData = ((icColorSpaceSignature)0x3f3f3f3f);  /* '????' */
        public const icColorSpaceSignature icMaxEnumData = ((icColorSpaceSignature)0xFFFFFFFF);
        public const icProfileClassSignature icMaxEnumClass = ((icProfileClassSignature)0xFFFFFFFF);
        public const icPlatformSignature icMaxEnumPlatform = ((icPlatformSignature)0xFFFFFFFF);
        public const icCmmSignature icMaxEnumCmm = ((icCmmSignature)0xFFFFFFFF);
        public const icReferenceMediumGamutSignature icMaxEnumReferenceMediumGamut = ((icReferenceMediumGamutSignature)0xFFFFFFFF);
        public const icColorimetricIntentImageStateSignature icMaxEnumColorimetricIntentImageState = ((icColorimetricIntentImageStateSignature)0xFFFFFFFF);
        public const icCurveSegSignature icMaxCurveSegSignature = ((icCurveSegSignature)0xFFFFFFFF);
        public const icCurveElemSignature icMaxCurveElemSignature = ((icCurveElemSignature)0xFFFFFFFF);
        public const icSingleSampledCurveType icMaxSingleSampledCurveType = icSingleSampledCurveType.icExtendSingleSampledCurve;
        public const icToneFunctionSignature icMaxToneFunctionsSignature = ((icToneFunctionSignature)0xFFFFFFFF);
        public const icValueEncodingType icMaxValueType = icValueEncodingType.icValueTypeUInt8;
        public const icAcsSignature icSigAcsZero = ((icAcsSignature)0x00000000);
        public const icMeasurementFlare icMaxEnumFlare = ((icMeasurementFlare)0xFFFFFFFF);
        public const icMeasurementFlare icMaxFlare = ((icMeasurementFlare)0xFFFFFFFF); /* as defined by earlier versions */
        public const icMeasurementGeometry icMaxEnumGeometry = ((icMeasurementGeometry)0xFFFFFFFF);
        public const icMeasurementGeometry icMaxGeometry = ((icMeasurementGeometry)0xFFFFFFFF);
        public const icRenderingIntent icUnknownIntent = ((icRenderingIntent)0x3f3f3f3f);  /* '????' */
        public const icRenderingIntent icMaxEnumIntent = ((icRenderingIntent)0xFFFFFFFF);
        public const icSpotShape icMaxEnumSpot = ((icSpotShape)0xFFFFFFFF);
        public const icStandardObserver icMaxEnumStdObs = ((icStandardObserver)0xFFFFFFFF);
        public const icStandardObserver icMaxStdObs = ((icStandardObserver)0xFFFFFFFF); /* as defined by earlier versions */
        public const icIlluminant icMaxEnumIlluminant = ((icIlluminant)0xFFFFFFFF);
        public const icIlluminant icMaxEnumIluminant = ((icIlluminant)0xFFFFFFFF);   /* as defined by earlier versions */
        public const icMeasurementUnitSig icMaxEnumMeasurmentUnitSig = ((icMeasurementUnitSig)0xffffffff);
        public const icColorantEncoding icMaxEnumColorant = ((icColorantEncoding)0xFFFF);
        public const icSparseMatrixType icSparseMatrixFloatNum = ((icSparseMatrixType)0x0000); //Use internal icFloatNumber encoding
    }
}
