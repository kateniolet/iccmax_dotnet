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
#if defined(XRITE_ADDITIONS)
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
 public enum icStructSignature : uint {
        icSigBRDFStruct = 0x62726466,  /* 'brdf' */
        icSigColorantInfoStruct = 0x63696e66,  /* 'cinf' */
        icSigColorEncodingParamsSruct = 0x63657074,  /* 'cept' */
        icSigMeasurementInfoStruct = 0x6d656173,  /* 'meas' */
        icSigNamedColorStruct = 0x6e6d636c,  /* 'nmcl' */
        icSigProfileInfoStruct = 0x70696e66,  /* 'pinf' */
        icSigTintZeroStruct = 0x746e7430,  /* 'tnt0' */
        icSigUndefinedStruct = 0x00000000,
    }
    

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

        /** Convenience Enum Definitions - Not defined in ICC specification*/
        public const icTagSignature icSigUnknownTag = ((icTagSignature)0x3f3f3f3f);  /* '????' */
        public const icTagSignature icMaxEnumTag = ((icTagSignature)0xFFFFFFFF);
        public const icTechnologySignature icMaxEnumTechnology = ((icTechnologySignature)0xFFFFFFFF);
        public const icTagTypeSignature icSigUnknownType = ((icTagTypeSignature)0x3f3f3f3f);  /* '????' */
        public const icTagTypeSignature icMaxEnumType = ((icTagTypeSignature)0xFFFFFFFF);
        public const icStructSignature icSigUnknownStruct = ((icStructSignature)0x3f3f3f3f);  /* '????' */
        public const icStructSignature icMaxEnumStruct = ((icStructSignature)0xFFFFFFFF);
    }
}
