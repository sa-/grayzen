namespace grayzen
{
    using static NativeMethods;

    class Grayscaler
    {
        private const float redWeight = 0.2126f;
        private const float greenWeight = 0.7152f;
        private const float blueWeight = 0.0722f;

        internal static void GoGrey()
        {
            var magEffectInvert = new MAGCOLOREFFECT
            {
                transform = new[] {
                    redWeight,   redWeight,   redWeight,   0.0f,  0.0f,
                    greenWeight, greenWeight, greenWeight, 0.0f,  0.0f,
                    blueWeight,  blueWeight,  blueWeight,  0.0f,  0.0f,
                    0.0f,       0.0f,       0.0f,       1.0f,  0.0f,
                    0.0f,       0.0f,       0.0f,       0.0f,  1.0f
                }
            };

            MagSetFullscreenColorEffect(ref magEffectInvert);

        }

        internal static void DontTransformColor()
        {
            var normal = new MAGCOLOREFFECT
            {
                transform = new[] {
                    1.0f,       0.0f,       0.0f,       0.0f,  0.0f,
                    0.0f,       1.0f,       0.0f,       0.0f,  0.0f,
                    0.0f,       0.0f,       1.0f,       0.0f,  0.0f,
                    0.0f,       0.0f,       0.0f,       1.0f,  0.0f,
                    0.0f,       0.0f,       0.0f,       0.0f,  1.0f
                }
            };
            MagSetFullscreenColorEffect(ref normal);
        }
    }
}
