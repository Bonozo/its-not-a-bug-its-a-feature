using UnityEngine;
using System.Collections;

// JankSound.cs
// Usage:
// 1) Attach this script to audio listener (usually camera)
// 2) Run game and use inspector "click this to test" to try it out
// 3) To trigger from code, call "JankSound.jankout();"
// for best results use with audio that is 44100hz stereo format

public class JankSound : MonoBehaviour
{

    public bool jankOn = true;
    public bool clickThisToTest = false;
    public float jankFactorBaseline_01 = 0.0f;
    public float jankFactorDuringJankOut_01 = 1.0f;
    public float jankOutDecaySec = 2.34f;
    public float jankTypeH_01 = 0.36f;
    public float jankTypeA_01 = 0.32f;
    public float jankTypeI_01 = 0.31f;

    static float janktimer = 0;
    public static void jankout()
    {
        {
            {
                janktimer = 1.0f;
            }
        }
    }

    /// <summary>
    /// T/////////////////stahpomgmonodevelopwhy    /// </summary>

    public bool vvv_no_touch_vvv;

    const int c8 = 44100 * 2;
    float[] zz = new float[c8];
    int z = 0;
    float timmy1 = 0;
    float timmy2 = 0;
    float timmy3 = 0;
    float freq1 = 0.65f;
    float freq2 = 0.54f;
    float freq3 = 0.43f;
    float jankness;


    float x(float i, int j)
    {
        float s44100 = (44100.0f * j);
        float s44c = 1.0f / s44100;
        jankness = jankFactorBaseline_01;
        if (janktimer > 0)
        {
            janktimer -= s44c / jankOutDecaySec;
            float flerp = Mathf.Clamp01(janktimer);
            flerp = 1 - ((flerp - 0.5f) * (flerp - 0.5f)) * 4;
            jankness = Mathf.Lerp(jankFactorBaseline_01, jankFactorDuringJankOut_01, flerp);
        }
        //zap = !zap;

        timmy1 += s44c * (freq1);
        timmy2 += s44c * (freq2);
        timmy3 += s44c * ((freq3 * (0.50f + 0.25f * Mathf.Sin(Mathf.PI * 2 * timmy2))));
        timmy1 -= (int)timmy1;
        timmy2 -= (int)timmy2;
        timmy3 -= (int)timmy3;
        float farfenugen = 0.5f;
        farfenugen += jankTypeH_01 * 0.20f * Mathf.Sin(Mathf.PI * 2 * timmy1);// * (zap?1:-1);
        farfenugen += jankTypeA_01 * 0.10f * Mathf.Sin(Mathf.PI * 2 * timmy2);// * (zap?1:-1);
        farfenugen += jankTypeI_01 * 0.10f * Mathf.Sin(Mathf.PI * 2 * timmy3);// * (zap?1:-1);
        z = (z + 1) % c8;
        zz[z] = i;
        int offset = ((int)(c8 * farfenugen * jankness / j)) * j;
        int z2 = (z + c8 * 2 - offset) % c8;
        test = offset;
        return zz[z2];
    }
    public float test;
    void OnAudioFilterRead(float[] f, int j)
    {
        if (!jankOn) return;
        for (int i = 0; i < f.Length; i += 1)
        {
            f[i] = x(f[i], j);
        }
    }

    void Update()
    {
        if (clickThisToTest)
        {
            clickThisToTest = false;
            jankout();
        }
    }

}