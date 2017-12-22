#pragma once
#ifndef NAMESPACE_H
#define NAMESPACE_H

namespace Qa
{

#define PI 3.1415926535898

    enum DrawFunction
    {
        None, Line, Solid, Fill
    };
    enum PenStyle 
    {
        NoPen = PS_NULL,
        SolidLine = PS_SOLID,
        DashLine = PS_DASH,
        DotLine = PS_DOT,
        DashDotLine = PS_DASHDOT,
        DashDotDotLine = PS_DASHDOTDOT,
        CustomDashLine = PS_USERSTYLE
    };
    enum PenCapStyle 
    {
        FlatCap = PS_ENDCAP_FLAT,
        SquareCap = PS_ENDCAP_SQUARE,
        RoundCap = PS_ENDCAP_ROUND
    };
    enum PenJoinStyle
    {
        MiterJoin = PS_JOIN_MITER,
        BevelJoin = PS_JOIN_BEVEL,
        RoundJoin = PS_JOIN_ROUND
    };
    enum BrushStyle 
    {
        NoBrush = BS_NULL,
        SolidPattern = BS_SOLID,
        HatchedPattern = BS_HATCHED,
        Pattern = BS_PATTERN,
        TexturePattern = BS_DIBPATTERN,
        HorPattern = HS_HORIZONTAL,
        VerPattern = HS_VERTICAL,
        BDiagPattern = HS_FDIAGONAL,
        FDiagPattern = HS_BDIAGONAL,
        CrossPattern = HS_CROSS,
        DiagCrossPattern = HS_DIAGCROSS
    };
    enum BackgroundMode
    {
        Opaque = OPAQUE,
        Transparent = TRANSPARENT
    };
    enum PolyFillMode 
    {
        Altenate = ALTERNATE,
        Winding = WINDING
    };
    enum Rop2Mode
    {
        R2Black = R2_BLACK,
        R2CopyPen = R2_COPYPEN,
        R2MaskNotPen = R2_MASKNOTPEN,
        R2MaskPen = R2_MASKPEN,
        R2MaskPenNot = R2_MASKPENNOT,
        R2MergNotPen = R2_MERGENOTPEN,
        R2MergePen = R2_MERGEPEN,
        R2MergePenNot = R2_MERGEPENNOT,
        R2NoP = R2_NOP,
        R2Not = R2_NOT,
        R2NotCopyPen = R2_NOTCOPYPEN,
        R2NotMaskPen = R2_NOTMASKPEN,
        R2NotMergePen = R2_NOTMERGEPEN,
        R2NotXorPen = R2_NOTXORPEN,
        R2White = R2_WHITE,
        R2XorPen = R2_XORPEN
    };
    enum RGNMode
    {
        RgnAnd = RGN_AND,
        RgnCopy = RGN_COPY,
        RgnFIFF = RGN_DIFF,
        RgnOR = RGN_OR,
        RgnXOR = RGN_XOR
    };
    enum TextFormat
    {
        FwDontcare = FW_DONTCARE,
        FwThin = FW_THIN,
        FwExtralight = FW_EXTRALIGHT,
        FwUltralight = FW_ULTRALIGHT,
        FwLight = FW_LIGHT,
        FwNormal = FW_NORMAL,
        FwRegular = FW_REGULAR,
        FwMedium = FW_MEDIUM,
        FwSemibold = FW_SEMIBOLD,
        FwDemibold = FW_DEMIBOLD,
        FwBold = FW_BOLD,
        FwExtrabold = FW_EXTRABOLD,
        FwUltrabold = FW_ULTRABOLD,
        FwHeavy = FW_HEAVY,
        FwBlack = FW_BLACK
    };
    enum TextCharset
    {
        CharsetAnsi = ANSI_CHARSET,
        CharsetBaltic = BALTIC_CHARSET,
        CharsetChinesebig5= CHINESEBIG5_CHARSET,
        CharsetDefault = DEFAULT_CHARSET,
        CharsetEasteurope = EASTEUROPE_CHARSET,
        CharsetGb2312 = GB2312_CHARSET,
        CharsetGreek = GREEK_CHARSET,
        CharsetHangul = HANGUL_CHARSET,
        CharsetMac = MAC_CHARSET,
        CharsetOem = OEM_CHARSET,
        CharsetRussian = RUSSIAN_CHARSET,
        CharsetShiftjis = SHIFTJIS_CHARSET,
        CharsetSymbol = SYMBOL_CHARSET,
        CharsetThurkish = TURKISH_CHARSET
    };
    enum TextPrecision 
    {
        OutDefault = OUT_DEFAULT_PRECIS,
        OutDevice = OUT_DEVICE_PRECIS,
        OutOutLine = OUT_OUTLINE_PRECIS,
        OutRaster = OUT_RASTER_PRECIS,
        OutString = OUT_STRING_PRECIS,
        OutStroke = OUT_STROKE_PRECIS,
        OutOnly = OUT_TT_ONLY_PRECIS,
        OutTt = OUT_TT_PRECIS,
    };
    enum TextClipPrecision
    {
        ClipDefault = CLIP_DEFAULT_PRECIS,
        ClipStroke = CLIP_STROKE_PRECIS,
        ClipEmbedded = CLIP_EMBEDDED,
        ClipAngles = CLIP_LH_ANGLES
    };
    enum TextQuality
    {
        QualityAntialiased = ANTIALIASED_QUALITY,
        QualityDefault = DEFAULT_QUALITY,
        QualityDraft = DRAFT_QUALITY,
        QualityNonantIaliased = NONANTIALIASED_QUALITY,
        QualityProof = PROOF_QUALITY
    };
    enum TextPitchAndFamily
    {
        PitchDefault = DEFAULT_PITCH,
        PitchFixed = FIXED_PITCH,
        PitchVariable = VARIABLE_PITCH,
        PitchDecorative = FF_DECORATIVE,
        PitchDontCare = FF_DONTCARE,
        PitchModern = FF_MODERN,
        PitchRoman = FF_ROMAN,
        PitchScript = FF_SCRIPT,
        PitchSwiss = FF_SWISS
    };
    enum MouseCode
    {
        MouseLeftButton,
        MouseRightButton,
        MouseMiddleButton
    };
    enum KeyCode
    {

        Key_0 = 48,
        Key_1 = 49,
        Key_2 = 50,
        Key_3 = 51,
        Key_4 = 52,
        Key_5 = 53,
        Key_6 = 54,
        Key_7 = 55,
        Key_8 = 56,
        Key_9 = 57,
        Key_A = 65,
        Key_B = 66,
        Key_C = 67,
        Key_D = 68,
        Key_E = 69,
        Key_F = 70,
        Key_G = 71,
        Key_H = 72,
        Key_I = 73,
        Key_J = 74,
        Key_K = 75,
        Key_L = 76,
        Key_M = 77,
        Key_N = 78,
        Key_O = 79,
        Key_P = 80,
        Key_Q = 81,
        Key_R = 82,
        Key_S = 83,
        Key_T = 84,
        Key_U = 85,
        Key_V = 86,
        Key_W = 87,
        Key_X = 88,
        Key_Y = 89,
        Key_Z = 90,
    };
}

#endif // !NAMESPACE_H
